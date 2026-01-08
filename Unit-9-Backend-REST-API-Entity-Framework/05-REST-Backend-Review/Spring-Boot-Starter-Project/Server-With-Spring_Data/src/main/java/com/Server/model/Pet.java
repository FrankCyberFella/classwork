package com.Server.model;

import jakarta.persistence.*;

import java.util.Objects;

@Entity              // Tells the data framework this is something it cares about
@Table(name = "pet") // Tells the data framework the table this POJO represents
public class Pet {

    // Data members - one for each column in the table you want to use
    @Id  // Tells the data framework the column follows is the primary key
    @GeneratedValue(strategy = GenerationType.IDENTITY)  // Tell framework the DBMS will create it
    @Column (name="pet_id")  // Column name in the table in the database
    private int    petId;    // Since this is defined as serial in the data base, we need @Generated

    @Column (name="name")
    private String petName;

    @Column (name="pet_type_id")
    private int    petTypeId;

    @Column (name="owner_id")
    private int    ownerId;

    // Constructor(s)

    // Programmer defined default constructor - in case Java/Framework needs it
    public Pet() {};

    // IDE Generated Constructor
    public Pet(int petId, String petName, int petTypeId, int ownerId) {
        this.petId     = petId;
        this.petName   = petName;
        this.petTypeId = petTypeId;
        this.ownerId   = ownerId;
    }

    // Standard named Getters and Setters - IDE Generated Standard Getters/Setters

    public int getPetId() {
        return petId;
    }
    public void setPetId(int petId) {
        this.petId = petId;
    }
    public String getPetName() {
        return petName;
    }
    public void setPetName(String petName) {
        this.petName = petName;
    }
    public int getPetTypeId() {
        return petTypeId;
    }
    public void setPetTypeId(int petTypeId) {
        this.petTypeId = petTypeId;
    }
    public int getOwnerId() {
        return ownerId;
    }
    public void setOwnerId(int ownerId) {
        this.ownerId = ownerId;
    }
    // Programmer may add custom getters/setters if needed

    // toString, equals and hashCode overrides
    // IDE can generate these which you can modify if needed
    @Override
    public String toString() {
        return "Pet{" +
                "petId=" + petId +
                ", petName='" + petName + '\'' +
                ", petTypeId=" + petTypeId +
                ", ownerId=" + ownerId +
                '}';
    }
    @Override
    public boolean equals(Object o) {
        if (o == null || getClass() != o.getClass()) return false;
        Pet pet = (Pet) o;
        return petId == pet.petId && petTypeId == pet.petTypeId && ownerId == pet.ownerId && Objects.equals(petName, pet.petName);
    }
    @Override
    public int hashCode() {
        return Objects.hash(petId, petName, petTypeId, ownerId);
    }

    // Additional methods to support the class

}  // End of Gambler POJO
