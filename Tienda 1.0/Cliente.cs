
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
                System.Console.Write(this.carritos[i].GetCarrito()[j].GetNombreProducto() + " - ");
                System.Console.WriteLine(this.carritos[i].GetCarrito()[j].ConDescuento());
            }
        }
    }


    public void InsertarCarrito(Producto nuevo, int indiceCarrito){
        if(nuevo.GetStock() <= 0){
            System.Console.WriteLine("No queda stock de producto");
        }
        else{
            this.carritos[indiceCarrito].GetCarrito().Add(nuevo);
        }   
    }


    public void Comprar(int indiceCarrito){

       
        double costoTotal = this.GetTotalCostoCarrito(indiceCarrito);

        if(this.carritos[indiceCarrito].GetCarrito().Count == 0){
            System.Console.WriteLine("Usted no tiene nada en el carrito actual");
        }
        else{

            for(int i = 0; i < this.carritos[indiceCarrito].GetCarrito().Count; i++){

                if(!this.carritos[indiceCarrito].GetCarrito()[i].ValidaStock()){
                    costoTotal -= this.carritos[indiceCarrito].GetCarrito()[i].ConDescuento();
                    this.carritos[indiceCarrito].GetCarrito().RemoveAt(i);
                    i--;
                }
                else{
                    this.carritos[indiceCarrito].GetCarrito()[i].ReducirStock();
                }


            }

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
            this.carritos.Last().GetCarrito().Last().AumentarStock();
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
                if(this.carritos[indiceCarrito].GetCarrito()[i] == producto){
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
            total += this.carritos[indiceCarrito].GetCarrito()[i].ConDescuento();
        }

        return total;
    }


    public void ImprimirCarrito(int indiceCarrito)
    {
        for(int i = 0; i < this.carritos[indiceCarrito].GetCarrito().Count; i++)
        {
            System.Console.WriteLine(this.carritos[indiceCarrito].GetCarrito()[i].GetNombreProducto());
        }
    }


    public void CrearCarrito()
    {
        this.carritos.Add(new Carrito());
    }
    
}