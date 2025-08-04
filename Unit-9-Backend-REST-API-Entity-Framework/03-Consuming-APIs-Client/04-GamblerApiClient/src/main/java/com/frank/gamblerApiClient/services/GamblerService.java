package com.frank.gamblerApiClient.services;

import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.web.client.ResourceAccessException;
import org.springframework.web.client.RestClientResponseException;
import org.springframework.web.client.RestTemplate;

import com.frank.gamblerApiClient.models.*;

public class GamblerService {

  private final String BASE_URL;
  private final RestTemplate restTemplate = new RestTemplate();

  public GamblerService() {
    BASE_URL = "http://localhost:8081/";
  }

  /**
   * Retrieve all Gamblers in the data source
   * @return List<Gambler>
   */
  public Gambler[] getAllGamblers() {
      Gambler[] theGamblers = null;
      try {
        theGamblers = restTemplate.getForObject(BASE_URL + "gamblers", Gambler[].class);
      } catch (RestClientResponseException expceptionObj) {
        // handles exceptions thrown by rest template and contains status codes
        System.out.println(expceptionObj.getRawStatusCode() + " : " + expceptionObj.getStatusText());
      } catch (ResourceAccessException exceptionObj) {
        // i/o error, ex: the server isn't running
        System.out.println(exceptionObj.getMessage());
      }
      return theGamblers;
  }

  /**
   * Retrieve a Gambler by id in the data source
   * @return Gambler
   */
  public Gambler getAGambler(int id) {
    Gambler theGambler = null;
    try {
      theGambler = restTemplate.getForObject(BASE_URL + "gamblers/"+id, Gambler.class);
    } catch (RestClientResponseException expceptionObj) {
      // handles exceptions thrown by rest template and contains status codes
      System.out.println(expceptionObj.getRawStatusCode() + " : " + expceptionObj.getStatusText());
    } catch (ResourceAccessException exceptionObj) {
      // i/o error, ex: the server isn't running
      System.out.println(exceptionObj.getMessage());
    }
    return theGambler;
  }

    /**
     * Add the Gambler given to the data source
     * @return Gambler
     */
    public Gambler addAGambler(Gambler gamblerToAdd) {

        if (gamblerToAdd == null) {
            return null;
        }

        Gambler theAddedGambler = null;

        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);
        HttpEntity<Gambler> entity = new HttpEntity<>(gamblerToAdd, headers);

        try {
            theAddedGambler = restTemplate.postForObject(BASE_URL + "gamblers", entity, Gambler.class);
        } catch (RestClientResponseException expceptionObj) {
            // handles exceptions thrown by rest template and contains status codes
            System.out.println(expceptionObj.getRawStatusCode() + " : " + expceptionObj.getStatusText());
        } catch (ResourceAccessException exceptionObj) {
            // i/o error, ex: the server isn't running
            System.out.println(exceptionObj.getMessage());
        }
        return theAddedGambler;
    }

    /**
     * Update the Gambler given to the data source
     * @return Gambler
     */
    public void updateAGambler(Gambler gamblerToUpdate) {

        if (gamblerToUpdate == null) {
            return;
        }

        Gambler theUpdatedGambler = null;

        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);
        HttpEntity<Gambler> entity = new HttpEntity<>(gamblerToUpdate, headers);

        try {
            restTemplate.put(BASE_URL + "gamblers", entity, Gambler.class);
       } catch (RestClientResponseException expceptionObj) {
            // handles exceptions thrown by rest template and contains status codes
            System.out.println(expceptionObj.getRawStatusCode() + " : " + expceptionObj.getStatusText());
        } catch (ResourceAccessException exceptionObj) {
            // i/o error, ex: the server isn't running
            System.out.println(exceptionObj.getMessage());
        }
    }

    /**
     * Delete an existing gambler in tehdata source
     * @param id
     */
    public void deleteAGambler(int id) {
        try {
            restTemplate.delete(BASE_URL + "gamblers/" + id);
        } catch (RestClientResponseException expceptionObj) {
            // handles exceptions thrown by rest template and contains status codes
            System.out.println(expceptionObj.getRawStatusCode() + " : " + expceptionObj.getStatusText());
        } catch (ResourceAccessException exceptionObj) {
            // i/o error, ex: the server isn't running
            System.out.println(exceptionObj.getMessage());
        }
    }

} // End of Gambler service
