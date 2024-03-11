
public class Carrito
{
    protected List<Producto> carrito;
    public Carrito()
    {
        carrito = new List<Producto>();
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

        if(this.carrito.Count == 0){
            System.Console.WriteLine("El carrito ya esta vacio");
        }
        else{
            this.carrito.Last().AumentarStock();
            this.carrito.RemoveAt(this.carrito.Count - 1);
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

    public void ImprimirCarrito()
    {
        for(int i = 0; i < this.carrito.Count; i++)
        {
            System.Console.WriteLine(this.carrito[i].GetNombreProducto());
        }
    }


    public List<Producto> GetCarrito()
    {
        return this.carrito;
    }

}