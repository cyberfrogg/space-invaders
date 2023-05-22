using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace BuildUtils.Tools
{
	public static class EditorTestValidator
	{
		private const string NUnitTestFileName = "nunit-results.xml";
		private const string ValidationNUnitLogFileName = "nunit-validation-log.txt";
		private const string PlayableTestFileName = "playable-results.xml";
		private const string ValidationPlayableLogFileName = "playable-validation-log.txt";

		public static void ValidateTests(string testsPath)
		{
			var nunitTestResult = new FileInfo(Path.Combine(testsPath, NUnitTestFileName));
			var playableTestResult = new FileInfo(Path.Combine(testsPath, PlayableTestFileName));
			if (!nunitTestResult.Exists)
				throw new System.Exception($"[EditorTestValidator] Can not find {NUnitTestFileName} file.");
			if (!playableTestResult.Exists)
				throw new System.Exception($"[EditorTestValidator] Can not find {PlayableTestFileName} file.");

			var nunitFailed = IsTestsFailed(nunitTestResult, out var nunitLog);
			var playableFailed = IsTestsFailed(playableTestResult, out var playableLog);

			File.WriteAllText(Path.Combine(testsPath, ValidationNUnitLogFileName), nunitLog);
			File.WriteAllText(Path.Combine(testsPath, ValidationPlayableLogFileName), playableLog);

			if (nunitFailed || playableFailed)
				throw new System.Exception(
					$"[EditorTestValidator] Test validation failed. Look more detail in validation log file from path: {testsPath}");
		}

		private static bool IsTestsFailed(FileInfo fileInfo, out string logText)
		{
			var document = new XmlDocument();
			document.Load(fileInfo.FullName);
			return GetTestResult(document.DocumentElement, out logText);
		}

		private static bool GetTestResult(XmlElement element, out string logText)
		{
			var stringBuilder = new StringBuilder();
			var firstSuite = element.ToEnumerable().First();
			var failed = int.Parse(element.GetAttributeValue("failed"));
			var asserts = int.Parse(element.GetAttributeValue("asserts"));

			stringBuilder
				.Append("Project: " + firstSuite.GetAttributeValue("name"))
				.Append("\r\n")
				.Append("Total: " + element.GetAttributeValue("total"))
				.Append("\r\n")
				.Append("Passed: " + element.GetAttributeValue("passed"))
				.Append("\r\n")
				.Append("Failed: " + failed)
				.Append("\r\n")
				.Append("Inconclusive: " + element.GetAttributeValue("inconclusive"))
				.Append("\r\n")
				.Append("skipped: " + element.GetAttributeValue("skipped"))
				.Append("\r\n")
				.Append("Asserts: " + asserts)
				.Append("\r\n")
				.Append("Start time: " + element.GetAttributeValue("start-time"))
				.Append("\r\n")
				.Append("End time: " + element.GetAttributeValue("end-time"))
				.Append("\r\n\r\n");

			var testCases = GetPassesResult(firstSuite);
			stringBuilder.Append("----------    TESTS PASSED    ----------").Append("\r\n\r\n");

			foreach (var testCase in testCases.Where(f => !f.IsFailed))
				stringBuilder.Append(testCase).Append("\r\n");

			stringBuilder.Append("\r\n").Append("----------    TESTS FAILED    ----------").Append("\r\n\r\n");

			foreach (var testCase in testCases.Where(f => f.IsFailed))
				stringBuilder.Append(testCase).Append("\r\n");

			var isFailed = asserts > 0 || failed > 0;
			stringBuilder.Append("\r\n")
				.Append(isFailed ? "----------    FAIL    ----------" : "----------    SUCCESS    ----------");

			logText = stringBuilder.ToString();
			return isFailed;
		}

		private static List<TestCase> GetPassesResult(XmlElement element)
		{
			var list = new List<TestCase>();

			if (element.Name == "test-suite")
			{
				var childCollection = element.ToEnumerable()
					.Where(f => f.Name == "test-suite" || f.Name == "test-case");
				foreach (var child in childCollection)
				{
					var testCases = GetPassesResult(child);
					list.AddRange(testCases);
				}
			}
			else if (element.Name == "test-case")
				list.Add(new TestCase(
					element.GetAttributeValue("result"),
					element.GetAttributeValue("classname"),
					element.GetAttributeValue("methodname")));

			return list;
		}

		private class TestCase
		{
			public readonly string Result;
			public bool IsFailed => Result == "Failed";
			public readonly string ClassName;
			public readonly string MethodName;

			public TestCase(string result, string className, string methodName)
			{
				Result = result;
				ClassName = className;
				MethodName = methodName;
			}

			public override string ToString() => $"{ClassName} -> {MethodName}";
		}
	}
}