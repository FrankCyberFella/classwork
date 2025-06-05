// Every class in Java is part of a package
// First thing your do to create a new class is create a new package
//       then create the class inside the package
package Pet;

import java.util.Objects;

/*******************************************************************************************
 * This class will represent Pet information for a pet
 *
 * Data: Name of the Pet
 *       Type of Pet (Dog, Cat, Gerbil, Lizard, Bird etc)
 *       Gender
 *       Weight (lbs)
 *       Is it spayed or neutered?
 *
 * Behavior (methods):
 *
 *   1. You should always have at least one constructor to initialize the class
 *         a default ctor (in case Java needs it; Java uses the default ctor
 *                                                behind the scenes if needed)
 *         a least one ctor that takes arguments used to initialize the object
 *
 *    2. Getters and Setters to allow controlled access to private data members (Encapsulation)
 *
 *    3. Object method overrides to get the behavior you want from the methods:
 *
 *        toString() - Represent the class data as a String rather than show location@Package.Class
 *        equals()   - To determine if two objects of the class are equal based on their content
 *                                  rather than based on their location in memory
 *        hashCode() - To generate a hash code based on the content of the object not
 *                                  it's location in memory
 *                     The same data members used in equals should be used hashCode() so
 *                     objects that are equal have equal hash code.
 *
 *     4. Additional methods to support the class (e.g. display method)
 *
 *     A class that has data and method in items 1 thru 3 is known as a POJO
 *     (Plain Old Java Object)
 *
 **********************************************************************************************/
public class Pet {
    /******************************************************************
     * Member Data - should be always private to support Encapsulation
     *****************************************************************/
    private String  petName;
    private String  petType;
    private char    petGender;
    private int     petWeight;
    private boolean isSpayed;  // boolean variable are usually started with "is"

    /**********************************************************************
     * Constructors - initialize objects instantiated for a class
     **********************************************************************/

    // Default ctor - define an empty object (we don't know default pet info)
    public Pet() {}   // ctor that takes no arguments and doesn't do anything

    // Ctor that initializes using arguments passed to the constructor
    public Pet(String petName, String petType, char petGender, int petWeight, boolean isSpayed) {
        // Why is this. used in these statements?
        // Because the parameters names are the same as the data member names (common)
        //      this. is used to reference the data member and NOT the parameters

        this.petName   = petName;  // Copy the petName   parameter to the petName data member
        this.petType   = petType;  // Copy the petType   parameter to the petType data member
        this.petGender = petGender;// Copy the petGender parameter to the petGender data member
        this.petWeight = petWeight;// Copy the petWeight parameter to the petWeight data member
        this.isSpayed  = isSpayed; // Copy the isSpayed  parameter to the isSpayed data member
    }

    /*************************************************************************************
     * Standard getters and setters to allow controlled access to private  data members
     *
     * Standard names: getters - getVariableName    setters: setVariableName
     *                  boolean: isVariableName
     ************************************************************************************/
    public String getPetName() {
        return petName;
    }
    public void setPetName(String petName) {
        this.petName = petName;
    }
    public String getPetType() {
        return petType;
    }
    public void setPetType(String petType) {
        this.petType = petType;
    }
    public char getPetGender() {
        return petGender;
    }
    public void setPetGender(char petGender) {
        this.petGender = petGender;
    }
    public int getPetWeight() {
        return petWeight;
    }
    public void setPetWeight(int petWeight) {
        this.petWeight = petWeight;
    }
    public boolean isSpayed() {
        return isSpayed;
    }
    public void setSpayed(boolean spayed) {
        isSpayed = spayed;
    }

    /*************************************************************************************
     * Object method overrides
     *
     *        toString() - Represent the class data as a String rather than show location@Package.Class
     *        equals()   - To determine if two objects of the class are equal based on their content
     *                                  rather than based on their location in memory
     *        hashCode() - To generate a hash code based on the content of the object not
     *                                  it's location in memory
     *                     The same data members used in equals should be used hashCode() so
     *                     objects that are equal have equal hash code.
     ************************************************************************************/

    @Override  // Optional - Asks the compiler to check to be sure this is valid override
    public String toString() {
        return "Pet{" +
                "petName='" + petName + '\'' +
                ", petType='" + petType + '\'' +
                ", petGender=" + petGender +
                ", petWeight=" + petWeight +
                ", isSpayed=" + isSpayed +
                '}';
    }
    @Override
    // equals receives a generic Object - NOT an object of the class
    // We have to check or cast the generic object to an object of the class
    // Usage: aPet.equals(anotherPet)  - in the method aPet is assumed and o represents the other pet
    public boolean equals(Object o) {
        // an object called pet is instantiated as part of if
        // (o instanceof Pet pet) - the Pet pet instantiates a Pet object called pet
        if (!(o instanceof Pet pet)) return false;
        return getPetGender() == pet.getPetGender()   // Compare the object to left of .equals to object inside the ()
            && getPetWeight() == pet.getPetWeight()
            && isSpayed() == pet.isSpayed()
            && Objects.equals(getPetName(), pet.getPetName())
            && Objects.equals(getPetType(), pet.getPetType());
    }

    @Override
    public int hashCode() {  // Uses the built-in hash() method to generate a hash code using all data members
        return Objects.hash(getPetName(), getPetType(), getPetGender(), getPetWeight(), isSpayed());
    }

    /**************************************************************************************************************
     * Additional methods to support the class
     **************************************************************************************************************/
    public void displayPet() {
        System.out.println(this);  // Display the object used to invoke the method (implied use the toString())
    }

}  // End of Pet Class