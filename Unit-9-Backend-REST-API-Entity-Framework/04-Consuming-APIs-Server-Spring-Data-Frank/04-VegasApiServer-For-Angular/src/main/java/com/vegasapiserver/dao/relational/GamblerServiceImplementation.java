package com.vegasapiserver.dao.relational;

import com.vegasapiserver.model.Gambler;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service  // Tells Spring that this service (which means Spring knows how to use)
// Note: implements the interface
public class GamblerServiceImplementation implements IGamblerService {

    // Define a reference to the repository so you can access framework methods
    private final GamblerRepository gamblerRepository;

    @Autowired  // Tells Spring to Dependency Inject the implementation when used
    // The repository is dependency injected into the constructor by Spring
    // (we don't have to code = new GamblerRepository to get an instance of it)
    public GamblerServiceImplementation(GamblerRepository gamblerRepository) {
        this.gamblerRepository = gamblerRepository;
    }

    // @Transaction helps the data base handle concurrent updates/adds/deletes to the database
    //         by doing a commit after the method rund
    //         good to use on any method that changes the data base
    //
    // If a methods only reads from the data base add (readOnly = true)
    //       to provide some efficiency in data base access

    @Override
    @Transactional  // Helps the data base handle concurrent updates/adds to teh database
     public Gambler saveGambler(Gambler gambler) {
        // Return what the repository sends back
        return gamblerRepository.save(gambler);
     }

    @Override
    @Transactional (readOnly = true)
    public Optional<Gambler> getGamblerById(Long id) {
        return gamblerRepository.findById(id);
    }

    @Override
    @Transactional (readOnly = true)
    public List<Gambler> getAllGamblers() {
        return gamblerRepository.findAll();
    }

    @Override
    @Transactional
    public void deleteGambler(Long id) {
        gamblerRepository.deleteById(id);
    }

    @Override
    @Transactional (readOnly = true)
    public List<Gambler> findGamblerWithNameContaining(String name) {
        // Calling the custome SQL method defined in the repository
        return gamblerRepository.findAllByNameContaining(name);
    }
}
