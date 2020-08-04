using DecompositorNumerico.Dominio;
using System;

namespace DecompositorNumerico.Servico
{
    public class Divisores
    {
        public Divisor Calcular (int valor)
        {
            int baseValor = valor;
            Divisor divisor = new Divisor();
            for (int i = 1; i < valor; i++)
            {
                try
                {
                    int a = baseValor / i;
                    divisor.Divisores.Add(i);
                    baseValor = a;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            foreach (var item in divisor.Divisores)
            {
                if (item % item == 0)
                    divisor.DivisoresPrimos.Add(item);
            }

            return divisor;
        }
    }
}
