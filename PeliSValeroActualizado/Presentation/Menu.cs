
using System;
using PeliSValero.Business;
using PeliSValero.Data;

using System;
using System.Reflection.Metadata;
using PeliSValero.Models;

namespace PeliSValero.Presentation
{
    class Menu
    {

        private bool iniciarSession = true;




        /* ZONA DE MENU PUBLICO A TODOS LOS USUARIOS */
        public void MostrarMenuPrincipal()
        {

            List<Account> usuariosCreados = new List<Account>();

            while (true)
            {
                Mostramenu1();

                int? opcion;
                if (int.TryParse(Console.ReadLine(), out int resultado))
                {
                    opcion = resultado;
                }
                else
                {
                    Console.WriteLine("Entrada no válida, por favor, ingrese un número");
                    continue;

                }

                switch (opcion)
                {
                    case 1:
                        Account usuarioNuevo = AccountService.CrearCuenta();
                        usuariosCreados.Add(usuarioNuevo);
                        AccountService.UserData(usuariosCreados);
                        break;

                    case 2:
                        Account cuentaExistente = AccountService.UsuarioExistente(usuariosCreados);
                        usuariosCreados.Add(cuentaExistente);

                        bool isCuentaExistente = AccountService.isCuentaValida(usuariosCreados, cuentaExistente);
                        if (isCuentaExistente)
                        {
                            iniciarSession = true;
                            while (iniciarSession)
                            {
                                MostrarMenuCuenta(cuentaExistente, usuariosCreados);
                            }
                        }
                        break;
                    case 3:
                        MovieService.MostrarPeliculas();
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo");
                        break;
                }

            }
        }

        /* ZONA DE MENU PRIVADO DENTRO DE LA CUENTA */

        public void MostrarMenuCuenta(Account cuentaExistente, List<Account> usuariosCreados)
        {
            Mostramenu2(cuentaExistente);
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AccountService.ModificarDatosCuenta(cuentaExistente);
                    AccountService.UserData(usuariosCreados);
                    break;
                case "2":
                    // metodo para alquilar una pelicula
                    MovieService.ComprarPeliculas(cuentaExistente, usuariosCreados);
                    break;
                case "3":
                    // metodo para mostrar todas las peliculas
                    MovieService.MostrarPeliculas();
                    break;
                case "4":
                    // metodo para ver el historial de compras
                    HistorialService.VerHistorialDeCompras(cuentaExistente);
                    break;
                case "5":
                    iniciarSession = false;
                    break;
                case "6":
                    // metodo para salir del programa
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo");
                    break;
            }
        }

        private static void Mostramenu1()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("==     BIENVENIDO A PeliSValero      ==");
            Console.WriteLine("==  SELECCIONE UNA DE LAS OPCIONES ==  ");
            Console.WriteLine("=======================================");

            Console.WriteLine("1. Crear una cuenta");
            Console.WriteLine("2. Entrar a una cuenta");
            Console.WriteLine("3. Ver todas las películas");
            Console.WriteLine("4. Salir del programa");

            Console.WriteLine("=======================================");
        }

        private static void Mostramenu2(Account cuentaExistente)
        {
            Console.WriteLine("=======================================");
            Console.WriteLine($"BIENVENIDO: {cuentaExistente.Username}");
            Console.WriteLine("==  SELECCIONE UNA DE LAS OPCIONES   ==");
            Console.WriteLine("=======================================");

            Console.WriteLine("1. Cambiar datos de la cuenta");
            Console.WriteLine("2. Alquilar una película");
            Console.WriteLine("3. Ver todas las películas");
            Console.WriteLine("4. Ver historial de compras");
            Console.WriteLine("5. Salir de la cuenta");
            Console.WriteLine("6. Salir del programa");

            Console.WriteLine("=======================================");
        }

    }
}