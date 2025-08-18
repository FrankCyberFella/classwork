// This was generate using ng g s services/gamblerApiService command

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { GamblerDataLayout } from '../interfaces/GamblerDataLayout';

@Injectable({
  providedIn: 'root'
})
export class GamblerApiService {

  // Define the connection string for the server aka Base Path
  // Used to make HTTP Requests for the server
  private theServerURL : string = "https://6891e7fa447ff4f11fbe463a.mockapi.io/gamblers"


  theGamblers : any[] = []

  // Have an HttpClient object dependency injected into the programs
  // We're calling the HttpClient theGamblerApiServer
  constructor(private theGamblerApiServer:HttpClient) {}

  // Define a method make an Http GET request to the API server
  // It needs to be async because we want to wait until we return from the API Server
  //    before continue (All APIi calls are async - We don'y know how long to get back)
  // It returns a Promise<data-type> so we know when the API call returns
  // The data type is the type of data returned from the API call
  async getAllTheGambler() : Promise<any[]> { 
   
    // Call the API server to with an HTTP GET
    //      and store the data returned in the variable result
    // Since we expect the possibilty of more than one entry to be returned,
    //       store the returned data in an array
    //                                          server-name define in ctor.get<type-of-data-returned>(serverUrl)
    // The API to get all gamblers is: GET /gamblers
    // Since /gambles is already theServerURL string we don't have to add it
    const theAPIGamblers : any[] =  await lastValueFrom(this.theGamblerApiServer.get<any[]>(this.theServerURL))
  
    this.theGamblers = theAPIGamblers;
    // Return theGamblers
    return this.theGamblers; 
  }

  // This will add an object to the API using
  async addGamblerToApi(newGambler : GamblerDataLayout) : Promise<any> {

    // Define headers for POST request
    const headers = new HttpHeaders ({
                                      'Content-Type' : 'application/json'
                                     });

   // Call the API with an HTTP POST
    await lastValueFrom(this.theGamblerApiServer.post(this.theServerURL, newGambler
                 ,{headers}))
  }

}
