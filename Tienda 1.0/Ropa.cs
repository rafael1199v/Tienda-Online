public class Ropa : Producto
{
    string marca;
    string talla;
    string color;


    public Ropa()
    {
        this.marca = "Marca Generica";
        this.talla = "Talla M";
        this.color = "Blanco";
    }
    
    public Ropa(string nombre, double precio, int stock, Categoria categoria, string marca, string talla, string color) : base(nombre, precio, stock, categoria)
    {
        this.marca = marca;
        this.talla = talla;
        this.color = color;
    }


    public override string GetDetalleAlgo()
    {

        string RopaDetalle = "";
        RopaDetalle += this.marca + "\n";
        RopaDetalle += this.talla + "\n";
        RopaDetalle += this.color + "\n";

        return RopaDetalle;
    }
}