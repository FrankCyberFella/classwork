import { Component }     from '@angular/core';
import { MoviesInfo }    from '../../interfaces/moviesInfo';  // include the MoviesInfo interface
import { FormsModule }   from '@angular/forms';
import { MoviesService } from '../../services/movies.service-api';
import { CommonModule }  from '@angular/common';
import { Router }        from '@angular/router';

@Component({
  selector: 'update-movie',
  imports: [CommonModule, FormsModule],
  standalone: true,
  templateUrl: './update-movie-component.html',
  styleUrl:    './update-movie-component.css'
})
export class UpdateMovieComponent {

// NOte Dependency Injection of MoviesService and Route  
constructor(private movieService  : MoviesService, 
            private router        : Router) {}

// Define a place to hold a new movie when entered by the user 
// Data from the web page will be used to fill in the values an updated movie (two-way bind)
// newMovie is initialized with the data passed to it when the router processed this component
//      [state] = {a-movie-object} on the router path to get to this component      
//     variable : data-type - using the interface as a data-type
public newMovie : MoviesInfo =  { 
                                  id: 0,
                                  title : "Type a title",
                                  releaseYear: new Date().getFullYear(), // initialize to this year
                                  director: ""
                                }

  // ngInit() contains processing you want Angular to do BEFORE it runs the constructor                              
  ngOnInit() {
    // This will retrieve any data sent to component through
    //      the [state] variable and initialize the newMovie object to it
    this.newMovie = history.state.theMovie
    // console.log('Received data:', this.newMovie)  //Optional for debugging
  }


// This method method called when the submit is clicked in the html form
// it receives a new movie object with values entered on form from the user
// the it tells the router to go the /movies page
//funcname(parameter : data-type) - using interface as a data-type
  async updateMovie(newMovie  : MoviesInfo) {
    // call the service to add the newMovie to the data source
    await this.movieService.updateMovie(newMovie)

    // Retrieve the current state of the data after the update using the service
    const theData  = await this.movieService.getMoviesList(); // Initialize our moviesList from service

    // Go to the /movies page
    this.router.navigate(['/movies']) // Tell the router to go to the /movies page
  }
  
  cancelButtonClicked() {
    this.router.navigate(['/movies']) // Tell the router to go to the /movies page
  }


}
