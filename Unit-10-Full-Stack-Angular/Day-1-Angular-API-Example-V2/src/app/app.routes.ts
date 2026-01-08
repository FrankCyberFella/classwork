import { Routes }               from '@angular/router';
import { HomeComponent }        from './components/home/home.component';
import { MovieListComponent }   from './components/movie-list/movie-list.component';
import { AddMovieComponent }    from './components/add-movie/add-movie.component';
import { UpdateMovieComponent } from './components/update-movie-component/update-movie-component';

export const routes: Routes = [
    {path: '', redirectTo: '/home', pathMatch: 'full' }  ,
    {path: 'home'       ,   component: HomeComponent}       ,
    {path: 'movies'     ,   component: MovieListComponent} ,
    {path: 'addmovie'   ,   component: AddMovieComponent}, 
    {path: 'updateMovie',   component: UpdateMovieComponent}
];
