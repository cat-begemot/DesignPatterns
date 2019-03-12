using System;
using System.Collections;
using System.Collections.Generic;

namespace Iterator
{
  class Program
  {
    static void Main(string[] args)
    {
			var collection = new WordsCollection();
			collection.AddItem("First");
			collection.AddItem("Second");
			collection.AddItem("Third");

			void IterateCollection()
			{
				foreach(var item in collection)
					Console.WriteLine(item);
			}

			Console.WriteLine("Straight traversal: ");
			IterateCollection();

			Console.WriteLine("\nReverse traversal:");
			collection.ReverseDirection();
			IterateCollection();
		}
  }

	internal abstract class Iterator : IEnumerator
	{
		Object IEnumerator.Current => Current();

		public abstract Int32 Key();

		public abstract Object Current();

		public abstract Boolean MoveNext();

		public abstract void Reset();
	}

	internal abstract class IteratorAggregate : IEnumerable
	{
		public abstract IEnumerator GetEnumerator();
	}

	internal class AlphabeticalOrderIterator : Iterator
	{
		WordsCollection collection;
		Int32 position = -1;
		Boolean reverse = false;

		public AlphabeticalOrderIterator(WordsCollection col, Boolean rev=false)
		{
			collection = col;
			reverse = rev;
			if (reverse) position = collection.GetItems().Count;
		}

		public override object Current()
		{
			return collection.GetItems()[position];
		}

		public override int Key()
		{
			return position;
		}

		public override bool MoveNext()
		{
			Int32 updatedPosition = position + (reverse ? -1 : 1);
			if (updatedPosition >= 0 && updatedPosition < collection.GetItems().Count)
			{
				position = updatedPosition;
				return true;
			}
			else
				return false;
		}

		public override void Reset()
		{
			position = reverse ? collection.GetItems().Count - 1 : 0;
		}
	}

	internal class WordsCollection : IteratorAggregate
	{
		List<String> collection = new List<String>();
		Boolean direction = false;

		public void ReverseDirection() => direction = !direction;

		public List<String> GetItems() => collection;

		public void AddItem(String item) => collection.Add(item);

		public override IEnumerator GetEnumerator() => 
			new AlphabeticalOrderIterator(this, direction);
	}
}
