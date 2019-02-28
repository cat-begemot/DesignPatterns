using System;

namespace Prototype
{
  class Program
  {
    static void Main(string[] args)
    {
			Person p1 = new Person();
			p1.Age = 42;
			p1.BirthDate = Convert.ToDateTime("1987-05-07");
			p1.Name = "Cat";
			p1.IdInfo = new IdInfo(312373);

			Person p2 = p1.ShallowCopy();
			Person p3 = p1.DeepCopy();
			Console.WriteLine("Original values of p1, p2, p3:");
			PrintPersons(p1, p2, p3);

			p1.Age = 32;
			p1.BirthDate = Convert.ToDateTime("1990-02-12");
			p1.Name = "Kitty";
			p1.IdInfo.IdNumber = 12345;
			Console.WriteLine("Values of p1, p2, p3 after changes to p1:");
			PrintPersons(p1, p2, p3);
		}

		public static void PrintPersons(Person p1, Person p2, Person p3)
		{
			Console.Write("\t p1 instance values: ");
			Console.WriteLine(p1.ToString());
			Console.Write("\t p2 instance values: ");
			Console.WriteLine(p2.ToString());
			Console.Write("\t p3 instance values: ");
			Console.WriteLine(p3.ToString());
		}
  }

	public class Person
	{
		public Int32 Age;
		public DateTime BirthDate;
		public String Name;
		public IdInfo IdInfo;

		public Person ShallowCopy()
		{
			return (Person)this.MemberwiseClone();
		}

		public Person DeepCopy()
		{
			Person clone = (Person)this.MemberwiseClone();
			clone.IdInfo = new IdInfo(IdInfo.IdNumber);
			clone.Name = String.Copy(Name);
			return clone;
		}

		public override String ToString()
		{
			return $"Name: {this.Name:s}, Age: {this.Age:d}," +
				$"BirthDate: {this.BirthDate:dd.mm.yy}, ID#: {this.IdInfo.IdNumber:d}";
		}
	}

	public class IdInfo
	{
		public Int32 IdNumber;

		public IdInfo(Int32 idNumber)
		{
			this.IdNumber = idNumber;
		}
	}
}
