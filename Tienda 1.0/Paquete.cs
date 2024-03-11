public class Paquete
{
    string nombrePaquete;
    Producto productoPaquete;
    int cantidadPaquete;
    int stockPaquete;

    public Paquete()
    {
        nombrePaquete = "Paquete Generico";
        productoPaquete = new Producto();
        cantidadPaquete = 6;
        stockPaquete = 1;
    }

    public Paquete(string nombrePaquete, Producto productoPaquete, int cantidadPaquete, int stockPaquete)
    {
        this.nombrePaquete = nombrePaquete;
        this.productoPaquete = productoPaquete;
        this.cantidadPaquete = cantidadPaquete;
        this.stockPaquete = stockPaquete;
    }


}