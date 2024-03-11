public class Electronico : Producto
{
    string marca;
    string Os;
    string tipo_electronico;


    public Electronico()
    {
        this.tipo_electronico = "PC";
        this.marca = "Hp";
        this.Os = "Windows xp";
    }
    
    public Electronico(string nombre, double precio, int stock, Categoria categoria, string marca, string Os, string tipo_electronico) : base(nombre, precio, stock, categoria)
    {
        this.tipo_electronico = tipo_electronico;
        this.marca = marca;
        this.Os = Os;
    }


    public override string GetDetalleAlgo()
    {

        string electronicoDetalle = "";
        electronicoDetalle += this.marca + "\n";
        electronicoDetalle += this.Os + "\n";
        electronicoDetalle += this.tipo_electronico + "\n";

        return electronicoDetalle;
    }
}