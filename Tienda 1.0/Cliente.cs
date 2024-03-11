
using System.Runtime.ConstrainedExecution;

public class Cliente
{
    protected string nombre;
    protected string direccion;
    //protected List<Producto> carrito;

    protected List<Carrito> carritos;
    protected List<Factura> facturas;
    protected int numCarnet;
    
    public Cliente(string nombre, string direccion, int numCarnet)
    {
        Validador(nombre, direccion, numCarnet);
        this.nombre = nombre;
        this.direccion = direccion;
        this.numCarnet = numCarnet;
        this.facturas = new List<Factura>();
        this.carritos = new List<Carrito>();
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


    public void ImprimirFactura()
    {
        if(this.facturas.Count == 0){
            System.Console.WriteLine("Usted no tiene un historial disponible");
        }
        else{
            System.Console.WriteLine($"Nombre: {facturas.Last().GetNombreFactura()}");
            System.Console.WriteLine($"NIT: {facturas.Last().GetNit()}");
            System.Console.WriteLine(facturas.Last().GetDetalleFactura());
        }
        
    }


    public void ImprimirCarritosDisponibles()
    {
        for(int i = 0 ; i < this.carritos.Count; i++)
        {
            System.Console.WriteLine($"Carrito {i + 1}:");

            for(int j = 0; j < this.carritos[i].GetCarrito().Count; j++)
            {
                System.Console.Write(this.carritos[i].GetCarrito()[j].Item1.GetNombreProducto() + " - ");
                System.Console.WriteLine(this.carritos[i].GetCarrito()[j].Item1.ConDescuento());
            }
        }
    }


    public void InsertarCarrito(Producto nuevo, int indiceCarrito){
        if(nuevo.GetStock() <= 0){
            System.Console.WriteLine("No queda stock de producto");
        }
        else{
            this.carritos[indiceCarrito].GetCarrito().Add((nuevo, 1));
        }   
    }


    public void Comprar(int indiceCarrito){

       
        double costoTotal = this.GetTotalCostoCarrito(indiceCarrito);
        System.Console.WriteLine("AAAAA" + costoTotal);

        if(this.carritos[indiceCarrito].GetCarrito().Count == 0){
            System.Console.WriteLine("Usted no tiene nada en el carrito actual");
        }
        else{

            for(int i = 0; i < this.carritos[indiceCarrito].GetCarrito().Count; i++){


               
                if(!this.carritos[indiceCarrito].GetCarrito()[i].Item1.ValidaStock() || this.carritos[indiceCarrito].GetCarrito()[i].Item2 > this.carritos[indiceCarrito].GetCarrito()[i].Item1.GetStock())
                {

                    System.Console.WriteLine(costoTotal + " Probando antes de que sea boraddo");
                    costoTotal -= this.carritos[indiceCarrito].GetCarrito()[i].Item1.ConDescuento() * this.carritos[indiceCarrito].GetCarrito()[i].Item2;
                    System.Console.WriteLine(costoTotal + " Despues de que sea borrado");
                    this.carritos[indiceCarrito].GetCarrito().RemoveAt(i);
                    i--;
                }
                else
                {
                    this.carritos[indiceCarrito].GetCarrito()[i].Item1.ReducirStock(this.carritos[indiceCarrito].GetCarrito()[i].Item2);
                }


            }


            System.Console.WriteLine(costoTotal + " BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");

            if(this.carritos[indiceCarrito].GetCarrito().Count == 0){
                System.Console.WriteLine("Su carrito esta vacio");
                return;
            }


            string detalle = Factura.GenerarFactura(this.carritos[indiceCarrito]);
            
            string ?nombreFactura = "";

            System.Console.WriteLine("Introduce tu Nombre: ");
            try{
                nombreFactura = Console.ReadLine();
            }
            catch(ArgumentNullException e){
                System.Console.WriteLine(e);
                nombreFactura = "Hipermaxi";
            }
            
            System.Console.WriteLine("Introduce el NIT: ");
            int nit = Convert.ToInt32(System.Console.ReadLine());

            Factura fac = new Factura(nit, nombreFactura, detalle);
            facturas.Add(fac);

            this.carritos.RemoveAt(indiceCarrito);
        }
        

    }


    // public string GetDetalleProductos(List<Producto> carrito)
    // {
    //     string detalles = "";
    //     foreach(Producto actual in carrito){
    //         detalles += $"Nombre Producto: {actual.GetNombreProducto()}\n";
    //         detalles += $"Precio Producto: {actual.ConDescuento()}\n";
    //     }
        
    //     return detalles;
    // }


    

    public void QuitarElementoCarrito()
    {

        if(this.carritos.Count == 0){
            System.Console.WriteLine("Usted no ha reservado ningun carrito");
        }

        else{
            this.carritos.Last().GetCarrito().Last().Item1.AumentarStock();
            this.carritos.Last().GetCarrito().RemoveAt(this.carritos.Last().GetCarrito().Count - 1);
            // this.carrito.RemoveAt(this.carrito.Count - 1);
        }
        
    }

    public void QuitarElementoCarrito(Producto producto, int indiceCarrito)
    {

        if(this.carritos[indiceCarrito].GetCarrito().Count == 0){
            System.Console.WriteLine("El carrito ya esta vacio");
        }
        else{

            for(int i = 0; i < this.carritos[indiceCarrito].GetCarrito().Count; i++){
                if(this.carritos[indiceCarrito].GetCarrito()[i].Item1 == producto){
                    // this.carritos[indiceCarrito].GetCarrito()[i].AumentarStock();
                    (this.carritos[indiceCarrito].GetCarrito()).RemoveAt(i);
                    // this.carrito.RemoveAt(i);
                    break;
                }
            }
        }
        
    }

    public double GetTotalCostoCarrito(int indiceCarrito)
    {
        double total = 0;
        for(int i = 0; i < this.carritos[indiceCarrito].GetCarrito().Count; i++){
            if(this.carritos[indiceCarrito].GetCarrito()[i].Item2 > 1)
            {
                total += this.carritos[indiceCarrito].GetCarrito()[i].Item1.ConDescuento() * this.carritos[indiceCarrito].GetCarrito()[i].Item2;
            }
            else{
                total += this.carritos[indiceCarrito].GetCarrito()[i].Item1.ConDescuento();
            }
            
        }

        return total;
    }


    public void ImprimirCarrito(int indiceCarrito)
    {
        for(int i = 0; i < this.carritos[indiceCarrito].GetCarrito().Count; i++)
        {
            System.Console.WriteLine(this.carritos[indiceCarrito].GetCarrito()[i].Item1.GetNombreProducto());
        }
    }


    public void CrearCarrito()
    {
        this.carritos.Add(new Carrito());
    }

    public void InsertarCarritoPaquete(Producto producto, int cantidad, int indiceCarrito)
    {
        if(producto.GetStock() <= 0 || producto.GetStock() < cantidad)
        {
            System.Console.WriteLine("La cantidad para el paquete no esta disponible");
        }
        else
        {
            this.carritos[indiceCarrito].GetCarrito().Add((producto, cantidad));
        }
    }

}