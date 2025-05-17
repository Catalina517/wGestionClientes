using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wGestionClientes
{
    public partial class frmGestionClientes : Form
    {
        public frmGestionClientes()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            cmbTipo.Items.Add("Cliente corporativo");
            cmbTipo.Items.Add("Cliente individual");
            cmbTipo.SelectedIndex = 0;

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarCampos();
        }

        private void MostrarCampos()
        {
            if (cmbTipo.SelectedItem.ToString() == "Cliente corporativo")
            {
                lblCuentasActivas.Visible = false;
                txtCantidadCuentas.Visible = false;
            }
            else
            {
                lblCuentasActivas.Visible = true;
                txtCantidadCuentas.Visible = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string identificacion = txtIdentificación.Text.Trim();
            decimal saldo = decimal.Parse(txtSaldo.Text);
            string tipo = cmbTipo.SelectedItem.ToString();
            int cantidadCuentas = 0;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(identificacion))
            {
                MessageBox.Show("El nombre no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((!decimal.TryParse(txtSaldo.Text, out saldo) || saldo < 0))

                {
                MessageBox.Show("Ingrese un valor valido para el saldo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tipo == "Cliente individual")
            {
                if (!int.TryParse(txtCantidadCuentas.Text, out cantidadCuentas) || cantidadCuentas < 0)
                {
                    MessageBox.Show("Ingrese un número válido de cuentas activas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                Cliente nuevoCliente = ClienteFactory.CrearCliente(tipo, nombre, identificacion, saldo, cantidadCuentas);
                bool agregado = GestorClientes.Instancia.AgregarCliente(nuevoCliente);

                if (agregado)
                {
                    MessageBox.Show("Cliente agregado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LimpiarCampos();
        }

        public void LimpiarCampos()
        {
            txtNombre.Clear();
            txtIdentificación.Clear();
            txtSaldo.Clear();
            txtCantidadCuentas.Clear();
            cmbTipo.SelectedIndex = 0;
            txtNombre.Focus();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            lstClientes.Items.Clear();
            foreach (var c in GestorClientes.Instancia.ObtenerClientes())
            {
                lstClientes.Items.Add($"{c.Nombre} - {c.Identificacion} - {c.Saldo}");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string identificacion = txtIdentificación.Text;
                string nuevoNombre = txtNombre.Text;
                decimal nuevoSaldo = decimal.Parse(txtSaldo.Text);
                GestorClientes.Instancia.ActualizarCliente(identificacion, nuevoNombre, nuevoSaldo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string identificacion = txtIdentificación.Text;
                GestorClientes.Instancia.EliminarCliente(identificacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LimpiarCampos();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
