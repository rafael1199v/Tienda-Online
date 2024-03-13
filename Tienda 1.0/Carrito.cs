
public class Carrito
{
    protected List<(Producto, int)> carrito;
    public Carrito()
    {
        carrito = new List<(Producto, int)>();
    }

    public void QuitarElementoCarrito(Producto producto)
    {

        if(this.carrito.Count == 0){
            System.Console.WriteLine("El carrito ya esta vacio");
        }
        else{

            for(int i = 0; i < this.carrito.Count; i++){
                if(this.carrito[i].Item1 == producto){
                    this.carrito[i].Item1.AumentarStock();
                    this.carrito.RemoveAt(i);
                    break;
                }
            }
        }
        
    }

    public void QuitarElementoCarrito()
    {

        if(this.carrito.Count == 0){
            System.Console.WriteLine("El carrito ya esta vacio");
        }
        else{
            this.carrito.Last().Item1.AumentarStock();
            this.carrito.RemoveAt(this.carrito.Count - 1);
        }
        
    }


    public double GetTotalCostoCarrito()
    {
        double total = 0;
        for(int i = 0; i < this.carrito.Count; i++){
            if(this.carrito[i].Item2 > 1)
            {
                total += this.carrito[i].Item1.ConDescuento() * 0.1 * this.carrito[i].Item2;
            }
            else{
                total += this.carrito[i].Item1.ConDescuento();
            }
            
        }

        return total;
    }


    public void ImprimirCarrito()
    {
        for(int i = 0; i < this.carrito.Count; i++)
        {
            System.Console.WriteLine(this.carrito[i].Item1.GetNombreProducto());
        }
    }


    public List<(Producto, int)> GetCarrito()
    {
        return this.carrito;
    }

    public bool EsPaquete(int indiceProducto)
    {
        if(this.carrito[indiceProducto].Item2 > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}