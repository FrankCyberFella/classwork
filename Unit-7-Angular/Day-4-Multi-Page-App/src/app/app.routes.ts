import { Routes }               from '@angular/router';  // Give me access to Angular router
import { HomeComponent }        from './components/home/home.component'; // Give me access to the HomeComponent
import { SampleFormComponent }  from './components/sample-form/sample-form.component';
import { StateSealsComponent }  from './components/state-seals/state-seals.component';
import { StudentListComponent } from './components/student-list/student-list.component';

// The Routes object is an array of objects to associate a URL path to a component
//
// Each entry in the array contains the following attributes:
//
//   path - the URL path to be associated with a component
//   component - name of the import for the component associated with the path
//   redirect - optional attribute to redirect a URL path to a different URL
//   pathMatch - indicates if a full match to a URL path is necessary to use the entry
//
// we are defining an object called tehRoute with a data type of Routes
// We tell the router the name of array with the Routes in app.config.ts
export const theRoutes: Routes = [
    {path: '', redirectTo: '/home', pathMatch: 'full' },   // empty path should redirect to /home
    {path: 'home',     component: HomeComponent},          // /home should display the HomeComponent
    {path: 'whatever', component:SampleFormComponent} ,    // /whatever should display the SampleFormComponent
    {path: 'seals', component : StateSealsComponent },     // /seals should display the StateSealsComponent
    {path: 'student-list', component: StudentListComponent}// /student-list should display the StudentListComponent    
];
