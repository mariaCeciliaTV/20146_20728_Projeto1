using System;

class Somatoria
{
    double aSoma;
    int quantosSomados;

    public Somatoria()
    {
        aSoma = 0;
        quantosSomados = 0;
    }

    public void Somar(double valor)
    {
        aSoma += valor;
        quantosSomados++;
    }

    public double MediaAritmetica
    {
        get
        {
            if (quantosSomados > 0)
               return aSoma / quantosSomados;

            throw new Exception("Divisão por zero!!!");
        }
    }

    public double Valor
    {
        get => aSoma;
    }

    public double Quantos
    {
        get => quantosSomados;
    }
}
