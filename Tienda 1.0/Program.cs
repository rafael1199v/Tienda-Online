

Categoria alimentos = new Categoria("Alimentos", 0.1);
Categoria electronicos = new Categoria("Electronicos", 0.5);
Categoria libros = new Categoria("Libros", 0.5);


Electronico computador = new Electronico("Computador nuevo", 500.2, 1, electronicos, "Acer", "Windows 10", "Laptop");
Producto yogurtPil = new Producto("Yogurt Pil", 100.1, 3, alimentos);
Libro principito = new Libro("Principito", 50.23, 12, libros, "Antoine de Saint-Exupéry", "Novela", "06-04-1943");

Paquete paqueteYogurt = new Paquete("Paquete Super Pil Yogurt x 12", yogurtPil, 12, 2);


Cliente nuevoCliente = new Cliente("Rafael Vargas", "Av Los Andes", 13774782);
Cliente cliente2 = new Cliente("Daniel Penharanda", "Segundo Anillo", 12345678);

nuevoCliente.CrearCarrito();

nuevoCliente.InsertarCarrito(computador, 0);

nuevoCliente.InsertarCarrito(yogurtPil, 0);
nuevoCliente.InsertarCarritoPaquete(yogurtPil, 2, 0);
nuevoCliente.InsertarCarritoPaquete(yogurtPil, 2, 0);
nuevoCliente.InsertarCarritoPaquete(principito, 6, 0);


// nuevoCliente.CrearCarrito();
// nuevoCliente.InsertarCarrito(principito, 1);
// nuevoCliente.InsertarCarrito(computador, 1);


//nuevoCliente.ImprimirCarritosDisponibles();

nuevoCliente.Comprar(0);
nuevoCliente.ImprimirFactura();
// nuevoCliente.Comprar(0);
// nuevoCliente.ImprimirFactura();



//nuevoCliente.ImprimirCarritosDisponibles();


