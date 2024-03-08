
public class Categoria
{
    protected String nombre;
    protected double descuento;


    public Categoria(){
        nombre = "Generica";
        descuento = 0.0;
    }

    public Categoria(String nombre, double descuento){
        Validador(nombre, descuento);
        this.nombre = nombre;
        this.descuento = descuento;
    }


    public double GetDescuento()
    {
        return this.descuento;
    }
    public void SetDescuento(double nuevoDescuento)
    {
        this.descuento = nuevoDescuento;
    }

    public String GetCategoria() => this.nombre;
    public void SetCategoria(String nuevoNombre)
    {
        this.nombre = nuevoNombre;
    }


    private static void Validador(String nombre, double descuento)
    {
        if(nombre == ""){
            throw new ArgumentException("El nombre no puede estar vacio");
        }
        else if(descuento > 1 && descuento < 0){
            throw new ArgumentException("El descuento tiene que estar entre 1 y 0 no incluyentes");
        }

    }
    
}