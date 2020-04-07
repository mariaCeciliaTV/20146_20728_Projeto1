using System;

class Contador
{
    protected
    int cont,
        valorInicial,
        valorFinal,
        passo;

    public Contador(int i, int f, int p)
    {
        valorInicial = cont = i;
        valorFinal = f;
        passo = p;
    }

    public void Iniciar()
    {
        cont = valorInicial;
    }

    public bool Prosseguir()
    {
        if (cont <= valorFinal)
            return true;
        else
            return false;

        // return cont <= valorFinal;
    }

    public void Contar()
    {
        if (Prosseguir())  // se não acabou a contagem
            cont += passo; // incrementa o contador
    }

    public int Valor
    {
        get => cont;
    }

}