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

        for(Gambler aGambler : gamblerService.getAllGamblers() ) {
            aGambler.displayGambler();
        }

        /***************************************************************************
         * Call API to retrieve a gambler by id and display it
         ***************************************************************************/

        System.out.println("-".repeat(70) + "\nCall API to retrieve a gambler by id and display them\n"+"-".repeat(70));

        int gamblerIdWeWant = 201;

        System.out.println("Gambler with id " + gamblerIdWeWant + ":\n");

        gamblerService.getAGambler(gamblerIdWeWant).displayGambler();

        /***************************************************************************
         * Call API to retrieve a gambler by id and display it
         ***************************************************************************/


        /***************************************************************************
         * Call API to add a new gambler then try to retrieve and display it
         * ***************************************************************************/

        System.out.println("-".repeat(70) + "\nCall API to add a new gambler then try to retrieve and display it\n"+"-".repeat(70));

        int idOfNewGambler = 9999;

        gamblerService.deleteAGambler(idOfNewGambler);

        Gambler newGambler = new Gambler(idOfNewGambler, "Frank Fella", "Phoenix, AZ", 1.00, "03/19/1952");

        gamblerService.addAGambler(newGambler);

        gamblerService.getAGambler(newGambler.getId()).displayGambler();

        /***************************************************************************
         * Call API to update an existing gambler then try to retrieve and display it
         * ***************************************************************************/

        System.out.println("-".repeat(70) + "\nCall API to update an existing gambler then try to retrieve and display it\n"+"-".repeat(70));

        int idOfgamblerToUpdate = 9999;

        Gambler gamblerToUpdate = gamblerService.getAGambler(idOfgamblerToUpdate);

        if (gamblerToUpdate != null) {
            System.out.println("Current Data in Gambler with id " + idOfgamblerToUpdate + ":\n");
            gamblerToUpdate.displayGambler();

            gamblerToUpdate.setSalary(5.00);
            gamblerToUpdate.setName("Frank J Fella");

            gamblerService.updateAGambler(gamblerToUpdate);

            System.out.println("Current Data in Gambler with id " + gamblerToUpdate.getId() + ":\n");
            gamblerService.getAGambler(gamblerToUpdate.getId()).displayGambler();

        }
        else {
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


    } // End of main()

}
