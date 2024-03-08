
using System.Runtime.CompilerServices;

public class Cliente
{
    protected string nombre;
    protected string direccion;
    protected List<Producto> carrito;

    protected List<Carrito> carritos;
    protected List<Factura> facturas;
    protected int numCarnet;
    




    public Cliente(string nombre, string direccion, int numCarnet)
    {
        Validador(nombre, direccion, numCarnet);
        this.nombre = nombre;
        this.direccion = direccion;
        this.numCarnet = numCarnet;
        this.carrito = new List<Producto>();
        this.facturas = new List<Factura>();
        this.carritos = new List<Carrito>();
    }

    public void InsertarCarrito(Producto nuevo){
        if(nuevo.GetStock() <= 0){
            System.Console.WriteLine("No queda stock de producto");
        }
        else{
            carrito.Add(nuevo);
        }   
    }

    public void Comprar(){

       
        double costoTotal = this.GetTotalCosto();

        if(this.carrito.Count == 0){
            System.Console.WriteLine("Usted no tiene nada en el carrito");
        }
        else{

            for(int i = 0; i < this.carrito.Count; i++){

                if(!this.carrito[i].ValidaStock()){
                    costoTotal -= this.carrito[i].ConDescuento();
                    this.carrito.RemoveAt(i);
                    i--;
                }
                else{
                    this.carrito[i].ReducirStock();
                }


            }

            if(this.carrito.Count == 0){
                System.Console.WriteLine("Su carrito esta vacio");
                return;
            }


            string detalles = this.GetDetalleProductos(this.carrito);
            detalles += Convert.ToString(costoTotal) + "\n";
            System.Console.WriteLine("Productos Comprados: ");
            System.Console.WriteLine(detalles);
            System.Console.WriteLine("Total a pagar: " + Math.Round(costoTotal, 3));
            System.Console.WriteLine("Gracias por su compra");
            System.Console.Write("Introduce el nombre: ");
            
            string ?nombreFactura;

            try{
                nombreFactura = Convert.ToString(System.Console.ReadLine());
            }
            catch(ArgumentNullException e){
                System.Console.WriteLine(e);
                nombreFactura = "Hipermaxi";
            }
            
            System.Console.Write("Introduce el NIT: ");
            int nit = Convert.ToInt32(System.Console.ReadLine());

            Factura fac = new Factura(nit, nombreFactura, detalles);
            facturas.Add(fac);
            this.carrito.Clear();
        }
        

    }


    public string GetDetalleProductos(List<Producto> carrito)
    {
        string detalles = "";
        foreach(Producto actual in carrito){
            detalles += $"Nombre Producto: {actual.GetNombreProducto()}\n";
            detalles += $"Precio Producto: {actual.ConDescuento()}\n";
        }
        
        return detalles;
    }


    

    public void QuitarElementoCarrito()
    {

        if(this.carrito.Count == 0){
            System.Console.WriteLine("El carrito ya esta vacio");
        }
        else{
            this.carrito.Last().AumentarStock();
            this.carrito.RemoveAt(this.carrito.Count - 1);
        }
        
    }

    public void QuitarElementoCarrito(Producto producto)
    {

        if(this.carrito.Count == 0){
            System.Console.WriteLine("El carrito ya esta vacio");
        }
        else{

            for(int i = 0; i < this.carrito.Count; i++){
                if(this.carrito[i] == producto){
                    this.carrito[i].AumentarStock();
                    this.carrito.RemoveAt(i);
                    break;
                }
            }
        }
        
    }

    public double GetTotalCosto()
    {
        double total = 0;
        for(int i = 0; i < this.carrito.Count; i++){
            total += this.carrito[i].ConDescuento();
        }

        return total;
    }


    private static void Validador(string nombre, string direccion, int numCarnet)
    {
        if(nombre == "" || direccion == ""){
            throw new ArgumentException("El nombre o la direccion no puede estar vacio");
        }
        else if(numCarnet < 0){
            throw new ArgumentException("El numero de carnet no puede ser negativo");
        }

    }

    public void ImprimirCarrito()
    {
        for(int i = 0; i < this.carrito.Count; i++)
        {
            System.Console.WriteLine(this.carrito[i].GetNombreProducto());
        }
    }

}