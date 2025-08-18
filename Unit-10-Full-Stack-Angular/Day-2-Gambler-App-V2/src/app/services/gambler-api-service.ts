import { Injectable, OnInit } from '@angular/core';
import { HttpClient }         from '@angular/common/http';
import { HttpHeaders }        from '@angular/common/http';
import { lastValueFrom }      from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GamblerApiService  {
  
private theServerURL : string = "https://6891e7fa447ff4f11fbe463a.mockapi.io/gamblers"

theGamblers : any[] = []

constructor(private theServer:HttpClient) {}

// Call API to retrieve all the data items
async getAllGamblers() : Promise<any[]> {
  const result : any[] = await lastValueFrom(this.theServer.get<any[]>(this.theServerURL))
  return result;
 }

 // Call API an object to the data items
async addGambler(newGambler : any) : Promise<any> {      

  const headers = new HttpHeaders ({
                                     'Content-Type' : 'application/json'
                                   });
                                       
  //                             use .post(API-URL          , data-to-send, {header-object}).toPromise()                                
  return lastValueFrom(this.theServer.post(this.theServerURL, newGambler    , {headers}));
   }
  

}
