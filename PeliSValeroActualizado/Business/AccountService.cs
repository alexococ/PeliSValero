using Newtonsoft.Json;
using PeliSValero.Data;
using PeliSValero.Models;
using System;
using System.ComponentModel.Design;
using System.Text.Json;



namespace PeliSValero.Business
{
    public class AccountService
    {


        /* -------------- METODOS PARA LA ZONA PÚBLICA (TODOS LOS USUARIOS) -----------*/


        // crear cuenta
        public static Account CrearCuenta()
        {

            Console.WriteLine("Ingrese el Username:");
            string username = Console.ReadLine();


            Console.WriteLine("Ingresa tu Nombre");
            string firstName = Console.ReadLine();

            for (int i = 0; i < firstName.Length; i++)
            {
                if (char.IsDigit(firstName[i]))
                {
                    throw new ArgumentException("formato incorrecto del nombre: no puede contener numeros");
                }
            }

            Console.WriteLine("Ingresa tu apellido");
            string lastName = Console.ReadLine();

            for (int i = 0; i < lastName.Length; i++)
            {
                if (char.IsDigit(lastName[i]))
                {
                    throw new ArgumentException("formato incorrecto del apellido: no puede contener numeros");
                }
            }

            Console.WriteLine("Ingresa tu DNI");
            string nif = Console.ReadLine();
            if (nif.Length != 9)
            {
                throw new ArgumentException("formato incorrecto de DNI: tiene que tener una longitud de 9");
            }

            for (int i = 0; i < 8; i++)
            {
                if (!char.IsDigit(nif[i]))
                {
                    throw new ArgumentException("formato incorrecto del DNI: tiene que ser 8 numeros");
                }
            }

            if (!char.IsLetter(nif[8]))
            {
                throw new ArgumentException("formato incorrecto del DNI: tiene que tener una letra al final");
            }

            Console.WriteLine("Ingresa un capital inicial");

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(nif))
            {
                throw new ArgumentException("Ninguno de los campos puede ser nulo o contener solo caracteres vacios");
            }


            Account account = new Account();

            if (decimal.TryParse(Console.ReadLine(), out decimal balance))
            {
                List<string> peliculasCompradas = new List<string>();
                List<Historial> historialCuenta = new List<Historial>();

                account = new Account()
                {
                    Username = username,
                    FirstName = firstName,
                    LastName = lastName,
                    NIF = nif,
                    Balance = balance,
                    peliculasCompradas = peliculasCompradas.Append("Se ha creado la cuenta").ToList(),
                    historialCuenta = historialCuenta

                };

                Console.WriteLine("Cuenta creada con éxito.");

            }
            else
            {
                Console.WriteLine("Entrada inválida para el capital. Inténtalo de nuevo.");
            }

            return account;
        }

        // ingresar datos en DataUsers.json
        public static void UserData(List<Account> usuariosCreados)
        {
            string nombre = @"../Data/DataUsers.json";
            var option = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = System.Text.Json.JsonSerializer.Serialize(usuariosCreados, option);
            File.WriteAllText(nombre, jsonString);
        }



        // entrar en una cuenta
        public static bool isCuentaValida(List<Account> usuariosCreados, Account cuentaExistente)
        {

            foreach (Account usuario in usuariosCreados)
            {
                if (usuario.NIF.Equals(cuentaExistente.NIF))
                {
                    return true;
                }
            }
            Console.WriteLine("¡Contraseña incorrecta!");
            return false;
        }



        // metodo para utilizar el usuario
        public static Account UsuarioExistente(List<Account> usuariosCreados)
        {
            Console.WriteLine("Ingresa DNI (contraseña):");
            string dniIngresado = Console.ReadLine();

            foreach (Account cuenta in usuariosCreados)
            {
                if (cuenta.NIF == dniIngresado)
                {
                    Console.WriteLine("¡DNI (contraseña) correcto!");
                    usuariosCreados.Remove(cuenta);
                    return new Account
                    {
                        FirstName = cuenta.FirstName,
                        LastName = cuenta.LastName,
                        NIF = cuenta.NIF,
                        Username = cuenta.Username,
                        Balance = cuenta.Balance,
                    };
                }
            }

            Console.WriteLine("¡DNI (contraseña) incorrecto!");
            return null; // Retorna null si no se encuentra la cuenta
        }








        /* -------------- METODOS PARA LA ZONA PRIVADA (DENTRO DE UNA CUENTA) -----------*/

        // metodo para modificar datos del usuario
        public static void ModificarDatosCuenta(Account cuentaExistente)
        {

            // cambiar username
            Console.WriteLine("Ingrese el nuevo Username:");
            string username = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("El campo no puede ser nulo o contener solo caracteres vacios");
            }
            cuentaExistente.Username = username;



            // cambiar nombre
            Console.WriteLine("Ingrese el nuevo Nombre:");
            string firstName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("El campo no puede ser nulo o contener solo caracteres vacios");
            }
            cuentaExistente.FirstName = firstName;




            // cambiar apellido
            Console.WriteLine("Ingrese el nuevo Apellido:");
            string lastName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("El campo no puede ser nulo o contener solo caracteres vacios");
            }
            cuentaExistente.LastName = lastName;
        }




    }
}
