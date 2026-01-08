namespace MockAssessment3;

public class Town
{
    // Define data for the class
    // Member data - This class has none - usually private
    // Properties - This class one - usually public

    // Property to hold a List of Villagers
    public List<Villager> Villagers; // reference to a List<Villagers>
                                     // no memory is reserved for the List
                                     // using the List with no memory
                                     //       reserved will cause an Exception
                                     // before it can be used memory must be reserved for the List
                                     //  new List<Villagers> will reserve memory for the List
                                     // You MUST reserve memory for the List either:
                                     //
                                     //   1. When you define the reference
                                     //   2. In the constructor

// If you use this technique, do not reserve memory and assign to reference in the constructor                                    
// public List<Villager> Villagers = new List<Villagers>(); // define reference AND reserve memory                                     

    public Town()
    {
        // Reserve memory for the List and assign it to the reference
        // and add a Farmer and 3 Slackers
        Villagers = new List<Villager> 
        { 
            new Farmer(),
            new Slacker(),
            new Slacker(),
            new Slacker()
        };
        
        /**************************************************************
         * Alternate solutions
         ***************************************************************/
        // Villagers = new List<Villager>();  // Instantiate the List
        
        // Villagers.Add(new Slacker());  // Add a Slacker to the List  
        // Villagers.Add(new Farmer());   // Add a Farmer to the List 
        // Villagers.Add(new Slacker());  // Add a Slacker to the List
        // Villagers.Add(new Slacker());  // Add a Slacker to the List
    }

    public int Harvest()
    {
        // Define a variable to hold the total
        int totalHarvest = 0;

        // Loop through the Villagers List and add up the Farm() values
        // .Count returns the number of items in a List
        for (int i = 0; i < Villagers.Count; i++)
        {
            totalHarvest += Villagers[i].Farm(); // add the Farm() values to total
        }
        // Alternate Solution
        // foreach(int value  : Villagers)
        // {
        //    totalHarvest += value;
        // }

        // Alternate Solution
        // totalHarvest = Villagers.Sum(aValue => aValue.Farm());
        
        return totalHarvest;
    } // End of Harvest()

    public int CalcFoodConsumption()
    {
        int foodConsumed = 0;  // Hold the value we are returning
        
        // Loop through the Villagers List and add up the Hunger values
        // .Count returns the number of items in a List
        for (int i = 0; i < Villagers.Count; i++)
        {
            foodConsumed += Villagers[i].Hunger; // add the Hunger values to total
        }
        return foodConsumed;
    } // End of CalcFoodConsumption

    public bool SurviveTheWinter()
    {
        int food = Harvest(); // Call Harvest and store what it returns
        int foodNeeded = CalcFoodConsumption(); // Call CalcFoodConsumption and store what it returns

        if (foodNeeded <= food)
        {
            return true; // stop and return true
        }

        // We only get here if previous condition was false
        return false;

/********* Alternate Solution *************************
        if (foodNeeded <= food)
        {
            return true;  // stop and return true
        }
        else
        {
            return false;
        }
    }
********************************************************/

//      return (foodNeeded <= food) ? true : false;
//      return (foodNeeded <= food); // Return what the condition returns
//      return CalcFoodConsumption() <= Harvest();  // THIS DOES NOT STORE VALUES

    } // End of SurviveTheWinter()
}  // End of class