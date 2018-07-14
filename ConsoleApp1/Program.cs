using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilizacaoRegressaoLinear
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] Peso_X = { 49.0, 65.0, 45.0, 40.0, 55.0, 45.0, 44.0, 47.0, 50.0, 56.0 };
            double[] Carcaca_Y = { 24.0, 40.0, 25.0, 23.5, 33.5, 22.0, 22.5, 23.5, 25.0, 35.0 }; 

            RegressaoLinear regressao = new RegressaoLinear(Peso_X, Carcaca_Y);

            Console.Write("Média X: " + regressao.Med_x);
            Console.Write("\nMédia Y: " + regressao.Med_Y);
            Console.Write("\nCCL: "+ regressao.CoeficienteCorrelacaoLinear);
            Console.Write("\nCoeficiente Angular: " + regressao.GetCoeficienteAngular());
            Console.Write("\nCoeficiente Linear: " + regressao.GetCoeficienteLinear());
            Console.Write("\nCoeficiente Determinacao: " + regressao.CoeficenteDeterminacao);
            Console.Read();
        }
    }
}
