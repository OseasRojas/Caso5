using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjVentaHeredada4700237
{
    class Contado : Venta
    {
        public static int n;

        public Contado()
        {
            n++;
        }
        public int getN()
        {
            return n;
        }

        public double calculaDescuento(double Subtotal)
        {
            if (Subtotal < 1000)
                return 2.0 / 100 * Subtotal;
            else if (Subtotal >= 1000 && Subtotal <= 3000)
                return 5.0 / 100 * Subtotal;
            else
                return 12.0 / 100 * Subtotal;
        }
        public double calculaneto(double subtotal, double descuento)
        {
            return subtotal - descuento;
        }
    }
}
