using DecompositorNumerico.Dominio;
using System;
using System.Collections.Generic;

namespace DecompositorNumerico.Servico
{
    public class Divisores
    {
        public Divisor Calcular(int valor)
        {
            double baseValor = valor;
            Divisor divisor = new Divisor();
            List<int> divisores = new List<int>();
            List<int> divisoresPrimos = new List<int>();

            for (int i = 1; i <= valor; i++)
            {
                try
                {
                    double a = baseValor / i;
                    if (Int32.TryParse(a.ToString(), out int inteiro))
                        divisores.Add(i);
                }
                catch (Exception ex)
                {

                    continue;
                }
            }

            foreach (var item in divisores)
            {
                if (item < 2)
                    continue;
                else if (item == 2)
                {
                    divisoresPrimos.Add(item);
                    continue;
                }

                int cont = 0;

                for (int i = 1; i <= item; i++)
                {
                    if ((item % i == 0))
                        cont++;
                }

                if (cont == 2)
                    divisoresPrimos.Add(item);

            }

            divisor.Divisores = divisores;
            divisor.DivisoresPrimos = divisoresPrimos;

            return divisor;
        }
    }
}
