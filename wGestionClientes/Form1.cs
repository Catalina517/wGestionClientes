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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region[Combo Clientes]
            cmbTipoCliente.Items.Add("Cliente corporativo");
            cmbTipoCliente.Items.Add("Cliente individual");
            cmbTipoCliente.SelectedIndex = 0;
            #endregion

        }

        private void cmbTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarCampos();
        }

        private void MostrarCampos()
        {
            if (cmbTipoCliente.SelectedItem.ToString() == "Cliente corporativo")
            {
                chkAccesoCredito.Visible = true;
                lblCuentasActivas.Visible = false;
                txtCantidadCuentas.Visible = false;
            }
            else
            {
                chkAccesoCredito.Visible = false;
                lblCuentasActivas.Visible = true;
                txtCantidadCuentas.Visible = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string identificacion = txtIdentificación.Text;
            decimal saldo = decimal.Parse(txtSaldo.Text);
            string tipo = cmbTipoCliente.SelectedItem.ToString();

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

            try
            {
                Cliente nuevoCliente = ClienteFactory.CrearCliente(tipo, nombre, identificacion, saldo);
                GestorClientes.Instancia.AgregarCliente(nuevoCliente);
                MessageBox.Show("Cliente agregado correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LimpiarCampos()
        {
            txtNombre.Clear();
            txtIdentificación.Clear();
            txtSaldo.Clear();
            cmbTipoCliente.SelectedIndex = 0;
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
        }
    }
}
