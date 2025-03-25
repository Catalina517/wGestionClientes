using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wGestionClientes
{
    public class ClienteIndividual : Cliente
    {
        public int CantidadCuentasActivas {  get; set; }

        public ClienteIndividual(string nombre, string identificacion, decimal saldo, int cantidadCuentas) : base(nombre, identificacion, saldo)
        {
            if (cantidadCuentas > 3)
            {
               throw new ArgumentException("Un cliente individual no puede tener más de 3 cuentas activas");
            }

            CantidadCuentasActivas = cantidadCuentas;
        }

        public override string CalcularBeneficio()
        {
            return "Cliente individual sin beneficios especiales.";
        }
    }
}
