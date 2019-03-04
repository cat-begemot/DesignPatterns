using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace Flyweight
{
	class Program
  {
    static void Main(string[] args)
    {
			var factory = new FlyweightFactory(
				new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
				new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
				new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
				new Car { Company = "BMW", Model = "M5", Color = "red" },
				new Car { Company = "BMW", Model = "X6", Color = "white" }
				);
			factory.ListFlyweights();

			Console.WriteLine();
			AddCarToPoliceDatabase(factory, new Car
			{
				Number = "CL234IR",
				Owner = "James Doe",
				Company = "BMW",
				Model = "M5",
				Color = "red"
			});

			Console.WriteLine();
			AddCarToPoliceDatabase(factory, new Car
			{
				Number = "CL234IR",
				Owner = "James Doe",
				Company = "BMW",
				Model = "X1",
				Color = "red"
			});

			Console.WriteLine();
			factory.ListFlyweights();
		}

		public static void AddCarToPoliceDatabase(FlyweightFactory factory, Car car)
		{
			Console.WriteLine("Adding a car to database.");
			var flyweight = factory.GetFlyweight(new Car
			{
				Color = car.Color,
				Model = car.Model,
				Company = car.Company
			});

			flyweight.Operation(car);
		}
  }





	public class Flyweight
	{
		private Car sharedState;

		public Flyweight(Car car)
		{
			this.sharedState = car;
		}

		public void Operation(Car uniqueState)
		{
			String s = JsonConvert.SerializeObject(this.sharedState);
			String u = JsonConvert.SerializeObject(uniqueState);
			Console.WriteLine($"Flyweight: Displaying shared {s} \n and unique {u} state.");
		}
	}

	public class FlyweightFactory
	{
		private List<Tuple<Flyweight, String>> flyweights = new List<Tuple<Flyweight, string>>();

		public FlyweightFactory(params Car[] args)
		{
			foreach (var elem in args)
				this.flyweights.Add(new Tuple<Flyweight, String>(new Flyweight(elem), this.GetKey(elem)));
		}

		public String GetKey(Car key)
		{
			List<String> elements = new List<String>();
			elements.Add(key.Model);
			elements.Add(key.Color);
			elements.Add(key.Company);

			if(key.Owner!=null && key.Number!=null)
			{
				elements.Add(key.Number);
				elements.Add(key.Owner);
			}

			elements.Sort();

			return String.Join("_", elements);
		}

		public Flyweight GetFlyweight(Car sharedState)
		{
			String key = this.GetKey(sharedState);
			if(flyweights.Where(t=>t.Item2==key).Count()==0)
			{
				Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
				this.flyweights.Add(new Tuple<Flyweight, String>(new Flyweight(sharedState), key));
			}
			else
				Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
			return this.flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
		}

		public void ListFlyweights()
		{
			var count = flyweights.Count;
			Console.WriteLine($"FlyweightFactory: I have {count} flyweights:");
			foreach(var flyweight in this.flyweights)
				Console.WriteLine(flyweight.Item2);
		}
	}

	public class Car
	{
		public String Owner { get; set; }
		public String Number { get; set; }
		public String Company { get; set; }
		public String Model { get; set; }
		public String Color { get; set; }
	}

}
