using System.Diagnostics.Contracts;

public class Factura
{
    protected int nit;
    protected string? nombre;
    protected string detalle;


    public Factura(int nit, string? nombre, string detalle)
    {
        this.nit = nit;
        this.nombre = nombre;
        this.detalle = detalle;
    }



}