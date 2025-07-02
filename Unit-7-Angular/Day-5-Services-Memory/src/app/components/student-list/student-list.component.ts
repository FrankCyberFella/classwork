import { CommonModule }   from '@angular/common';
import { Component }      from '@angular/core';
import { StudentInfo }    from '../../interfaces/studentInfo';
import { StudentService } from '../../services/student.service.memory';
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
constructor(private studentService  : StudentService ) {
  // Call the service method to send back the current list of Student from the data source
  this.studentList = studentService.getStudentList(); // Initialize our StudentList from service
  //  1. studentService.getStudentList() - go to the Studentervice and run the method getStudentList
  //  2. = - take with the method returns and assign it to (store it in)
} //  3. this.studentList is assigned the data from step 2

}  // End of export