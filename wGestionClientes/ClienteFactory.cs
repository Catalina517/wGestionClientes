using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientes
{
    public class ClienteFactory
    {
        public static Cliente CrearCliente(string tipo, string nombre, string identificacion, decimal saldo, int cantidadCuentas = 0)
        {
            if (tipo ==  "Cliente corporativo")
            {
                return new ClienteCorporativo(nombre, identificacion, saldo);
            }
            else if (tipo == "Cliente individual")
            {
                return new ClienteIndividual(nombre, identificacion, saldo, cantidadCuentas);
            }
            else
            {
                throw new ArgumentException("Tipo de cliente no válido");
            }
        }
    }
}
