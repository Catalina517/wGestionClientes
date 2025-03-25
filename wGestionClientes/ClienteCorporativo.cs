using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wGestionClientes
{
    public class ClienteCorporativo : Cliente
    {
        public bool AccesoLineaCredito {  get; set; }

        public ClienteCorporativo(string nombre, string identificacion, decimal saldo) : base(nombre, identificacion, saldo)
        {
            if (saldo <= 0 || saldo < 50000000)
            {
                throw new ArgumentException("l saldo para un cliente corporativo debe ser mayor que 0 y al menos de 50,000,000");
            }

            AccesoLineaCredito = saldo >= 50000000;


            if (!AccesoLineaCredito)
            {
                MessageBox.Show("El saldo no alcanza para acceder al crédito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override string CalcularBeneficio()
        {
            if (AccesoLineaCredito)
            {
                return "Cliente con acceso a línea de crédito.";
            }
            else
            {
                return "Cliente sin acceso a línea de crédito.";
            }
        }
    }
}
