using System;
using System.Linq;

public class CoeficenteDeterminacao
{
    private RegressaoLinear Dados { get; set; }
    private double SomaQuadradoTotal { get; set; }
    private double SomaQuadradoErros { get; set; }
    private double SomaQuadradosRegressao { get; set; }
    public double CoeficienteDeterminacao { get; set; }

    public CoeficenteDeterminacao (RegressaoLinear dados)
    {
        this.Dados = dados;
        this.SomaQuadradoTotal = CalcularSomaQuadradoTotal();
        this.SomaQuadradoErros = CalcularSomaQuadradoErro();
        this.SomaQuadradosRegressao = CalcularSomaQuadradosRegressao();
        this.CoeficienteDeterminacao = this.SomaQuadradosRegressao / this.SomaQuadradoTotal;
    }

    private double CalcularSomaQuadradoTotal()
    {
        double somaQuadradoTotal = 0;
        foreach (double y in this.Dados.ValoresY)
        {
            somaQuadradoTotal += Math.Pow((y - this.Dados.Med_Y),2);
        }
        return somaQuadradoTotal;
    }

    private double CalcularSomaQuadradoErro()
    {
        double somaQuadradoErro = 0;
        for (int i =0; i< this.Dados.ValoresY.Count(); i++ )
        {
            somaQuadradoErro += Math.Pow((this.Dados.ValoresY[i] - this.Dados.CalcularPrevisao(this.Dados.ValoresX[i])), 2);
        }
        return somaQuadradoErro;
    }

    private double CalcularSomaQuadradosRegressao()
    {
        return this.SomaQuadradoTotal - this.SomaQuadradoErros;
    }
}
