using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
  class Program
  {
    static void Main(string[] args)
    {
			var director = new Director();
			var builder = new ConcreteBuilder();
			director.Builder = builder;

			Console.WriteLine("Standard basic product:");
			director.BuildMinimalViableProduct();
			Console.WriteLine(builder.GetProduct().ListParts());

			Console.WriteLine("Standard full featured product:");
			director.BuildFullFeaturedProduct();
			Console.WriteLine(builder.GetProduct().ListParts());

			Console.WriteLine("Custom product:");
			builder.BuildPartA();
			builder.BuildPartC();
			Console.WriteLine(builder.GetProduct().ListParts());

    }
  }

	public interface IBuilder
	{
		void BuildPartA();
		void BuildPartB();
		void BuildPartC();
	}

	public class ConcreteBuilder : IBuilder
	{
		private Product _product = new Product();

		public void Reset()
		{
			this._product = new Product();
		}

		public void BuildPartA()
		{
			this._product.Add("PartA1");
		}

		public void BuildPartB()
		{
			this._product.Add("PartA2");
		}

		public void BuildPartC()
		{
			this._product.Add("PartA3");
		}

		public Product GetProduct()
		{
			Product result = this._product;
			this.Reset();
			return result;
		}
	}

	public class Product
	{
		private List<Object> _parts = new List<object>();

		public void Add(String part)
		{
			this._parts.Add(part);
		}

		public String ListParts()
		{
			StringBuilder str = new StringBuilder();
			str.Append("Product parts: ");
			for (int i = 0; i < this._parts.Count; i++)
				str.Append(this._parts[i]).Append(", ");
			str.Remove(str.Length - 2, 2).AppendLine();
			return str.ToString();
		}
	}

	public class Director
	{
		private IBuilder _builder;

		public IBuilder Builder { set => _builder = value; }

		public void BuildMinimalViableProduct()
		{
			this._builder.BuildPartA();
		}

		public void BuildFullFeaturedProduct()
		{
			this._builder.BuildPartA();
			this._builder.BuildPartB();
			this._builder.BuildPartC();
		}
	}
}
