package com.vegasapiserver.dao.relational;

import com.vegasapiserver.model.Gambler;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

/************************************************************************
 * The Repository gains you access to the Data Framework methods
 * in JpaRepository class (Java Persistence Api)
 *
 * You send the JpaRepository the class of the object to be accessed
 *                            and the data type of primary key
 *
 * If you requirements beyond the basic CRUD processing
 * you can code the SQL to be run in the repository:
 *
 *    Code @Query with the custom SQL to be run when the method is called
 *    before the method signature
 *
 *    If data in the custom SQL, code name of data with : in front of it
 *    and use an @Param in the parameter part of the signature
 *
 *    It's a good idea to test the custom SQL in a Query processor
 *    to be sure it is correct and produces the expected resuly
 *
 ************************************************************************/
public interface GamblerRepository extends JpaRepository<Gambler, Long> {

    // the :name in the SQL represents the data passed to the method
    // it is specified in the @Param of the method parameter list
    // To Do a case-insensitive LIKE in PostgreSQL - use ILIKE instead of LIKE in the SELECT
    @Query(value = "SELECT * FROM gambler WHERE gambler_name LIKE %:name%", nativeQuery = true)
    List<Gambler> findAllByNameContaining(@Param("name") String name);

}