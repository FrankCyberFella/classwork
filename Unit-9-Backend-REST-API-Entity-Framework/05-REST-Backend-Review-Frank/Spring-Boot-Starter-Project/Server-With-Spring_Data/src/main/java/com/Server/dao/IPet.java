package com.Server.dao;

import com.Server.model.Pet;
import java.util.List;
import java.util.Optional;

public interface IPet {
    // Provide method signatures for operations that can be performed on the data
    // Should provide at least minimum CRUD support
    // The actual code to perform the processing is in th implementation file

    // Get all entries for data source    - return multiple objects - receive nothing
    public List<Pet> getAllPets();

    // Get an entry by primary key        - return one object - receive a primary key value
    public Optional<Pet> returnPet(int pkey);

    // Add an entry to data source        - return the entry added (REST protocol) - receive an object
    public Pet addPet(Pet aPet);

    // Update an entry in the data source - return the entry updated (REST protocol) - receive an object
    public Pet updatePet(Pet aPet);

    // Delete an entry by primary key     - return nothing (REST protocol) - receive a primary key
    public void deletePet(int priKey);

} // End if iPet interface
