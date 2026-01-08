package com.frank.gamblerApiClient;

import com.frank.gamblerApiClient.models.Gambler;
import com.frank.gamblerApiClient.services.GamblerService;

public class GamblerApiClientApp {

    public static void main(String[] args) {

        GamblerService gamblerService = new GamblerService();

        /***************************************************************************
         * Call API to retrieve all the gamblers and display them
         ***************************************************************************/

        System.out.println("-".repeat(70) + "\nCall API to retrieve all the gamblers and display them\n"+"-".repeat(70));

        // The application program calls a service method to get the data
        // The application program has no knowledge of teh data source or how to get the data
        // The application should NEVER access the data source directly
        // The application prgram is "loosely-coupled" to the data source the service
        for(Gambler aGambler : gamblerService.getAllGamblers() ) {
            aGambler.displayGambler();
        }

        /***************************************************************************
         * Call API to retrieve a gambler by id and display it
         ***************************************************************************/

        System.out.println("-".repeat(70) + "\nCall API to retrieve a gambler by id and display them\n"+"-".repeat(70));

        int gamblerIdWeWant = 201;

        System.out.println("Gambler with id " + gamblerIdWeWant + ":\n");

        // The appliction program calls a service method to get the data
        gamblerService.getAGambler(gamblerIdWeWant).displayGambler();

        /***************************************************************************
         * Call API to add a new gambler then try to retrieve and display it
         * ***************************************************************************/

        System.out.println("-".repeat(70) + "\nCall API to add a new gambler then try to retrieve and display it\n"+"-".repeat(70));

        int idOfNewGambler = 9999;

        // The application program calls a service method to delete the data if it's there
        gamblerService.deleteAGambler(idOfNewGambler);

        // Create an object with all data for the new object
        Gambler newGambler = new Gambler(idOfNewGambler, "Frank Fella", "Phoenix, AZ", 1.00, "03/19/1952");

        // The application program calls a service method to add the data
        gamblerService.addAGambler(newGambler);

        // Try to retrieve the objected added to data sourse by primary key
        gamblerService.getAGambler(newGambler.getId()).displayGambler();

        /***************************************************************************
         * Call API to update an existing gambler then try to retrieve and display it
         * ***************************************************************************/

        System.out.println("-".repeat(70) + "\nCall API to update an existing gambler then try to retrieve and display it\n"+"-".repeat(70));

        // Determine the primary key of the object you ant to update
        int idOfgamblerToUpdate = 9999;

        // Since we operate with object, not individuals fields in object oriented environment
        // We need to get the existing object from teh data source
        //    and only change the fields in the retrieved object to teh new values
        //    leaving anything we didn't change the way it was
        //
        // It is unusually to changed the pripmary key of an existing object
        //    if the object has deoendencies on the primary key value
        //        those dependencies need to be updated to
        //
        // Changing a primary the value complicates the update process

        // Get the current object for the primary key from teh data source
        Gambler gamblerToUpdate = gamblerService.getAGambler(idOfgamblerToUpdate);

        if (gamblerToUpdate != null) { // if an existing object was found in the data source
            System.out.println("Current Data in Gambler with id " + idOfgamblerToUpdate + ":\n");
            gamblerToUpdate.displayGambler();     // Display the current data values

            gamblerToUpdate.setSalary(5.00);           // Change any existing data you need to change in the object
            gamblerToUpdate.setName("Frank J Fella");  // Change any existing data you need to change in the object

            gamblerService.updateAGambler(gamblerToUpdate); // Call the service method to do the update in the data source

            System.out.println("Current Data in Gambler with id " + gamblerToUpdate.getId() + ":\n");
            gamblerService.getAGambler(gamblerToUpdate.getId()).displayGambler();

        }
        else {  // If existing object with the primary key is not found - process the error
            System.out.println("!".repeat(25) + "Uh-Oh Uh-Oh Uh-Oh" + "!".repeat(25));
            System.out.println("Gambler (id=" + idOfgamblerToUpdate + ") for update not found!");
            System.out.println("!".repeat((25)) + "Uh-Oh Uh-Oh Uh-Oh" + "!".repeat(25));
        }

        /***************************************************************************
         * Call API to delete an existing gambler then try to retrieve and display it
         * ***************************************************************************/

        System.out.println("-".repeat(70) + "\nCall API to delete an existing gambler then try to retrieve and display it\n"+"-".repeat(70));

        int idOfgamblerToDelete = 9999;

        gamblerService.deleteAGambler(idOfgamblerToDelete);

        System.out.println("Delete of Gambler Id '" + idOfgamblerToDelete + "' "
                            + ((gamblerService.getAGambler(idOfgamblerToDelete)) == null ? "successful" : "failed"));

        /***************************************************************************
         * Call API to find existing gamblers whose name contains a search string
         *      and display them
         * ***************************************************************************/

        System.out.println("-".repeat(70) + "\nfind existing gamblers whose name contains a search string\n"+"-".repeat(70));

        String whatWeWant = "man"; // // Determine the search string we are gonna use

        System.out.println("Looking for Gamblers whos name contains '" + whatWeWant +"'");
        Gambler[] foundGamblers = gamblerService.searchAGambler(whatWeWant); // Call the service that will go to the data source with the search string

        // Verify the result by display what was returned
        for(Gambler aGambler : foundGamblers) {
            aGambler.displayGambler();
        }

    } // End of main()
}
