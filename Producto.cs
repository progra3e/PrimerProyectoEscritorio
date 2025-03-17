using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerProyectoEscritorio
{
    internal class Producto
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra {  get; set; }
        public decimal PrecioVenta { get; set; }
        public int Existencia {  get; set; }

        public void Vender()
        {
            ;
        }

        public void Comprar()
        {
            ;
        }
    }
}
