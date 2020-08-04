using DecompositorNumerico.Dominio;
using System;
using System.Collections.Generic;

namespace DecompositorNumerico.Servico
{
    public class Divisores
    {
        /// <summary>
        /// Realiza as operações para obter os divisores e os numeros primos
        /// </summary>
        /// <param name="valor">Valor informado pelo usuário</param>
        /// <returns></returns>
        public Divisor Calcular(int valor)
        {
            double baseValor = valor;
            Divisor divisor = new Divisor();
            List<int> divisores = new List<int>();
            List<int> divisoresPrimos = new List<int>();

            for (int i = 1; i <= valor; i++)
            {
                //verifica se o resultado da divisão é um inteiro, se for o numero é um divisor
                double a = baseValor / i;
                if (Int32.TryParse(a.ToString(), out int inteiro))
                    divisores.Add(i);

            }

            foreach (var item in divisores)
            {
                if (item < 2)//1 não é considerado número primo
                    continue;
                else if (item == 2)//2 é um número primo
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

                //Número primo é dividido por 1 e por ele mesmo
                //Se cont for igual a 2 o numero é primo
                if (cont == 2)
                    divisoresPrimos.Add(item);

            }

            divisor.Divisores = divisores;
            divisor.DivisoresPrimos = divisoresPrimos;

            return divisor;
        }
    }
}
