import { Component }     from '@angular/core';
import { StudentInfo }   from '../../interfaces/studentInfo';  // include the StudentInfo interface
import { FormsModule }   from '@angular/forms';
import { CommonModule }  from '@angular/common';
import { Router }        from '@angular/router';
import { StudentService } from '../../services/student.service.memory';

@Component({
  selector: 'add-student',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-student.component.html',
  styleUrl:    './add-student.component.css'
})
export class AddStudentComponent {
// Uses Dependency Injection to define the variable Studentervice,
//        create an instanceof StudentService and assign that to the Studentervice
// also Dependency Injects the Router into the router variable (so we can go to different pages)
constructor(private studentService  : StudentService, 
            private router          : Router) {}

// Define a place to hold a new student when entered by the user 
// Data from the web page will be used to fill in the values a new student (two-way bind)
//     variable : data-type - using the interface as a data-type
public newStudent : StudentInfo =  {
                               // initialize studentNumber to value between 1000 and 9999
                                  studentNumber : Math.floor(Math.random() * (9999 - 1000 + 1)) + 1000,
                                  firstName     : "Enter First Name",
                                  lastName      : "Enter Last Name",
                                  cohort        : "Enter Cohort",
                                  startDate     : "Please select Start Date"
                                };

// This method method called when the submit is clicked in the html form
// it receives a new student object with values entered on form from the user
// the it tells the router to go the /students page
//funcname(parameter : data-type) - using interface as a data-type
  addStudent(newStudent  : StudentInfo) {
    console.table(newStudent);
    this.studentService.addStudent(newStudent) // call the service to add the newStudent to th data source
    this.router.navigate(['/students']) // Tell the router to go to the /students page
  }
  cancelButtonClicked() {
    this.router.navigate(['/students']) // Tell the router to go to the /Student page
  }
}
