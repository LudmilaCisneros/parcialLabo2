﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Kwik_E_Mart
{
    public static class Negocio
    {
        public static List<Producto> listaProductos;
        public static List<Compra> listaCompras;
        public static Dictionary<string, string> usuariosPass;
        private static int autoIncrement;

        static Negocio()
        {
            listaProductos = new List<Producto>();
            listaCompras = new List<Compra>();
            usuariosPass = new Dictionary<string, string>();
            CargarUsuariosPasswords();
            CargarProductosDisponibles();
            autoIncrement = 0;
        }

        public static void CargarUsuariosPasswords()
        {
            usuariosPass.Add("Apu", "1234");
            usuariosPass.Add("Sanjay", "holi");
        }
        /// <summary>
        /// Hardcodeo stock disponible
        /// </summary>
        /// <param name="listaProductos"></param>
        public static void CargarProductosDisponibles()
        {
            listaProductos.Add(new Producto(1, "cerveza Duff", 20, 100, Producto.ETipo.bebida));
            listaProductos.Add(new Producto(2, "cigarrillos Laramie", 10, 150, Producto.ETipo.varios));
            listaProductos.Add(new Producto(3, "rosquilla", 40, 20, Producto.ETipo.comestibles));
            listaProductos.Add(new Producto(4, "hot dog", 20, 100, Producto.ETipo.comestibles));
            listaProductos.Add(new Producto(5, "waffles", 20, 100, Producto.ETipo.comestibles));
            listaProductos.Add(new Producto(6, "buzz Cola", 20, 100, Producto.ETipo.bebida));
            listaProductos.Add(new Producto(7, "boletos loteria", 20, 15, Producto.ETipo.varios));
            listaProductos.Add(new Producto(8, "patatas fritas", 20, 30, Producto.ETipo.comestibles));
            listaProductos.Add(new Producto(9, "chupelupes", 20, 5.60f, Producto.ETipo.golosinas));
            listaProductos.Add(new Producto(10, "mani", 20, 100, Producto.ETipo.comestibles));
            listaProductos.Add(new Producto(11, "butterfinger", 20, 100, Producto.ETipo.golosinas));
            listaProductos.Add(new Producto(12, "tarta de luna", 20, 100, Producto.ETipo.comestibles));
            listaProductos.Add(new Producto(13, "leche", 20, 100, Producto.ETipo.bebida));
            listaProductos.Add(new Producto(14, "anciano congelado", 20, 100, Producto.ETipo.varios));
            listaProductos.Add(new Producto(15, "telefono dulce", 20, 100, Producto.ETipo.golosinas));
            listaProductos.Add(new Producto(16, "revistas porno", 20, 100, Producto.ETipo.varios));
            listaProductos.Add(new Producto(17, "tarjetas", 20, 100, Producto.ETipo.varios));
            listaProductos.Add(new Producto(18, "jamon", 20, 100, Producto.ETipo.comestibles));
            listaProductos.Add(new Producto(19, "raspados", 20, 100, Producto.ETipo.bebida));
            listaProductos.Add(new Producto(20, "armas", 20, 100, Producto.ETipo.varios));
            listaProductos.Add(new Producto(21, "preservativos", 20, 100, Producto.ETipo.varios));
            listaProductos.Add(new Producto(22, "radioctive man comics", 20, 100, Producto.ETipo.varios));
            listaProductos.Add(new Producto(23, "cereales Krusty", 20, 100, Producto.ETipo.comestibles));
            listaProductos.Add(new Producto(24, "pan de astronauta", 20, 100, Producto.ETipo.comestibles));
            listaProductos.Add(new Producto(25, "hamburguesa", 20, 100, Producto.ETipo.comestibles));
            listaProductos.Add(new Producto(26, "squishees", 20, 100, Producto.ETipo.golosinas));
            listaProductos.Add(new Producto(27, "horoscopos", 20, 100, Producto.ETipo.varios));
            listaProductos.Add(new Producto(28, "fruta", 20, 100, Producto.ETipo.comestibles));
            listaProductos.Add(new Producto(29, "café", 20, 100, Producto.ETipo.bebida));
            listaProductos.Add(new Producto(30, "agua", 20, 100, Producto.ETipo.bebida));
            listaProductos.Add(new Producto(31, "prueba", 0, 100, Producto.ETipo.bebida));

            return;
        }

        public static void HardcodearCompras()
        {
            for (int i = 0; i < 50; i++)
            {
                HardcodearCompra();
            }
        }
        private static void HardcodearCompra()
        {
            Random random = new Random();
            Cliente cliente = new Cliente();
            Compra nuevaCompra;
            string auxCliente;
            int aux;
            int length = random.Next(3, 5);

            //hardcodear productos
            for (int i = 0; i < length; i++)
            {
                aux = random.Next(0, listaProductos.Count - 1);
                if (listaProductos[aux].Stock > 0)
                {
                    cliente.carritoCliente.Add(listaProductos[aux]);
                    listaProductos[aux].Stock = listaProductos[aux].Stock - 1;
                }
            }
            auxCliente = "cliente ";
            auxCliente = string.Concat(auxCliente, autoIncrement.ToString());
            nuevaCompra = new Compra(cliente, auxCliente, "Apu", "efectivo");
            listaCompras.Add(nuevaCompra);
            autoIncrement++;
        }
        public static int EncontrarIndexEnLista(List<Producto> listaProductos, int idProducto)
        {
            int index = -1;

            for (int i = 0; i < listaProductos.Count; i++)
            {
                if (listaProductos[i].IdProducto == idProducto)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public static string generarTextoUsuariosPass()
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> item in usuariosPass)
            {
                sb.AppendLine();
                sb.AppendFormat("{0}  -  {1}\n", item.Key, item.Value);
            }
            return sb.ToString();
        }
        public static List<string> HardcodearMediosDePago(List<string> mediosDePagoHabilitados)
        {
            mediosDePagoHabilitados.Add("efectivo");
            mediosDePagoHabilitados.Add("debito");
            mediosDePagoHabilitados.Add("credito");

            return mediosDePagoHabilitados;
        }
        /// <summary>
        /// Encuentra cual compra del cliente
        /// </summary>
        /// <param name="coleccionDeCeldasSelect"></param>
        /// /// <returns>el carrito de ese cliente</returns>
        public static int EncontrarCompraPorNombreCte(string nombreCte)
        {
            int index = -1;

            for (int i = 0; i < listaCompras.Count-1; i++)
            {
                if(listaCompras[i].NombreCliente == nombreCte)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

    }
}
