using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Produtorio
{
    double oProduto;
    int quantosMultiplicados;

    public Produtorio()
    {
        oProduto = 1;
        quantosMultiplicados = 0;
    }

    public void Multiplicar(double valor)
    {
        oProduto *= valor;   // oProduto = oProduto * valor
        quantosMultiplicados++;
    }

    public double MediaGeometrica()
    {
        if (quantosMultiplicados <= 0)
            throw new Exception("Impossível calcular média geométrica!");

        if (quantosMultiplicados % 2 == 0 &&
            oProduto < 0)
            throw new Exception("Raiz par de valor negativo não pode ser calculada no momento.");

        return Math.Pow(oProduto, 1.0 / quantosMultiplicados);
    }

    public double Valor
    {
        get => oProduto;
    }


}

