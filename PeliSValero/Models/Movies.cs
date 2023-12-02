namespace PeliSValero.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? Gender { get; set; }
        public string? Director { get; set;}
        public decimal Price { get; set; }
        public bool InStock { get; set; }

        public List<Movie> Peliculas {get; set;}

        public Movie(string title, string gender, decimal price, string director)
        {
            Title = title;
            Gender = gender;
            Price = price;
            Director = director;
        }


    }


}