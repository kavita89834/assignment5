using System;
using System.Collections.Generic;

class Movie
{
    public string Title { get; set; }
    public int Year { get; set; }
}

class MovieDatabase
{
    private List<Movie> movies;

    public MovieDatabase()
    {
        movies = new List<Movie>
        {
            new Movie { Title = "HUM", Year = 2010 },
            new Movie { Title = "The Men", Year = 1994 },
            new Movie { Title = "The World", Year = 1996 },
        };
    }

    public List<Movie> GetAllMovies()
    {
        return movies;
    }

    public Movie GetMovieByTitle(string title)
    {
        return movies.Find(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }
}

class Program
{
    static void Main()
    {
        MovieDatabase movieDatabase = new MovieDatabase();

        // GET: Retrieve a list of all movies
        List<Movie> allMovies = movieDatabase.GetAllMovies();
        Console.WriteLine("All Movies:");
        foreach (Movie movie in allMovies)
        {
            Console.WriteLine($"{movie.Title} ({movie.Year})");
        }

        // GET (by title): Retrieve a specific movie by its title
        string searchTitle = "HUM";
        Movie specificMovie = movieDatabase.GetMovieByTitle(searchTitle);
        if (specificMovie != null)
        {
            Console.WriteLine($"\nMovie found by title '{searchTitle}': {specificMovie.Title} ({specificMovie.Year})");
        }
        else
        {
            Console.WriteLine($"\nMovie with title '{searchTitle}' not found.");
        }
    }
}