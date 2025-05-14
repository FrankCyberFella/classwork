namespace SampleOOPApplication;

class Program
{
    // Application program will define and mainpulate objects
    static void Main(string[] args)
    {
        Console.WriteLine("------ Start of Sample Object Oriented Application Made From Scratch -------");
        
        Person aPerson = new Person("John", 78, 250.6, 69, "Male");
        Console.WriteLine($"aPerson:  {aPerson}");  // .WriteLine() uses the ToString() of the class
        
        Person aPerson2 = new Person("John", 78, 250.6, 69, "Male");
        Console.WriteLine($"aPerson2: {aPerson2}");  // .WriteLine() uses the ToString() of the class
        
        // Compare aPerson and aPerson2 to see if they are equal
        // if (aPerson == aPerson2)   // == compares the reference value (locations in memory)
        if (aPerson.Equals(aPerson2)) // .Equals() SHOULD compare the content of the object
        {
            Console.WriteLine("They are equal");
        }
        else
        {
            Console.WriteLine("They are NOT equal");
        }
        
        Console.WriteLine("------ End of Sample Object Oriented Application Made From Scratch -------");
    } // End of Main()
}