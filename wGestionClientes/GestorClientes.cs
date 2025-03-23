using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wGestionClientes
{
    public class GestorClientes
    {
        private static GestorClientes _instancia;
        private List<Cliente> clientes;

        private GestorClientes()
        {
            clientes = new List<Cliente>();
        }

        public static GestorClientes Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new GestorClientes();
                }
                return _instancia;
            }
        }

        public void AgregarCliente(Cliente cliente)
        {
            try
            {
                if (clientes.Exists(c => c.Identificacion == cliente.Identificacion))
                    throw new ArgumentException("El cliente con esta identificación ya existe.");

                clientes.Add(cliente);

                MessageBox.Show("Cliente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EliminarCliente(string identificacion)
        {
            try
            {
                clientes.RemoveAll(c => c.Identificacion == identificacion);
                MessageBox.Show("Cliente eliminado correctamente", "éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ActualizarCliente(string identificacion, string nuevoNombre, decimal nuevoSaldo)
        {
            try
            {
                Cliente cliente = clientes.FirstOrDefault(c => c.Identificacion == identificacion);

                if (cliente == null)
                {
                    throw new ArgumentException("No se encontró un cliente con esta identificación");
                }
                if (string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    throw new ArgumentException("El nombre no puede estar vacío");
                }
                if (nuevoSaldo <= 0)
                {
                    throw new ArgumentException("El saldo debe ser mayor que 0");
                }

                cliente.Nombre = nuevoNombre;
                cliente.Saldo = nuevoSaldo;

                MessageBox.Show("Cliente actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<Cliente> ObtenerClientes()
        {
            return clientes;
        }
    }
}
