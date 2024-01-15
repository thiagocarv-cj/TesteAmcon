using System.Globalization;

namespace Questao1
{
    class ContaBancaria
    {
        public int numero;
        public string? titular;
        public double depositoinicial;

        public ContaBancaria(int numero, string? titular)
        {
            this.numero = numero;
            this.titular = titular;
        }

        public ContaBancaria(int numero, string? titular, double depositoInicial)
        {
            this.numero = numero;
            this.titular = titular;
            depositoinicial = depositoInicial;
        }

        internal void Deposito(double quantia)
        {
            depositoinicial += quantia;
        }

        internal void Saque(double quantia)
        {
            depositoinicial -= quantia;
        }


    }
    
}
