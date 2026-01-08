package com.vegasapiserver.dao.relational;

import com.vegasapiserver.model.Gambler;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface GamblerRepository extends JpaRepository<Gambler, Long> {

    // To Do a case-insensitive LIKE in PostgreSQL - use ILIKE instead of LIKE in the SELECT
    @Query(value = "SELECT * FROM gambler WHERE gambler_name LIKE %:name%", nativeQuery = true)
    List<Gambler> findAllByNameContaining(@Param("name") String name);

}