import { Routes }               from '@angular/router';
import { HomeComponent }        from './components/home/home.component';
import { StudentListComponent } from './components/student-list/student-list.component';
import { AddStudentComponent }  from './components/add-student/add-student.component';

export const routes: Routes = [
    {path: '', redirectTo: '/home', pathMatch: 'full' }  ,
    {path: 'home',       component: HomeComponent}       ,
    {path: 'students',   component: StudentListComponent} ,
    {path: 'addstudent', component: AddStudentComponent} 
];
