using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using MOAP_Library;

//  implementing inheritance by inheriting interface and abstract classes


public class Colony 
{
    // create objects of 1Bhk and 2Bhk from interface. use school, mall and tech park objects
    public OneBhk SingleHomes { get; set; }
    public TwoBhk FamilyHomes { get; set; }
    public Villa LuxHome { get; set; }
    public School Patel { get; set; }
    public Mall Bharathiya { get; set; }
    public TechPark Manyata { get; set; }
    
    // normal constructor
    public Colony(OneBhk oneBhk, TwoBhk twoBhk, Villa villa, Mall mall)
    {   
    }
    // parameterized constructor
    public Colony(OneBhk oneBhk, TwoBhk twoBhk, Villa villa, Mall mall, TechPark tpark)
    {
        this.SingleHomes = oneBhk;
        this.FamilyHomes = twoBhk;
        this.LuxHome = villa;
        this.Bharathiya = mall;
        this.Manyata = tpark;
    }

   


}

namespace MOAP_Building_Poject
{
    internal class Program
    {
        // Writing the linq query to search school from the three syllabus options
        public static void Search(List<MOAP_Library.School> InstitutionList, string key)
        {
            // linq 
            var SearchKey = from syllabus in InstitutionList
                            where syllabus.Affiliation == key
                            select syllabus;

            // output
            int count = 0;
            Console.WriteLine("The found schools are: ");
            foreach (var item in SearchKey)
            {
                count++;
                Console.WriteLine($"{count}: {item.Affiliation}");
            }
        }
        

        // Writing a function to use Lambda function
        public static void OrderSchool(List<MOAP_Library.School> InstitutionList)
        {
            // order by asc 
            var OrderAsc = InstitutionList.OrderBy(x=> x.Owner).ToList();

            Console.WriteLine("The List is Ordered by Ascending Order ");
            
            int c1 = 0;
            foreach (var item in OrderAsc)
            {
                c1++;
                Console.WriteLine($"{c1}: {item.Owner} "); // {item.ParentConstructor.DevPlace}
            }

            // order by desc
            var OrderDesc = InstitutionList.OrderByDescending(x=> x.Owner).ToList();

            Console.WriteLine("The List is Ordered by Descending Order ");
            int c2 = 0;
            foreach (var item in OrderDesc)
            {
                c2++;
                Console.WriteLine($"{c2}: {item.Owner} "); //and {item.ParentConstructor.DevPlace}
            }
        }


        static void Main(string[] args)
        {
            //MOAP_Library.Developer d1 = new Developer("Godrej", "Bengaluru","560001");
            List<MOAP_Library.Developer> BuilderList = new List<Developer> {
                new Developer("Godrej", "Bengaluru","560001"),
                new Developer("Tata Projects", "Mumbai", "400001"),
                new Developer("Larsen & Toubro", "Mumbai", "400050"),
                new Developer("Lodha Group", "Pune", "411001"),
                new Developer("Reliance Infrastructure", "Delhi", "110001"),
                new Developer("Sadbhav Engineering", "Punjab", "141001"),
                new Developer("Punj Lloyd", "Haryana", "133001"),
            };
            
            //MOAP_Library.Building b1 = new MOAP_Library.School(8000, 4, "St Josephs", 8000, d1,"State");
            List<MOAP_Library.School> InstitutionList = new List<MOAP_Library.School>
            {
                new MOAP_Library.School(8000, 4, "St Josephs", 8000, BuilderList[1], "State"),
                new MOAP_Library.School(6000, 3, "ABC School", 6000, BuilderList[0], "CBSE"),
                new MOAP_Library.School(7000, 5, "XYZ School", 7000, BuilderList[1], "ICSE"),
                new MOAP_Library.School(5000, 5, "Maple High School", 5000, BuilderList[0], "CBSE"),
                new MOAP_Library.School(9000, 6, "Greenfield Academy", 9000, BuilderList[3], "ICSE"),
                new MOAP_Library.School(7500, 4, "Sunshine Public School", 7500, BuilderList[2], "State"),
                new MOAP_Library.School(5500, 3, "Rosewood International", 5500, BuilderList[3], "CBSE"),
                new MOAP_Library.School(6800, 5, "Oakridge High", 6800, BuilderList[4], "ICSE"),
                new MOAP_Library.School(7200, 4, "Blossom School", 7200, BuilderList[5], "State"),
                new MOAP_Library.School(6200, 3, "Sunflower Academy", 6200, BuilderList[6], "CBSE"),
                new MOAP_Library.School(8000, 5, "Lotus High School", 8000, BuilderList[3], "ICSE"),
                new MOAP_Library.School(6700, 4, "Rainbow Public School", 6700, BuilderList[5], "State"),
                
            };
            InstitutionList[0].Lighting();
            InstitutionList[0].Pool();
            InstitutionList[0].TotalCost();

            // now add , lambda, linq,  
            string key1 = "State";
            string key2 = "ICSE";
            string key3 = "CBSE";
            Search(InstitutionList, key1);
            Search(InstitutionList, key2);
            Search(InstitutionList, key3);

            // exception example with building class
            MOAP_Library.Developer d1 = new Developer("Godrej", "Bengaluru","560001");
            //Building b1 = new School(3000, 2, "St Josephs", 3000, d1, "State");

            // function to implement lambda function
            // Orders by asc and desc and stores in a list
            OrderSchool(InstitutionList);

            // Creating the Colony objects 
            Developer godrej = new Developer("Godrej", "Bengaluru", "560001");
            OneBhk studioApart = new OneBhk();
            TwoBhk famApart = new TwoBhk();
            Villa luxHome = new Villa();
            Mall BharathiyaMall = new Mall(9000, 7,"Shetty's", 8000, godrej, 12);
            TechPark Manyata = new TechPark(8000, 4, "Garuda", 5000, godrej, 7);
            Colony FrenchColony = new Colony(studioApart, famApart, luxHome, BharathiyaMall, Manyata);

            Console.ReadKey();
        }
    }
}
