using Newtonsoft.Json;
using PeliSValero.Data;
using PeliSValero.Models;
using System;
using System.ComponentModel.Design;
using System.Text.Json;



namespace PeliSValero.Business
{

    public class MovieService
    {


        // metodo para mostrar toda la lista de películas
        public static void MostrarPeliculas()
        {
            string nombre = @"../Data/DataMovies.json";

            if (File.Exists(nombre))
            {
                string jsonString = File.ReadAllText(nombre);

                List<Movie> peliculas = JsonConvert.DeserializeObject<List<Movie>>(jsonString);

                // Recorrer la lista e imprimir los valores
                foreach (var pelicula in peliculas)
                {
                    Console.WriteLine($"Nombre: {pelicula.Title}, Precio: {pelicula.Price}");
                }
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
        }


        // ruta del archivo de películas(DataMovies.json)
        private const string NombreJson = "../Data/DataMovies.json";


        // metodo para comprar las peliculas
        public static void ComprarPeliculas(Account cuentaExistente, List<Account> usuariosCreados)
        {
            Console.WriteLine("Ingrese el nombre de una película existente:");
            string nombrePelicula = Console.ReadLine();

            List<Movie> listaPeliculas = PeliculasJson();

            Movie peliculaSeleccionada = BuscarPeliculaPorNombre(nombrePelicula, listaPeliculas);

            if (peliculaSeleccionada != null && peliculaSeleccionada.InStock)
            {
                Console.WriteLine($"¿Estás seguro que quieres comprar la película '{peliculaSeleccionada.Title}'? (Si/No)");
                string respuesta = Console.ReadLine();

                if (respuesta.Equals("Si", StringComparison.OrdinalIgnoreCase))
                {
                    if (cuentaExistente.Balance >= peliculaSeleccionada.Price)
                    {
                        cuentaExistente.Balance -= peliculaSeleccionada.Price;
                        Console.WriteLine($"Has comprado la película '{peliculaSeleccionada.Title}'.");
                        Console.WriteLine($"La pelicula ha costado: '{peliculaSeleccionada.Price}'€.");
                        Console.WriteLine($"Tienes un balance de:: '{cuentaExistente.Balance}'€.");
                        AccountService.UserData(usuariosCreados);
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente para comprar la película.");
                    }
                }
                else if (respuesta.Equals("No", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Has decidido no comprar la película.");
                }
                else
                {
                    Console.WriteLine("Solo puedes introducir Si o No. Volviendo al menú.");
                }
            }
            else
            {
                Console.WriteLine("La película no existe o no está disponible en stock. Volviendo al menú.");
            }


        }


        // metodo para obtener las películas
        private static List<Movie> PeliculasJson()
        {
            try
            {
                string json = File.ReadAllText(NombreJson);
                return JsonConvert.DeserializeObject<List<Movie>>(json) ?? new List<Movie>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo de películas: {ex.Message}");
                return new List<Movie>();
            }
        }


        // metodo para buscar las peliculas por el nombre
        private static Movie BuscarPeliculaPorNombre(string nombre, List<Movie> listaPeliculas)
        {
            return listaPeliculas.Find(EncuentraPeliculaPorNombre);

            bool EncuentraPeliculaPorNombre(Movie pelicula)
            {
                return pelicula.Title.Equals(nombre, StringComparison.OrdinalIgnoreCase);
            }
        }






        // metodo para ver el historial de las compras
        public static void VerHistorialDeCompras(Account cuentaExistente)
        {

        }



    }










}