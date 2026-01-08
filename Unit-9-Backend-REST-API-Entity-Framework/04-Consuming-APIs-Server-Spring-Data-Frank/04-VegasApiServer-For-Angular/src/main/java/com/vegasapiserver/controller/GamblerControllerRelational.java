package com.vegasapiserver.controller;

import com.vegasapiserver.dao.relational.GamblerServiceImplementation;
import com.vegasapiserver.model.Gambler;
import org.springframework.web.bind.annotation.*;

import java.sql.Timestamp;
import java.util.List;
import java.util.Optional;

//CrossOrigin(origins = "*")
@RestController
@RequestMapping("/v2")  // Set a prefix for all paths used in the file
public class GamblerControllerRelational {
    // Define a reference to the Relational Data DAO Implementation
    GamblerServiceImplementation gamblerService;

    // Add the DAO Implementation to the constructor
    // Spring will dependency inject
    // Most IDEs will generate the constuctor correctly
    public GamblerControllerRelational(GamblerServiceImplementation gamblerService) {
        logRequest("Gambler Service Connected");
        this.gamblerService = gamblerService;
    }

    @GetMapping("/gamblers")
    public List<Gambler> getGamblersRelational() {
        logRequest("GET\trequest for /v2/gamblers");
        // Call the DAO methods to perform teh dase base action
        return gamblerService.getAllGamblers();
    }

    @GetMapping("/gamblers/{id}")
    public Optional<Gambler> finaAGambler(@PathVariable Long id) {
        logRequest("GET\trequest for /v2/gamblers/"+id);
        return gamblerService.getGamblerById(id);
    }

    @PostMapping("/gamblers")  // This method will handle a POST request for the URL "/gamblers"
    public Gambler addToDataSource(@RequestBody Gambler newGambler) {
        logRequest("POST\trequest for /v2/gamblers and object: " + newGambler);
        return gamblerService.saveGambler(newGambler);  // Call the DAO method to add the Gambler to the data source
    }

    @PutMapping("/gamblers")
    public Gambler updateAObject(@RequestBody Gambler updatedGambler) {
        logRequest("PUT\trequest for /v2/gamblers and object: " + updatedGambler);
        return gamblerService.saveGambler(updatedGambler);
    }

    @DeleteMapping("/gamblers/{id}")  // Path variable called id in the URL
    public void removeAGambler(@PathVariable Long id) { // parameter name must match the path variable for now
        logRequest("DEL\trequest for /v2/gamblers/" + id);
        gamblerService.deleteGambler(id);  // Call the DAO to delete the object using teh id passed to us
    }

    @GetMapping("/gamblers/search") // This maps the method to the URL path "/gamblers"
    // The @RequestParam annotation tells the server to
    //      extract the value of the query parameter "name"
    // For now, the name of the parameter in the method must match the name of the query parameter
    public List<Gambler> getGamblerByName(@RequestParam String name) {
        logRequest("GET \trequest for /v2/gamblers/search?name="+name);
        // Call the DAO method to get the gambler by name
        //   and return the gambler it gives us
        return gamblerService.findGamblerWithNameContaining(name);
    } // End of getGamblerByName() method

    /**
     * Log timestamp of request and request
     * @param message
     */
    static void logRequest(String message) {
        Timestamp timestamp = new Timestamp(System.currentTimeMillis());

        System.out.println(timestamp + " - " + message);
    }

}
