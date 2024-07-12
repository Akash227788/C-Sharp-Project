using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOAP_Library
{
    // Inheritance has-a rel object Parent construction company for the property
    public class Developer
    {
        public string DevName { get; set; }
        public string DevPlace { get; set; }
        public string Pincode { get; set; }
        public Developer(string name, string place, string pincode)
        {
            this.DevName = name;
            this.DevPlace = place;
            this.Pincode = pincode;
        }
    }

    public abstract class Building
    {
        // data members
        public double CostPerSqft { get; set; }
        public int Floor { get; set; }
        public string Owner { get; set; }
        public int Size { get; set; }

        // adding the object dev name
        public Developer ParentConstructor { get; set; }


        // constructors
        public Building()
        {

        }

        public Building(int cost, int floor, string owner, int size, Developer BuildingParent)
        {
            this.CostPerSqft = cost;
            this.Floor = floor;
            this.Owner = owner;
            this.Size = size;
        }

        // abstract member functions
        public abstract void Pool();
        public abstract void TotalCost();
        public abstract void Lighting();


    }

    // School child class using Building abstract class
    public class School : Building
    {
        // data members
        public string Affiliation { get; set; }

        

        public School(int cost, int floor, string owner, int size, Developer BuildingParent, string affiliate) : base(cost, floor, owner, size, BuildingParent)
        {
            // Implementing exceptions here
            if (CostPerSqft < 5000) // cost should not be less than 10k
            {
                throw new ArithmeticException("Please give valid Cost");
            }
            if (Floor < 3) // min 3 floors for a School
            {
                throw new ArithmeticException("Please enter more than 3 floor");
            }
            if (Owner == null)
            {
                throw new ArgumentException("Please give a valid Owner Name");
            }
            if (Size < 5000) // Throw exception if size is less than 5000 sqft
            {
                throw new ArithmeticException("Please give valid Cost");
            }
            this.Affiliation = affiliate;
        }


        public override void Pool()
        {
            // 1 pool per 1000sqft for schools
            int noOfPools = Size / 1000;
            System.Console.WriteLine($"There are {noOfPools} pools in {Owner} School");
        }

        public override void Lighting()
        {
            // 5 per 1000 sqft
            int totLight = Size / 200;
            System.Console.WriteLine($"Total Lights required is: {totLight}");
        }

        public override void TotalCost()
        {
            double totCost = Size * CostPerSqft;
            System.Console.WriteLine($"Cost for the construction of {Owner} is: {totCost}");
        }
    }

    // Mall child class using Building abstract class
    public class Mall : Building
    {
        public int Brands { get; set; }

        // Throw exception if size is less than 8000 sqft

        public Mall(int cost, int floor, string owner, int size, Developer BuildingParent, int brands) : base(cost, floor, owner, size, BuildingParent)
        {
            this.Brands = brands;
        }


        public override void Pool()
        {
            // 1 pool per 2000sqft for Malls
            int noOfPools = Size / 2000;
            System.Console.WriteLine($"There are {noOfPools} in {Owner} Mall");
        }

        public override void Lighting()
        {
            // 10 per 1000 sqft
            int totLight = Size / 100;
            System.Console.WriteLine($"Total Lights required is: {totLight}");
        }

        public override void TotalCost()
        {
            // Multiplier for Mall as cost is more
            double totCost = Size * CostPerSqft + (CostPerSqft * Size * 0.2);
            System.Console.WriteLine($"Cost for the construction of {Owner} is: {totCost}");
        }
    }

    // TechPark child class using Building abstract class

    public class TechPark : Building
    {
        public int Companies { get; set; }

        // Throw exception if size is less than 20000 sqft

        public TechPark(int cost, int floor, string owner, int size, Developer BuildingParent, int companies) : base(cost, floor, owner, size, BuildingParent)
        {
            this.Companies = companies;
        }


        public override void Pool()
        {
            // 1 pool per 4000sqft for Tech Parks
            int noOfPools = Size / 4000;
            System.Console.WriteLine($"There are {noOfPools} in {Owner} Mall");
        }

        public override void Lighting()
        {
            // 5 per 1000 sqft
            int totLight = Size / 200;
            System.Console.WriteLine($"Total Lights required is: {totLight}");
        }

        public override void TotalCost()
        {
            // Multiplier for Tech park as cost is more and sez reduction
            double totCost = Size * CostPerSqft + (CostPerSqft * Size * 0.7) - (Size * 200);
            System.Console.WriteLine($"Cost for the construction of {Owner} is: {totCost}");
        }
    }

    public class Villa: Building
    {
        public override void Pool()
        {
            Console.WriteLine("Villa has pool");
        }

        public override void Lighting()
        {
            Console.WriteLine("Villa has pool");
        }

        public override void TotalCost()
        {
            Console.WriteLine("Villa has pool");
        }
    }

    // interface example for Building idea
    // interface ideas -> 1bhk, kitchen, 

    // Interface 
    public interface IResidential_Essentials
    {
        // interface method declarations
        void Kitchen();
        void Restroom();
        void Bedroom();
    }



    // interface implementations
    // 1BHK house
    public class OneBhk : IResidential_Essentials
    {
        public void Kitchen()
        {
            System.Console.WriteLine("One Kitchen");
        }
        public void Restroom()
        {
            System.Console.WriteLine("One Restroom");
        }
        public void Bedroom()
        {
            System.Console.WriteLine("One Master Bedroom");
        }
    }

    // 2 BHK house
    public class TwoBhk : IResidential_Essentials
    {
        public void Kitchen()
        {
            System.Console.WriteLine("Two Kitchen");
        }
        public void Restroom()
        {
            System.Console.WriteLine("Two Restroom");
        }
        public void Bedroom()
        {
            System.Console.WriteLine("Two Master Bedroom");
        }
    }


}
