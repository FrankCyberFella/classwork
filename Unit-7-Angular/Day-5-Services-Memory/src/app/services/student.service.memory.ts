/***************************************************************
 This is service

 A service is a set of processing to facilitate the retrieval
 and storage of data - typically in a persistent source (saved)

 May do other processing as well

 This service DOES not save the data to a persistent source

 The data from this service is just an array in memory

*******************************************************************/

import { Injectable}   from '@angular/core';              // Access Angular Dependency Injection
import { StudentInfo } from '../interfaces/studentInfo';  // Using the StudentInfo interface

@Injectable({         // This service may be Dependency Injected into any Angular process if needed
  providedIn: 'root'
})
export class StudentService {

 // A module contains data and methods/functions for processing that data
 
   // Source of data for calls to retrieve the data - initialized in the code
   private listOfStudents : StudentInfo[] = []  // An array of StudentInfo objects
 
   // a constructor is method to initialized data defined in the module
   // it is executed automatically when the service is loaded
   // Here we use the constructor to initialize our data source
   constructor() { 
    this.listOfStudents.push({studentNumber: 11,  firstName: "Missy",    lastName : "Michaux", cohort: "AHBC - March 2025", startDate: "2025-03-24"})
    this.listOfStudents.push({studentNumber:  4,  firstName: "India",    lastName : "Doria",   cohort: "AHBC - March 2025", startDate: "2025-03-24"})
    this.listOfStudents.push({studentNumber: 12,  firstName: "Ravyn",    lastName : "Dobine",  cohort: "AHBC - March 2025", startDate: "2025-03-24"})
    this.listOfStudents.push({studentNumber: 56,  firstName: "Preshous", lastName : "Austin",  cohort: "AHBC - March 2025", startDate: "2025-03-24"})
    this.listOfStudents.push({studentNumber: 101, firstName: "Zach",     lastName : "Sanford", cohort: "AHBC - March 2025", startDate: "2025-03-24"})
    this.listOfStudents.push({studentNumber: 3,   firstName: "Marquise", lastName : "Adeleye", cohort: "AHBC - March 2025", startDate: "2025-03-24"})
    this.listOfStudents.push({studentNumber: 56,  firstName: "Kiana",    lastName : "Bauer",   cohort: "AHBC - March 2025", startDate: "2025-03-24"})
    this.listOfStudents.push({studentNumber: 27,  firstName: "Kevin",    lastName : "Gibbs",   cohort: "AHBC - March 2025", startDate: "2025-03-24"})
    this.listOfStudents.push({studentNumber: 21,  firstName: "Amber",    lastName : "Ross",    cohort: "AHBC - March 2025", startDate: "2025-03-24"}) 
   }
 
   // methods others may use to interact with our service
 
   // This method will return the current data in our data source (listOfStudents)
   //  name(parameters) : return-type-of-data-returned
       getStudentList()  : StudentInfo[] {  // this function returns a StudentInfo array
         return this.listOfStudents;
       }
   // This method will receive a StudentInfo object and add it to our data source (listOfStudents)
       addStudent(newStudent : StudentInfo) {      
         console.table(newStudent)            // optional - verify new student data
         this.listOfStudents.push(newStudent) // store the student in the data source
         console.table(this.listOfStudents)   // optional - verify new student was added to the array
       }
}
