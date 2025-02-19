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
    public partial class frmCredito : Form
    {
        static int[] Letras = { 3, 6, 9, 12 };
        static string[] productos = { "Lavadora", "Refrigeradora", "Licuadora", "Extractora", "Radiograbadora", "DVD", "BluRay" };


        ArrayList aproductos = new ArrayList(productos);
        ArrayList aletras = new ArrayList(Letras);

        double tSubtotal = 0;
        public frmCredito()
        {
            InitializeComponent();
        }
        private void frmCredito_Load(object sender, EventArgs e)
        {
            cboLetras.DataSource = aletras;
            cboProducto.DataSource = aproductos;
            mostrarfecha();
            mostrarhora();
        }
        void mostrarfecha()
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }
        void mostrarhora()
        {
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnAdquirir_Click(object sender, EventArgs e)
        {
            Credito objcr = new Credito();

            objcr.cliente = txtCliente.Text;
            objcr.Ruc = txtRuc.Text;
            objcr.fecha = lblFecha.Text;
            objcr.hora = lblHora.Text;

            objcr.producto = cboProducto.Text;
            objcr.cantidad = int.Parse(txtCantidad.Text);

            ListViewItem fila = new ListViewItem(objcr.getX().ToString());
            fila.SubItems.Add(objcr.producto);
            fila.SubItems.Add(objcr.cantidad.ToString());
            fila.SubItems.Add(objcr.asignaprecio().ToString("C"));
            fila.SubItems.Add(objcr.calculaSubtotal().ToString("C"));
            lvDetalle.Items.Add(fila);
            tSubtotal += objcr.calculaSubtotal();
            lblMonto.Text = tSubtotal.ToString("0.00");
        }
        void montoLetras(int le)
        {
            double montoMensual = double.Parse(lblMonto.Text) / le;

            lvResumen.Items.Clear();
            for (int i = 1; 1 <= i; i++)
            {
                ListViewItem fila = new ListViewItem(i.ToString());
                fila.SubItems.Add(montoMensual.ToString("C"));
                lvResumen.Items.Add(fila);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            int letras = int.Parse(cboLetras.Text);
            switch (letras)
            {
                case 3: montoLetras(3); break;
                case 6: montoLetras(6); break;
                case 9: montoLetras(9); break;
                case 12: montoLetras(12); break;
            }
        }
    }
    
}
