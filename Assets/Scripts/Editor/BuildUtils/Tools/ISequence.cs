using System;

namespace Utils.Tools
{
	public interface ISequence
	{
		void Do(Action onComplete);
	}
}