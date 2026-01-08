import Pet.Pet;  // Give use access to teh Pet class stuff

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        System.out.println("Welcome to Pet Management");

        // Instantiate a Pet
        Pet cat1 = new Pet("James", "Cat", 'M', 30, true);

        cat1.displayPet();

        // Instantiate a Pet from User input - Java use Scanner for keyboard input
        // Scanner is a class to scan data and break it into variables
        // System.in is a Java defined object to represent the keyboard
        Scanner theKeyboard = new Scanner(System.in);  // Create a Scanner for the keyboard

        System.out.println("\nWhat is the name of your pet?");
        String thePetName = theKeyboard.nextLine(); // nextLine() gets the a line from the keyboard

        System.out.println("\nWhat is the type of your pet?");
        String thePetType = theKeyboard.nextLine(); // nextLine() gets the a line from the keyboard

        System.out.println("\nWhat is the gender of your pet?");
        String thePetGender = theKeyboard.nextLine(); // nextLine() gets the a line from the keyboard

        System.out.println("\nWhat is the weight of your pet?");
        String thePetWeight = theKeyboard.nextLine(); // nextLine() gets the a line from the keyboard

        System.out.println("\nIs your pet spayed?");
        String thePetSpay = theKeyboard.nextLine(); // nextLine() gets the a line from the keyboard

        // Instantiate a pet from user input
        // Convert the data required that is not a String to the right type

        char petGender = thePetGender.charAt(0);        // Take the first char of the String
        int petWeight = Integer.parseInt(thePetWeight); // Convert the weight for String to int

        boolean petSpayed = false;  // Assume pet is not spayed
        if (thePetSpay.equals("Y")) { // if it is spayed...
            petSpayed = true;         //    set the variable to true
        }
        Pet pet1 = new Pet(thePetName, thePetType, petGender, petWeight, petSpayed);
        pet1.displayPet();

    } // End of main()
} // End of Main() class