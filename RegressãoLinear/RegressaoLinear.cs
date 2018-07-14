using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Cálculos retirados do link https://edisciplinas.usp.br/pluginfile.php/1479289/mod_resource/content/0/regr_lin.pdf
/// </summary>
public class RegressaoLinear
{
    #region Variaveis
    //Média dos valores de x
    public double Med_x { get; set; }
    
    //Média dos valores de y
    public double Med_Y { get; set; }
    
    //Valores de X
    public double[] ValoresX { get; set; }
    
    //Valores de Y
    public double[] ValoresY { get; set; }
    
    //Desvio Padrão de X
    public double DesvioP_x { get; set; }
    
    //Desvio Padrão de Y
    public double DesvioP_Y { get; set; }
    
    //Coeficiente de correlação linear
    public double CoeficienteCorrelacaoLinear { get; set; }
    
    //Soma de i=1 até n  ((X(i) - Med_X) * (Y(i) - Med_Y))
    private double XY { get; set; }

    //Coeficiente de Determinacao
    public double CoeficenteDeterminacao {
        get
        {
            CoeficenteDeterminacao coeficienteDeterminacao = new CoeficenteDeterminacao(this);
            return coeficienteDeterminacao.CoeficienteDeterminacao;
        }
    }
    #endregion

    public RegressaoLinear (double[] X, double[] Y)
    {
        this.ValoresX = X;
        this.ValoresY = Y;
        CalculaMedia();
        CalcularDesvioPadrao();
        CalcularXY();
        CalcularCCL();
    }

    private void CalcularMedia()
    {
        double resultX = 0, resultY = 0;
        foreach(double valor in ValoresX)
        {
            resultX += valor;
        }
        this.Med_x = (ValoresX.Count() == 0)? 0 :  resultX/ValoresX.Count();

        foreach (double valor in ValoresY)
        {
            resultY += valor;
        }
        this.Med_Y = (ValoresY.Count() == 0) ? 0 : resultY / ValoresY.Count();
    }

    private void CalcularDesvioPadrao()
    {
        double resultX = 0, resultY = 0;

        foreach(double valor in ValoresX)
        {
            resultX += Math.Pow((valor - this.Med_x), 2);
        }
        this.DesvioP_x = (ValoresX.Count() == 0) ? 0 : Math.Sqrt(resultX / ValoresX.Count());


        foreach (double valor in ValoresY)
        {
            resultY += Math.Pow((valor - this.Med_Y), 2);
        }
        this.DesvioP_Y = (ValoresY.Count() == 0) ? 0 : Math.Sqrt(resultY / ValoresY.Count());
    }
        
    //Soma de i=1 até n  ((X(i) - Med_X) * (Y(i) - Med_Y))
    private void CalcularXY()
    {
        double result = 0;
        for(int i = 0; i< this.ValoresX.Count(); i++)
        {
            result += (this.ValoresX[i] - this.Med_x) * (this.ValoresY[i] - this.Med_Y);
        }
    }

    private void CalcularCCL()
    {
        this.CoeficienteCorrelacaoLinear = this.XY / (this.DesvioP_x * this.DesvioP_Y * this.ValoresX.Count());
    }

    public double GetCoeficienteAngular()
    {
        double k = 0;
        for (int i = 0; i < this.ValoresX.Count(); i++)
        {
            k += (this.ValoresX[i]) * (this.ValoresY[i]);
        }
        k = k - (this.ValoresX.Count() * this.Med_x * this.Med_Y);

        double l = this.ValoresX.Count() * Math.Pow(this.DesvioP_x, 2);
        return k / l;
    }

    public double GetCoeficienteLinear()
    {
        return this.Med_Y - (this.Med_x * GetCoeficienteAngular());
    }

    public double CalcularPrevisao(double x)
    {
        return GetCoeficienteLinear() + GetCoeficienteAngular() * x;
    }

}

