using System.Runtime.ConstrainedExecution;

Categoria alimentos = new Categoria("Alimentos", 0.1);
Categoria electronicos = new Categoria("Electronicos", 0.5);
Categoria libros = new Categoria("Libros", 0.5);


Producto computador = new Producto("Computador nuevo", 500.2, 1, electronicos);
Producto yogurtPil = new Producto("Yogurt Pil", 100.1, 3, alimentos);
Producto principito = new Producto("Principito", 50.23, 3, libros);


Cliente nuevoCliente = new Cliente("Rafael Vargas", "Av Los Andes", 13774782);
Cliente cliente2 = new Cliente("Daniel Penharanda", "Segundo Anillo", 12345678);

nuevoCliente.InsertarCarrito(computador);
cliente2.InsertarCarrito(computador);
nuevoCliente.InsertarCarrito(computador);
nuevoCliente.InsertarCarrito(computador);
nuevoCliente.InsertarCarrito(computador);
nuevoCliente.InsertarCarrito(computador);

nuevoCliente.ImprimirCarrito();


// nuevoCliente.InsertarCarrito(yogurtPil);
// nuevoCliente.InsertarCarrito(principito);

System.Console.WriteLine(computador.GetStock());

System.Console.WriteLine("C");

System.Console.WriteLine("C2");
cliente2.Comprar();
nuevoCliente.Comprar();

