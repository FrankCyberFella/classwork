import { CommonModule }   from '@angular/common';
import { Component }      from '@angular/core';
import { StudentInfo }    from '../../interfaces/studentInfo';          // Give me access to StudentInfo interface
import { StudentService } from '../../services/student.service.memory'; // Give me access to the student.service.memory stuff
import { RouterLink } from '@angular/router';

@Component({
  selector: 'student-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './student-list.component.html',
  styleUrl: './student-list.component.css'
})
export class StudentListComponent {
// This will hold the data for the Student to be displayed
// the data will come from a call to a service
// it starts out as an empty array  
//     var-name   : data-type
public studentList : StudentInfo [] ; // This is an array of StudentInfo objects

// Since we need the data in the initial display of the component
//       use the constructor() to get the data when the page is loaded
//
// constructor is used to initialize data in the component
//
// This style of constructor will define the variable, create a StudentService object
//                                       and assign that object to the variable
//                                       using Dependency Injection
//
// Dependency Injection is the automatic creation of variables and objects required
//
// Dependency Injection decouples the service from the code
// (makes it much easier to change the service)
//   
// without Dependency Injection the code would look like this:
//
//     private studentService;   // define a variable to hold the service
//
//     constructor() {
//                    studentService = new StudentService();// create the service
//                   }                                      //    and assign it to the variable
//
// Since the StudentService is Dependency Injectable we don't have to instantiate it
// Angular will automatically instantiate a copy for use and pass it to the constructor
//         when you code an object of the service type as a parameter                              
constructor(private studentService  : StudentService ) {

  // Call the service method to send back the current list of Student from the data source
  this.studentList = studentService.getStudentList(); // Initialize our StudentList from service
  //  1. studentService.getStudentList() - go to the StudentService and run the method getStudentList
  //  2. = - take with the method returns and assign it to (store it in)
  //  3. this.studentList is assigned the data from step 1

} // End of constructor

}  // End of export