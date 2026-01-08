import { Injectable, OnInit } from '@angular/core';
import { HttpClient }         from '@angular/common/http';
import { HttpHeaders }        from '@angular/common/http';
import { lastValueFrom }      from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GamblerApiService  {
  
// The URLl string used whenmaking HTTP calls  
private theServerURL : string = "https://6891e7fa447ff4f11fbe463a.mockapi.io/gamblers"

// Define a data structure tp hold the data from the API call
theGamblers : any[] = []

// Define a constructor inteh service that dependency injects an HttpClient object
// This is where you name the HttpClient for use later (theServer in this example)
constructor(private theServer:HttpClient) {}

// Call API to retrieve all the data items
// async because need to wait for the API send back the data
// Almost all API calls are async becaude we dpn't how long it takes to send the data
// API calls return a Promise so we return a Promise with the data we received
// Promise<data-type-of-date-returned>
async getAllGamblers() : Promise<any[]> {
  // Call the API using the HttpClient object defined in the constructor
  //      and the URL string for the API server path we want
  // await tells the program to wait for the API call to complete
  // lastValueFrom() converts what comes back in the API response to a Promise
  //     containing the data returned by the API server
  // store  the result in a variable defines as the type expected
  //                           (HttpClientPbject.get<expected-return-type>(API server path)) 
  const result : any[] = await lastValueFrom(this.theServer.get<any[]>(this.theServerURL))
  return result;  // return teh result
 }

 // Call API an object to the data items
 // HTTP PPOT to add to the data source
 // a POST and a PUT requires headers telling the server type of data you are sending it
 //                           amd the data to added/updated in the body of the request
async addGambler(newGambler : any) : Promise<any> {      

  // Define headers to send withteh POST telling it what kind of data we are sending
  const headers = new HttpHeaders ({
                                     'Content-Type' : 'application/json'
                                   });
  
  // Since the URL string we defined above has the complete path for a POST
  //      there was no need to add anything to that string 
  //      Sometimes you need to add to the base path defined in the URL string                                
  //                 HttpClientObject.post(API-URL          , data-to-send  , {header-object}).toPromise()                                
  return lastValueFrom(this.theServer.post(this.theServerURL, newGambler    , {headers}));
   }
  

}
