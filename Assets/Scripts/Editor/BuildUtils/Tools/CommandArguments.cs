using System;

namespace Utils.Tools
{
	public static class CommandArguments
	{

		private static bool _readed;
		private static string[] _args;

		public static string[] Args
		{
			get
			{
				if (!_readed)
				{
					_args = Environment.GetCommandLineArgs();
					_readed = true;
				}

				return _args;
			}
		}

		public static string GetArgParameter(string key)
		{
			foreach (var arg in Args)
			{
				var parameters = arg.Split('=');
				if(parameters.Length < 2 || parameters[0] != key)
					continue;
				return parameters[1];
			}

			return string.Empty;
		}

	}
}