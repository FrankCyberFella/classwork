// typescript file goes here
console.log("Welcome to My First TypeScript Program");
// Define a class that will hold and process all the students
}()); // End of class Roster
/**************************************************************************
 * Code the use our Roster class
 *************************************************************************/
var classRoster = new Roster(); // Define a new Roster
// Add some students to the roster
classRoster.addStudent({ studentName: "Frank", className: "Angular", startDate: 20250623 });
classRoster.addStudent({ studentName: "Zach", className: "Angular", startDate: 20250623 });
classRoster.addStudent({ studentName: "India", className: "Angular", startDate: 20250623 });
classRoster.addStudent({ studentName: "Kiana", className: "Angular", startDate: 20250623 });
classRoster.addStudent({ studentName: "Youssef", className: "of his own", startDate: 20260623 });
var aStudent = { studentName: "Jay", className: "Advanaced Angular", startDate: 20250723 };
classRoster.addStudent(aStudent);
// Display all the students in our roster
// Loop through the roster and display students one at a time
// Get the roster as an array and use the array forEach to iterate through it
classRoster.getAllTheStudents().forEach(function (aStudent) { console.log(aStudent); });
