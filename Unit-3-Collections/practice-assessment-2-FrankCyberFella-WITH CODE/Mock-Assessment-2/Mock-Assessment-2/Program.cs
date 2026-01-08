using Microsoft.VisualBasic.CompilerServices;

namespace Mock_Assessment_2;

class Program
{
    /**************************************************************************************************
     * Assessment #2 Methods
     * Testing for methods follow the last method
     **************************************************************************************************/
    
    //-------------------------------------------------------------------------------------------------  
    // 1. Create a static method named AddStarWarsCharacters()
    //    that takes in a string[].
    //    This method then searches for and returns the index of “Yoda”.
    //    If “Yoda” is not in the array, return -1.
    //-------------------------------------------------------------------------------------------------  
    static int AddStarWarsCharacters(string[] starWarsCharacters)
    {
        for (int i = 0; i < starWarsCharacters.Length; i++)
        {
            if (starWarsCharacters[i] == "Yoda")
            {
                return i;
            } 
        }
        return -1;
    }
    //-------------------------------------------------------------------------------------------------  
    // 2. Create a static method named DeathStarCombat()
    //    that takes in a Dictionary<string,int> of Star Wars characters (key)
    //    and their attack values (value)
    //    This method should return the name of the Jedi with the highest Attack value.
    //-------------------------------------------------------------------------------------------------  
    static string DeathStarCombat(Dictionary<string, int> jediDictionary)
    {
        string strongestJedi = "";
        int    strongestValue = -1;

        foreach (KeyValuePair<string, int> aJedi in jediDictionary)
        {
            if(aJedi.Value > strongestValue)
            {
                strongestJedi  = aJedi.Key;
                strongestValue = aJedi.Value;
            }
        }
        return strongestJedi;
    }  // End of DeathStarCombat
    
    //-------------------------------------------------------------------------------------------------  
    // 3. Create a static method named ConvertPlanets() takes in one parameter: an array of planet names
    //    The method will convert the array of planets into a list of planets in the reverse order.
    //    Return the List.
    //-------------------------------------------------------------------------------------------------  
    
    // ------ Solution 1 - Use Collections class methods 
    static List<string> ConvertPlanets(string[] arrayOfPlanets)
    {
        // Define a List to hold return value  
        List<string> listOfPlanets = new List<string>();

        listOfPlanets = arrayOfPlanets.ToList();  // Convert array to List
        listOfPlanets.Reverse();                  // Reverse the elements in the List

        return listOfPlanets;  // Return final result
    }  // End of ConvertPlanets() Solution 1

    // ------ Solution 2 - process array backwards from end to start
        static List<string> ConvertPlanets2(string[] arrayOfPlanets) {
        
        // Define a List to hold return value    
        List<string> listOfPlanets = new List<string>();
        
        // Set i to last valid index and decrement i each time through the loop
        for (int i = arrayOfPlanets.Length - 1; i >= 0; i--)
        {
            listOfPlanets.Add(arrayOfPlanets[i]);  // Add current element to List
        }
        
        return listOfPlanets ; // Return List with final resuly
    } // `// End of ConvertPlanets() Solution 1
    
    //-------------------------------------------------------------------------------------------------   
    // 4. Create a static method named AverageDroids() takes in an integer List for droids
    //    The method will search through the list and calculate the average of all even-numbered droids. 
    //    Return the average.
    //-------------------------------------------------------------------------------------------------  

    static double AverageDroids(List<int> droids)
    {
       double evenAverage = 0;
       double    evenSum = 0;
       
       List<int> evenNumbers = new List<int>();

        foreach (int aNumber in droids)
        {
            if (aNumber % 2 == 0)
            {
                evenSum = evenSum + aNumber;    
                evenNumbers.Add(aNumber);
            }
        }
        evenAverage = evenSum / evenNumbers.Count;
        return evenAverage;
    }
    
    // Alternate Solution
    static double AverageDroids2(List<int> droids)
    {
        List<int> evenDroidScores = droids.Where(droidScore => droidScore % 2 == 0).ToList();
        return evenDroidScores.Average();
    }
    
    // Alternate Solution
    static double AverageDroids3(List<int> droids)
    {
        return droids.Where(droidScore => droidScore % 2 == 0).ToList().Average();
    }
    
    // 5. Create a static method named TryToCatchDarthVader().
    //    This method will take in a string as a parameter and parse that string as an integer.
    //    return “Vader Was Captured!” If the parse is successful.
    //    return “Vader Got Away!”. If FormatException is thrown.
    //    Hint: Use A Try-Catch.

    static string TryToCatchDarthVader(string darthVader)
    {
        try
        {
            Int32.Parse(darthVader);
        }
        catch (FormatException exceptionObject)
        {
            return "Vader Got Away!";
        }

        return "Vader Was Captured";
    }  // End of TryToCatchDarthVader()
    
    /**************************************************************************************************
     * Tests for Assessment #2 Methods
     **************************************************************************************************/
    
    static void Main(string[] args)
    {
    Console.WriteLine("\nStart of Mock Assessment #2 Method Tests");

    //-------------------------------------------------------------------------------------------------   
    Console.WriteLine("\n----------------------------------------------------------------------------------------");
    Console.WriteLine("1. Look for index of Yoda in an array containing Yoda\n");
    
    string[] starWarsCharactersArray  = {"Luke", "Leia", "Darth", "Yoda", "Obiwan", "JarJar"};
    string[] starWarsCharactersNoYoda = {"Luke", "Leia", "Darth", "Obiwan", "JarJar"};
    
    int yodaIndex = AddStarWarsCharacters(starWarsCharactersArray);
    Console.WriteLine($"Index of Yoda in array with Yoda: {yodaIndex} - expecting 3");
    
    yodaIndex = AddStarWarsCharacters(starWarsCharactersNoYoda);
    Console.WriteLine($"Index of Yoda in array without Yoda: {yodaIndex} - expecting -1");
    
    //-------------------------------------------------------------------------------------------------    
    Console.WriteLine("\n----------------------------------------------------------------------------------------");
    Console.WriteLine("2. Create a static method named DeathStarCombat()");
    Console.WriteLine("   that takes in a Dictionary<string,int> of Star Wars characters (key)");
    Console.WriteLine("   and their attack values (value)");
    Console.WriteLine("   This method should return the name of the Jedi with the highest Attack value.\n");
    
    Dictionary<string, int> jediDictionary = new Dictionary<string, int>();
    jediDictionary.Add("Luke"  , 700);
    jediDictionary.Add("Leia"  , 700);
    jediDictionary.Add("Darth" , 900);
    jediDictionary.Add("Obiwan", 1000);
    jediDictionary.Add("JarJar", 2);    
    
    string strongestJedi = DeathStarCombat(jediDictionary);
    Console.WriteLine($"The stongest Jedi is {strongestJedi} with an attack value of {jediDictionary[strongestJedi]}");
    Console.WriteLine("Expecting 'Obiwan' with attack value of 1000");

    //-------------------------------------------------------------------------------------------------  
    Console.WriteLine("\n----------------------------------------------------------------------------------------");
    Console.WriteLine("3. Create a static method named ConvertPlanets() ");
    Console.WriteLine("   that takes in one parameter: an array of planet names");
    Console.WriteLine("   The method will convert the array of planets into a list of planets in the reverse order.");
    Console.WriteLine("   Return the List.");
    //------------------------------------------------------------------------------------------------- 

    string[] planets = {"Mercury", "Venus", "Earth", "Mars", "Jupiter", "Neptune", "Uranus", "Pluto"};

    Console.WriteLine("\n----- Testing Solution 1 -----"); 
    Console.WriteLine("\nPlanets in reverse order (expecting Pluto first and Mercury last:");
    foreach (string planet in ConvertPlanets(planets))
    {
        Console.Write(planet + " ");   
    }
    Console.WriteLine("\n\n----- Testing Solution 2 -----"); 
    Console.WriteLine("\nPlanets in reverse order (expecting Pluto first and Mercury last:");
    foreach (string planet in ConvertPlanets2(planets))
    {
        Console.Write(planet + " ");   
    }
    
    //-------------------------------------------------------------------------------------------------  
    Console.WriteLine("\n----------------------------------------------------------------------------------------");
    Console.WriteLine("4. Create a static method named AverageDroids() takes in an integer List for droids");
    Console.WriteLine("   The method will search through the list and calculate the average of all even-numbered droids.");
    Console.WriteLine("   Return the average.");
    Console.WriteLine("   Hint: Create another list to store the even numbers in.");
    //-------------------------------------------------------------------------------------------------  
    double evenAverage = AverageDroids(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
    Console.WriteLine($"\nUsing Solution 1 - Average for even numbers is {evenAverage} - expecting 6");
    
    double evenAverage2 = AverageDroids2(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
    Console.WriteLine($"Using Solution 2 - Average for even numbers is {evenAverage2} - expecting 6");
    
    double evenAverage3 = AverageDroids(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
    Console.WriteLine($"Using Solution 3 - Average for even numbers is {evenAverage3} - expecting 6");
    
    Console.WriteLine("\n----------------------------------------------------------------------------------------");
    Console.WriteLine(" 5. Create a static method named TryToCatchDarthVader().");
    Console.WriteLine("    This method will take in a string as a parameter and parse that string as an integer.");
    Console.WriteLine("    return “Vader Was Captured!” If the parse is successful.");
    Console.WriteLine("    return “Vader Got Away!”. If FormatException is thrown.");
    Console.WriteLine("    Hint: Use A Try-Catch.\n");

    Console.WriteLine("Trying to catch Vader with invalid int string (expecting Got Away!): " + TryToCatchDarthVader("R2D2"));
    Console.WriteLine("Trying to catch Vader with invalid int string (expecting Got Away!): " + TryToCatchDarthVader("3.2"));
    Console.WriteLine("Trying to catch Vader with valid int string (expecting CapturedNo!):   " + TryToCatchDarthVader("1"));

    Console.WriteLine("\nEnd of Mock Assessment #2 Method Tests");
    
    } // End of Main()
    
} // End of class Program