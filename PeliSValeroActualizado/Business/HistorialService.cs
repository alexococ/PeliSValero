using Newtonsoft.Json;
using PeliSValero.Data;
using PeliSValero.Models;
using System;
using System.ComponentModel.Design;
using System.Text.Json;



namespace PeliSValero.Business
{
    public class HistorialService
    {


        // metodo para ver el historial de las compras
        public static void VerHistorialDeCompras(Account cuentaExistente)
        {
            foreach (var item in cuentaExistente.historialCuenta)
            {
                Console.WriteLine($"{item.Titular} ha comprado la pelicula: {item.Pelicula}. Tu balance actual es: {item.Cantidad} a dia: {item.Fecha} en {item.Proveedor} ponen tu compra como: {item.Estado}");
            }

        }
    }
}
