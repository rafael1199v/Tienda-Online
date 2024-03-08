
using System.Reflection.Metadata.Ecma335;

public class Producto
{
    public String nombre;
    protected double precio;
    protected int stock;
    protected Categoria categoria;

    
    public Producto(){

        this.nombre = "Generico";
        this.precio = 0;
        this.stock = 0;
        this.categoria = new Categoria();
    }

    public Producto(string nombre, double precio, int stock, Categoria categoria){
        Validador(nombre, precio, stock, categoria);
        this.nombre = nombre;
        this.precio = precio;
        this.stock = stock;
        this.categoria = categoria;
    }


    public void ReducirStock(){
        if(stock  - 1 < 0){
            System.Console.WriteLine("No queda stock");
        }
        else{
            stock--;
        }
    }

    public void AumentarStock()
    {
        this.stock += 1;
    }

    public int GetStock()
    {
        return this.stock;
    }

    public void SetStock(int nuevoStock)
    {
        if(nuevoStock < 0){
            System.Console.WriteLine("Hubo un error no se puede actualizar el stock");
        }
        else{
            this.stock = nuevoStock;
        }
    }

    public String GetNombreProducto(){
        return this.nombre;
    }

    public bool ValidaStock()
    {
        if(this.stock <= 0){
            return false;
        }

        return true;
    }

    
    public double ConDescuento(){
        return this.precio * (1 - this.categoria.GetDescuento());
    }

    private static void Validador(string nombre, double precio, int stock, Categoria categoria)
    {
        if(nombre == ""){
            throw new ArgumentException("El nombre no puede estar vacio");
        }
        else if(precio <= 0 || stock < 0){
            throw new ArgumentException("El stock y el precio no pueden ser negativos");
        }
        else if(categoria == null){
            throw new ArgumentException("El producto no puede ser nulo");
        }
    }

}