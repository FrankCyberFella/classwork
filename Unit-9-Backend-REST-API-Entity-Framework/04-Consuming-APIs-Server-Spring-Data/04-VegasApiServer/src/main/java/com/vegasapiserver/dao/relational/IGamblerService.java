package com.vegasapiserver.dao.relational;

import com.vegasapiserver.model.Gambler;

import java.util.List;
import java.util.Optional;

public interface IGamblerService {

    Gambler           saveGambler(Gambler gambler);

    Optional<Gambler> getGamblerById(Long id);

    List<Gambler>     getAllGamblers();

    void              deleteGambler(Long id);

    List<Gambler>     findGamblerWithNameContaining(String name);
}

