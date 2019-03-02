using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
	class Program
	{
		static void Main(string[] args)
		{
			Client client = new Client();
			Leaf leaf = new Leaf();
			Console.WriteLine("Client: I get a simple component:");
			client.ClientCode(leaf);

			Component tree = new Composite();
			Composite branch1 = new Composite();
			branch1.Add(new Leaf());
			branch1.Add(new Leaf());
			Composite branch2 = new Composite();
			branch2.Add(new Leaf());
			tree.Add(branch1);
			tree.Add(branch2);
			Console.WriteLine("Client: Now I've got a composite tree:");
			client.ClientCode(tree);
			Console.WriteLine("Client: I don't need to check the components classes even" +
				" when managing the tree:\n");
			client.ClientCode2(tree, leaf);
		}
	}

	public class Client
	{
		public void ClientCode(Component component)
		{
			Console.WriteLine($"RESULT: {component.Operation()}\n");
		}

		public void ClientCode2(Component component1, Component component2)
		{
			if (component1.IsComposite())
				component1.Add(component2);
			Console.WriteLine($"RESULT: {component1.Operation()}");
		}
	}

	public abstract class Component
	{
		public abstract String Operation();

		public virtual void Add(Component component)
		{
			throw new NotImplementedException();
		}

		public virtual void Remove(Component component)
		{
			throw new NotImplementedException();
		}

		public virtual Boolean IsComposite()
		{
			return true;
		}
	}

	public class Leaf : Component
	{
		public override string Operation()
		{
			return "Leaf";
		}

		public override bool IsComposite()
		{
			return false;
		}
	}

	public class Composite : Component
	{
		protected List<Component> _children = new List<Component>();

		public override void Add(Component component)
		{
			_children.Add(component);
		}

		public override void Remove(Component component)
		{
			_children.Remove(component);
		}

		public override string Operation()
		{
			Int32 i = 0;
			StringBuilder result = new StringBuilder("Branch(", 100);

			foreach(var component in _children)
			{
				result.Append(component.Operation());
				if (i++ != _children.Count - 1)
					result.Append("+");
			}
			return result.Append(")").ToString();
		}
	}
}
