package com.gamblerapi.dao.GamblerDAO;

import com.gamblerapi.model.Gambler;

import java.util.ArrayList;
import java.util.List;

public class GamblerMemoryDao {
    /***********************************************************************
     *  GamblerDAO Starter Code
     *  
     *  DAO - Data Access Object - Used to Manipulate data in a data source
     **************************************************************************/

    // Data Source
    private List<Gambler> gamblers;   // Reference to data source

    // Constructor - Initializes the data source
    public GamblerMemoryDao()
    {
        this.gamblers = new ArrayList<Gambler>(); // Instantiate the data source object

        // Initialize the data source - using constructor and hardcoded data
        gamblers.add(new Gambler(12 , "T Judson Smith" , "Los Angeles, CA", 1398.65,    "05/01/1972"));
        gamblers.add(new Gambler(49 , "Dana Imori"     , ""               , 7580.50,    "08/08/1938"));
        gamblers.add(new Gambler(201, "S.Q. Elle"      , "Relational, DA" , 1000000.01, "05/23/1995"));
        gamblers.add(new Gambler(54 , "Neil Bransfield", "Seattle, WA"    , 5000.00,    "03/11/1959"));
        gamblers.add(new Gambler(382, "Stickman Nelson", "Cumberland, MD" , 12983.75,   "10/21/1955"));
        gamblers.add(new Gambler(572, "Al Mostbroke"   , "Clayton MO"     , 4505.55,    "01/18/1975"));
    }

    // Method to return all entries in the data source
    public List<Gambler> getGamblers()
    {
        return gamblers;
    } // End of getGamblers() method

    // Method to return a gambler by ID
    // The first thing you need is a method signature for the method
    // A method signature:
    // access  return-type method-name(parameters)
    public Gambler getGamblerById(int id)
    {
        // Loop through the data source to find the gambler with the given ID
        // Use a for-each loop to iterate through the list of gamblers
        // for(type-and-name-for-element : data-structure) { ... }
           for(Gambler aGambler : gamblers) {
            // Check if the current gambler's ID matches the given ID
            if (aGambler.getId() == id) {
                return aGambler; // Return the gambler if found
            }
        }
        // Return null if no gambler with the given ID is found
        return null;
    } // End of getGamblerById() method

    // Method to retrieve a gambler by name
    public Gambler getGamblerByName(String name) {
        // Loop through the data source to find the gambler with the given name
        for (Gambler aGambler : gamblers) {
            // Check if the current gambler's name matches the given name
            // Use equalsIgnoreCase to compare names without case sensitivity
            // Note use of getter for current gambler's name
            if (aGambler.getName().equalsIgnoreCase(name)) {
                return aGambler; // Return the gambler if found
            }
        }
        // Return null if no gambler with the given name is found
        return null;
    } // End of getGamblerByName() method

}  // end of GamblerMemoryDao class
