using System.Collections.Generic;

namespace Utils.Tools
{
	public class SequenceManager
	{
		private readonly Queue<ISequence> _sequences = new Queue<ISequence>();

		public SequenceManager Add(ISequence sequence)
		{
			_sequences.Enqueue(sequence);
			return this;
		}

		public void Do()
		{
			if (_sequences.Count == 0)
				return;
			var sequence = _sequences.Dequeue();
			sequence.Do(Do);
		}

		public void Clear() => _sequences.Clear();
	}
}