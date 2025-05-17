using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientes
{
    public abstract class Cliente
    {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }

        public decimal Saldo { get; set; }

        public Cliente(string nombre, string identificacion, decimal saldo)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentNullException("El nombre no puede estar vacío");
            }
            if (string.IsNullOrWhiteSpace(identificacion))
            {
                throw new ArgumentException("La identificación no puede estar vacía");
            }
            if (saldo <= 0)
            {
                throw new ArgumentException("El saldo debe ser mayor que 0");
            }

            Nombre = nombre;
            Identificacion = identificacion;
            Saldo = saldo;
        }

        public abstract string CalcularBeneficio();
    }
}
