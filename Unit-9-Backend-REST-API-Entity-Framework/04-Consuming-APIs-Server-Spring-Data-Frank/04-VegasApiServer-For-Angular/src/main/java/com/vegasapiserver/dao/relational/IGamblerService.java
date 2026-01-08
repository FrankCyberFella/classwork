package com.vegasapiserver.dao.relational;

import com.vegasapiserver.model.Gambler;

import java.util.List;
import java.util.Optional;

/*****************************************************************
 * An Interface specifies methods that must be implemented by
 * any class that implements the interface
 *
 * List of available processing through the interafce
 *
 * Should have CRUD methods
 ******************************************************************/
public interface IGamblerService {

    // Create and Update method
    // We are working with objects and update replacing an existing object
    Gambler           saveGambler(Gambler gambler);
    // Read method
    // Optional allows teh isPresent() method to be used by data Framework
    //     to determine if null
    Optional<Gambler> getGamblerById(Long id);
    // Read method
    List<Gambler>     getAllGamblers();
    // Delete
    void              deleteGambler(Long id);
    // Read method
    List<Gambler>     findGamblerWithNameContaining(String name);
}

