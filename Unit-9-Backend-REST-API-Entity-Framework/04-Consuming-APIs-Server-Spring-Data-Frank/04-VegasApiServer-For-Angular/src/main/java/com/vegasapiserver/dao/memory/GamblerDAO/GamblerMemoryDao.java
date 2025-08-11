package com.vegasapiserver.dao.memory.GamblerDAO;

import com.vegasapiserver.model.Gambler;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.List;

public class GamblerMemoryDao {
    /***********************************************************************
     *  GamblerDAO Starter Code
     *  
     *  DAO - Data Access Object - Used to Manipulate data in a data source
     *
     *  DAOs work with Objects - Receive and return objects
     *                           unless specific search values
     **************************************************************************/

    // Data Source
    private List<Gambler> gamblers;   // Reference to data source

    // Constructor - Initializes the data source
    public GamblerMemoryDao() throws ParseException {
        this.gamblers = new ArrayList<Gambler>(); // Instantiate the data source object

        // Initialize the data source - using constructor and hardcoded data
        gamblers.add(new Gambler(12 , "T Judson Smith" , "Los Angeles, CA", 1398.65,    "05/01/1972", 0L));
        gamblers.add(new Gambler(49 , "Dana Imori"     , ""               , 7580.50,    "08/08/1938", 0L));
        gamblers.add(new Gambler(201, "S.Q. Elle"      , "Relational, DA" , 1000000.01, "05/23/1995", 0L));
        gamblers.add(new Gambler(54 , "Neil Bransfield", "Seattle, WA"    , 5000.00,    "03/11/1959", 0L));
        gamblers.add(new Gambler(382, "Stickman Nelson", "Cumberland, MD" , 12983.75,   "10/21/1955", 0L));
        gamblers.add(new Gambler(572, "Al Mostbroke"   , "Clayton MO"     , 4505.55,    "01/18/1975", 0L));
    }

    // Methods are called by the controller to get data based in the request it receives

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

    // Method to retrieve a gambler whose name contains characters passed
    // It's possible more than 1 Gambler will meet that criteria
    // So be sure you return a set of objects (List, Map, Set, Queue, Stack, et al)
    public List<Gambler> getGamblerByName(String name) {
        // Define the set to hold teh pbjects to be returned
        List<Gambler> theGamblers = new ArrayList<Gambler>();

        // Loop through the data source to find the gambler with the given name
        for (Gambler aGambler : gamblers) {
            // Check if the current gambler's name matches the given name
            // Use equalsIgnoreCase to compare names without case sensitivity
            // Note use of getter for current gambler's name
            if (aGambler.getName().toLowerCase().contains(name.toLowerCase())) {
                theGamblers.add(aGambler); // Add the Gambler that matches the search criteria to the List
            }
        }
        // Once we have search teh entire data source and created the set of objects
        return theGamblers; // Return the set of Gamblers we foudn
    } // End of getGamblerByName() method

    // Add a Gambler to the data source
    //
    // 1. Need to have Gambler to add to the data source - a parameter passed to method
    //         Note: DAOs work with objects NOT individual fields
    // 2. Add  the Gambler to the data source
    // 3. If Gambler is added successfully to data source, return object added
    // 4. If Gambler is NOT added successfully to data source, return null
    public Gambler addGambler(Gambler aGambler) {   // Receive the Gambler to be added as a parameter
        // Use Exception Handling to determine if the object was added
        // If not exception happens it works, if exception happens it didn't
        try {  // Use exception handling for statements in the black
            gamblers.add(aGambler);
        }
        catch (Exception anExceptionBlock) { // if an Exception happens in the try blocl - do this
            return null;  // We return null object if the add didn't work
        }
        return aGambler;  // If not exception occurred - return the object that was added
        }
// if you don't care if it works or not:
//
//      gamblers.add(aGambler);
//      return aGambler;
//
// if you want to use the boolean returned by add instead of Exception Handling:
//
//     if(gamblers.addGambler(aGambler) { // if the .add returned true....
//        return aGambler;                //     return the object added
//     }
//     else {                    // if the .add didn't return true...
//           return null;        //      return null;
//     }

// Update the data source with a Gambler object
//    (We work in objects NOT individual variables)
// We expect an object with the updated data already in it
// (The DAO has not idea how to update individual values in a class
//          The class is responsible for the data in its object)
//
//    1. Need to have Gambler to update in the data source - a parameter passed to method
//         Note: DAOs work with objects NOT individual fields
//    2. Update the Gambler in the data source with the data we are passed
//    3. If Gambler is update successfully to data source, return object update
//    4. If Gambler is NOT updated successfully to data source, return null

    public Gambler updateGambler(Gambler updateGambler) {
    //    1. Since our data source (ArrayList) does not have a method to replace and existing element
    //    2. Remove the existing object
    //       a. Find the existing object - use a unique value (primary key)
    //       b. Remove
    //    3. Add the new object

        // Find the existing Gambler by id by using the existing to do that
        Gambler existingGambler = getGamblerById(updateGambler.getId());

        // Remove the existing Gambler
        gamblers.remove(existingGambler);

        // Add the updated gambler
        gamblers.add(updateGambler);

        return updateGambler;
    }
// Delete from the data source a Gambler object
// Delete is allowed to only receive the primary key of data to be deleted
// Delete expects the primary key of object to be deleted
// Delete usually does not return anything
    public void zapAGambler(int gamblerId) {
        // 1. Find the object in the ArrayList to be deleted
        // 2. Remove the object found
        Gambler existingGambler = getGamblerById(gamblerId);
        gamblers.remove(existingGambler);
    }


}  // end of GamblerMemoryDao class
