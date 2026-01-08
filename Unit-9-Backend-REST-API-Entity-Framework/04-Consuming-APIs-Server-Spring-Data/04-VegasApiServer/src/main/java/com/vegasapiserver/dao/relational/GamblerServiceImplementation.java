package com.vegasapiserver.dao.relational;

import com.vegasapiserver.model.Gambler;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class GamblerServiceImplementation implements IGamblerService {

    private final GamblerRepository gamblerRepository;

    @Autowired
    public GamblerServiceImplementation(GamblerRepository gamblerRepository) {
        this.gamblerRepository = gamblerRepository;
    }
    
    @Override
    @Transactional
     public Gambler saveGambler(Gambler gambler) {
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
        return gamblerRepository.findAllByNameContaining(name);
    }
}
