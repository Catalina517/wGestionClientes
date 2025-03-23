using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientes
{
    public class ClienteFactory
    {
        public static Cliente CrearCliente(string tipo, string nombre, string identificacion, decimal saldo, bool accesoLineaCredito = false, int cantidadCuentas = 0)
        {
            if (tipo ==  "Cliente Corporativo")
            {
                return new ClienteCorporativo(nombre, identificacion, saldo, accesoLineaCredito);
            }
            else if
        }
    }
}
