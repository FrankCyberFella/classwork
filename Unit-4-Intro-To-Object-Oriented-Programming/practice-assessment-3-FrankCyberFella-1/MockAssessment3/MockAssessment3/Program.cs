namespace MockAssessment3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Mock Assessment #3");
        // Testing your classes means instantiate objects with various values
        // Use the methods with those object to verify result is what is expected
        //
        // To create a Test:
        //
        // 1. Instantiate an object (or objects) with values you select
        // 2. Choose a method to test
        // 3. Determine the expected result from the method using object defined
        
        // Create a Town object
        // (Town will create Villagers and Slackers so we don't have to create them)

        Town aTown = new Town();
        // We have Town with 1 Farmer and 3 Slackers
        // The Farmer's Hunger property will return a 1
        //              Farm() method   will return a 2
        
        // We want to test SurviveTheWinter() of Town
        // We need to know the relationship of total of Hunger values to Farm()
        
        // Each Slacker's Hunger property will return 3
        //                Farm   method   will return 0
        
        // Since a Town has 1 Farmer and 3 Slackers
        // The total of all Hunger properties should be 10 (1 * 1) + (3 * 3)
        // The total of all Farm return values should be 2 (1 * 2) + (3 * 0)
        
        // We expect that SurviveTheWinter() will return: false
        
        Console.WriteLine("Expecting false");
        Console.WriteLine($"Will we survive the winter? {aTown.SurviveTheWinter()}");
      



    } // End of Main()
}