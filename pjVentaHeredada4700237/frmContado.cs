using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjVentaHeredada4700237
{
    public partial class frmContado : Form
    {
        static string[] productos = { "Lavadora", "Refrigeradora", "Licuadora", "Extractora", "Radiograbadora", "DVD", "BluRay" };

        ArrayList aProductos = new ArrayList(productos);

        double tSubtotal = 0;
        public frmContado()
        {
            InitializeComponent();
        }

        private void btnAdquirir_Click(object sender, EventArgs e)
        {
            Contado objc = new Contado();

            objc.cliente = txtCliente.Text;
            objc.Ruc = txtRuc.Text;
            objc.fecha = lblFecha.Text;
            objc.hora = lblHora.Text;

            objc.producto = cboProducto.Text;
            objc.cantidad = int.Parse(txtCantidad.Text);

            ListViewItem fila = new ListViewItem(objc.getN().ToString());
            fila.SubItems.Add(objc.producto);
            fila.SubItems.Add(objc.cantidad.ToString());
            fila.SubItems.Add(objc.asignaprecio().ToString("C"));
            fila.SubItems.Add(objc.calculaSubtotal().ToString());
            lvDetalle.Items.Add(fila);

            listado(objc);
        }

        private void frmContado_Load(object sender, EventArgs e)
        {
            cboProducto.DataSource = aProductos;
            mostrarFecha();
            mostrarHora();
        }
        void mostrarFecha()
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }
        void mostrarHora()
        {
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }
        void listado(Contado objc)
        {
            tSubtotal += objc.calculaSubtotal();
            lstResumen.Items.Clear();
            lstResumen.Items.Add("** RESUMEN DE VENTA **");
            lstResumen.Items.Add("---------------------------------------");
            lstResumen.Items.Add("CLIENTE:" + objc.cliente);
            lstResumen.Items.Add("RUC:" + objc.Ruc);
            lstResumen.Items.Add("FECHA:" + objc.fecha);
            lstResumen.Items.Add("HORA:" + objc.hora);
            lstResumen.Items.Add("---------------------------------------");
            lstResumen.Items.Add("Subtotal:" + tSubtotal.ToString("C"));
            double descuento = objc.calculaDescuento(tSubtotal);
            double neto = objc.calculaneto(tSubtotal, descuento);
            lstResumen.Items.Add("NETO:" + neto.ToString("C"));


            lblNeto.Text = neto.ToString("C");
        }
    }
    
}
