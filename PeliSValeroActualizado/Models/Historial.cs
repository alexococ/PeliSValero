namespace PeliSValero.Models;

public class Historial
{
    public decimal Cantidad { get; set; }
    public DateTime Fecha { get; set; }
    public string Pelicula { get; set; }
    public string Titular { get; set; }

    public string Proveedor { get; set; }

    public string Estado {get; set;}
    public Historial()
    {

    }

    public Historial(decimal cantidad, DateTime fecha, string pelicula, string titular, string proveedor, string estado)
    {
        Cantidad = cantidad;
        Fecha = fecha;
        Pelicula = pelicula;
        Titular = titular;
        Proveedor = proveedor;
        Estado = estado;
    }
}