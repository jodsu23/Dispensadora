using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Dispensador
{
    public class Dispensadora
    {
        public List<Producto> Productos { get; set; }
        public string Pago { get; set; }

        //Se crea constructor y por defecto se creen 3 productos
        public Dispensadora() {
            this.Productos = new List<Producto>();

            Producto cocacola = new Producto();
            cocacola.Codigo = "01";
            cocacola.Nombre = "Coca Cola";
            cocacola.Categoria = "B";
            cocacola.Cantidad = 5;
            cocacola.Valor = 2000;

            Producto papas = new Producto();
            papas.Codigo = "02";
            papas.Nombre = "Margaritas";
            papas.Categoria = "M";
            papas.Cantidad = 2;
            papas.Valor = 1500;

            this.Productos.Add(cocacola);
            this.Productos.Add(papas);
        }

        public int validaProducto(string codigo) {
            int encontro = -1;

            for (int i = 0; i < this.Productos.Count; i++) {
                if (this.Productos[i].Codigo == codigo) {
                    encontro = i;
                }
            }

            return encontro;
        }

        public bool agregarProducto(Producto producto) {
            int enc = this.validaProducto(producto.Codigo);

            if (enc >= 0) {
                this.Productos[enc].sumarCantidad(producto.Cantidad);
            } else {
                this.Productos.Add(producto);
            }

            return true;
        }

        /// Crear la funcion modificarProducto(Producto producto)
        public bool modificarProducto(Producto producto){

            int enc = this.validaProducto(producto.Codigo);
            
            if (enc >= 0) {
                this.Productos[enc].Nombre = producto.Nombre;       
            }

            return false;
        }

        public bool eliminarProducto(string codigo) {
            int enc = this.validaProducto(codigo);

            if (enc >= 0) {
                this.Productos.RemoveAt(enc);
                return true;
            }

            return false;
        }

        public double validarMonedas(string[] monedas) {
            double total = 0;
            
            foreach (string item in monedas) {
                try
                {
                    total += float.Parse(item);
                }
                catch (Exception e) { }
            }

            return total;
        }

        // 1000-500-200-100
        public Producto vender(string codigo) {
            //Buscar el producto
            int enc = this.validaProducto(codigo);

            if (enc >= 0) {
                
                // Validar la cantidad
                if (this.Productos[enc].validarCantidad()){

                    // Validar el pago - Monedas
                    string[] monedas = this.Pago.Split('-');

                    double total = this.validarMonedas(monedas);

                    //Validar que precio sea mayor o igual
                    if (this.Productos[enc].validarValor(total)) {

                        //Se resta un producto
                        this.Productos[enc].restarProducto();

                        return this.Productos[enc];
                    }

                }

            }

            return null;
        }

        public string listarProducto() {
            string lista = "";
            foreach (Producto item in this.Productos) {
                lista += item.Codigo + " " + item.Nombre + " " + item.Categoria + " " + item.Cantidad + " " + item.Valor + "\n";
            }

            return lista;
        }

    }
}
