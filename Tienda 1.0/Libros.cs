
public class Libro : Producto
{
    string autor;
    string genero;
    string fecha_publicacion;


    public Libro()
    {
        this.genero = "Manual";
        this.autor = "Autor genérico";
        this.fecha_publicacion = "01-01-2000";
    }
    
    public Libro(string nombre, double precio, int stock, Categoria categoria, string autor, string genero, string fecha_publicacion) : base(nombre, precio, stock, categoria)
    { 
        this.autor = autor;
        this.genero = genero;
        this.fecha_publicacion = fecha_publicacion;
    }


    public override string GetDetalleProductos()
    {

        string libroDetalle = "";
        libroDetalle += this.autor + "\n";
        libroDetalle += this.genero + "\n";
        libroDetalle += this.fecha_publicacion + "\n";

        return libroDetalle;
    }
}