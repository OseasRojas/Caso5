using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjVentaHeredada4700237
{
    internal class Venta
    {
        public string cliente { get; set; }
        public string Ruc { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }


        public double asignaprecio()
        {
            switch (producto)
            {
                case "Lavadora": return 1500;
                case "Refrigeradora": return 3500;
                case "Licuadora": return 500;
                case "Extractora": return 150;
                case "Radiograbadora": return 750;
                case "DVD": return 100;
                case "BluRay": return 250;

            }
            return 0;
        }

        public double calculaSubtotal()
        {
            return asignaprecio() * cantidad;
        }
    }
}
