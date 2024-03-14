
public class Factura
{
    protected int nit;
    protected string? nombre;
    protected string detalle;
    protected double costoTotal;

    public Factura(int nit, string? nombre, string detalle, double costoTotal)
    {
        this.nit = nit;
        this.nombre = nombre;
        this.detalle = detalle;
        this.costoTotal = costoTotal;
    }


    public static string GenerarFactura(Carrito carrito)
    {
        
        string detalles = "";
        double precioTotal = carrito.GetTotalCostoCarrito();

        for(int i = 0; i < carrito.GetCarrito().Count; i++){

            string nombre = carrito.GetCarrito()[i].Item1.nombre;
            int cantidad = 1;
    
            for(int j = i + 1; j < carrito.GetCarrito().Count; j++){

                if(nombre == carrito.GetCarrito()[j].Item1.nombre && carrito.GetCarrito()[i].Item2 == carrito.GetCarrito()[j].Item2)
                {
                    cantidad += 1; 
                    carrito.GetCarrito().RemoveAt(j);
                    j--;
                }

            }

            if(carrito.EsPaquete(i))
            {
                detalles += "Paquete: ";
                detalles += nombre + " - Cantidad: "  + cantidad + " - Costo total: " + carrito.GetCarrito()[i].Item1.ConDescuento() * cantidad * carrito.GetCarrito()[i].Item2 * 0.9 + "\n";
            }
            else
            {
                detalles += nombre + " - Cantidad: "  + cantidad + " - Costo total: " + carrito.GetCarrito()[i].Item1.ConDescuento() * cantidad * carrito.GetCarrito()[i].Item2 + "\n";
            }

            
            detalles += carrito.GetCarrito()[i].Item1.GetDetalleProductos();
        }

        detalles += "Costo Total = " + Convert.ToString(Math.Round(precioTotal, 3));
        
        return detalles;
    
    }


    public int GetNit()
    {
        return this.nit;
    }
    public string? GetNombreFactura()
    {
        return this.nombre;
    }


    public string GetDetalleFactura()
    {
        return this.detalle;
    }



}