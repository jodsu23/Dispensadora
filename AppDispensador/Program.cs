using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dispensador;

namespace AppDispensador
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creamos objeto dispensador
            Dispensadora dispensador = new Dispensadora();

            //Agregamos menu de opciones

            Console.WriteLine("Bienvenidpos a la dispensadora Consola");

            while (true) {

                Console.WriteLine(dispensador.listarProducto());

                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Modificar producto");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Comprar producto");
                string opcion = Console.ReadLine();

                switch (opcion) {
                    case "1":
                        Producto producto = new Producto();

                        Console.Write("Codigo ");
                        producto.Codigo = Console.ReadLine();

                        Console.Write("Nombre ");
                        producto.Nombre = Console.ReadLine();

                        Console.Write("Categoria ");
                        producto.Categoria = Console.ReadLine();

                        Console.Write("Cantidad ");
                        producto.Cantidad = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Valor ");
                        producto.Valor = double.Parse(Console.ReadLine());

                        dispensador.agregarProducto(producto);

                        break;
                    case "2":
                        Producto mproducto = new Producto();

                        Console.Write("Codigo ");
                        mproducto.Codigo = Console.ReadLine();

                        // Validar codigo - continuar flujo
                        
                        Console.Write("Nombre ");
                        mproducto.Nombre = Console.ReadLine();

                        dispensador.modificarProducto(mproducto);

                        break;
                    case "3":
                        Console.Write("Codigo ");
                        string codigo = Console.ReadLine();

                        dispensador.eliminarProducto(codigo);

                        break;
                    case "4":
                        Console.Write("Codigo ");
                        string codigo_venta = Console.ReadLine();

                        Console.Write("Ingrese solo monedas de (1000-500-200-100) ");
                        dispensador.Pago = Console.ReadLine();
                        
                        Producto pcomprado = dispensador.vender(codigo_venta);

                        if (pcomprado == null)
                        {
                            Console.WriteLine("No se pudo sacar el producto");
                        }
                        else {
                            Console.WriteLine("su producto es {0} y la devuelta es {1}", pcomprado.Codigo, pcomprado.Cambio);
                        }

                        break;
                }

                Console.WriteLine("Desea continuar si/no");

                if (Console.ReadLine() == "no") {
                    break;
                }

            }

        }
    }
}
