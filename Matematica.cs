using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using System.IO;



class Matematica
{

    int numeroInteiro;

    public Matematica(int numeroInteiro)
    {
        this.numeroInteiro = numeroInteiro;
    }

    public bool EhPalidromo()
    {
        int aux = 0, numero = numeroInteiro;

        while( numero > 0)
        {
            int quociente = numero / 10;
            int resto = numero - quociente * 10;
            aux = aux * 10 + resto;
            numero = quociente;
        }

        return (aux == numeroInteiro);
    }

    public int Fatorial()
    {
        var oFatorial = new Produtorio();
        var umContador = new Contador(1, numeroInteiro, 1);

        while(umContador.Prosseguir())
        {
            oFatorial.Multiplicar(umContador.Valor);
            umContador.Contar();
        }

        return Convert.ToInt32(oFatorial.Valor);
    }

    public string Divisores()
    {
        string lista = "";
        int metadeNumero = numeroInteiro / 2;
        var possivelDivisor = new Contador(2, metadeNumero, 1);

        while(possivelDivisor.Prosseguir())
        {
            int quociente = numeroInteiro / possivelDivisor.Valor;
            int resto = numeroInteiro - quociente * possivelDivisor.Valor;
            if (resto == 0)
                lista = lista + Convert.ToString(possivelDivisor.Valor);
            possivelDivisor.Contar();

        }

        return "1, " + lista + numeroInteiro;
    }

    

    public int mdc(int outroNumero)
    {
        int resto = 0, oMDC = 0;
        int dividendo = numeroInteiro;
        int divisor = outroNumero;
        do
        {
            int quociente = dividendo / divisor;
            resto = dividendo - divisor * quociente;

            if (resto == 0)
                oMDC = divisor;
            dividendo = divisor;
            divisor = resto;
        }
        while (resto != 0);
        return oMDC;
    }

    public double Elevado(double a)
    {
        var umContador = new Contador(1, numeroInteiro, 1); // instancia um objeto da classe contador que terá como valor incial 1, valor final um número x digitado pelo usuário e o passo1

        var umMultiplicador = new Produtorio();  // instancia um objeto da classe Produtório

        while (umContador.Prosseguir()) // esse comando fará com que após a realização dos comandos entre chaves, o fluxo de execução retorne a ele
                                        // o método entre parenteses fará com que se o contador for menor ou igual a número digitado pelo usuário o fluxo de execução entre nos comandos entre parêntese.
        {
            umMultiplicador.Multiplicar(a); // esse método fa´ra com que o valor presente na variável "a" seja multiplicado pelo valor presente na variável "oProduto".

            umContador.Contar();
        }

        return umMultiplicador.Valor;  //  retorna o valor que está na variável "oProduto"
    }

    public double SomaDivisores()
    {
        int metadeNumero = numeroInteiro / 2;
        var possivelDivisor = new Contador(2, metadeNumero, 1);
        var umSomador = new Somatoria();

        while (possivelDivisor.Prosseguir())
        {
            int quociente = numeroInteiro / possivelDivisor.Valor;
            int resto = numeroInteiro - quociente * possivelDivisor.Valor;
            if (resto == 0)
                umSomador.Somar(possivelDivisor.Valor);
            possivelDivisor.Contar();

        }

        return (umSomador.Valor + 1 + numeroInteiro);
    }

    public bool EhPerfeito()
    {
        double somaDivisores = SomaDivisores() - numeroInteiro;

        if (somaDivisores == numeroInteiro)
            return true;
        else
            return false;
    }

    public bool EhPrimo()
    {
        if (Divisores() == $"1, {numeroInteiro}")
            return true;
        else
            return false;
    }

    public int MMC(int outroValor)
    {
        int oMMC = 0;
        int dividendo1 = numeroInteiro;
        int dividendo2 = outroValor;
        int quociente1 = 0;
        int quociente2 = 0; 

        var umContador = new Contador(2, numeroInteiro * outroValor, 1);

        var umMultiplicador = new Produtorio();

        while(dividendo1 != 1 || dividendo2 != 1 && umContador.Prosseguir())
        {
            numeroInteiro = umContador.Valor;

            if (Divisores() == $"1, {umContador.Valor}") // O contador é primo? 
            {
       
                while (dividendo1 % umContador.Valor == 0 || dividendo2 % umContador.Valor == 0)
                {
                    quociente1 = dividendo1 / umContador.Valor;
                    quociente2 = dividendo2 / umContador.Valor;

                    umMultiplicador.Multiplicar(umContador.Valor);

                    if (dividendo1 % umContador.Valor == 0)
                        dividendo1 = quociente1;

                    if (dividendo2 % umContador.Valor == 0)
                        dividendo2 = quociente2;

                    quociente1 = 0;

                    quociente2 = 0;
                }
            }
            else
            {
                quociente1 = 0;
                quociente2 = 0;
            }

            umContador.Contar();
            
        }

        oMMC = Convert.ToInt32(umMultiplicador.Valor);

        return oMMC;
    }

    public double Cosseno(double anguloEmGraus)
    {
        double cosseno = 1;

        double anguloEmRadianos = (PI * anguloEmGraus) / 180.0; // Converte o valor do angulo em graus para o angulo em Radianos


        var umContador1 = new Contador(2, 2 * numeroInteiro, 2);

        var umSomador = new Somatoria();

        int positivoNegativo = -1;

        while (umContador1.Prosseguir())
        {
            var umContador2 = new Contador(1, umContador1.Valor, 1);
            var oFatorial = new Produtorio();

            while (umContador2.Prosseguir())
            {
                oFatorial.Multiplicar(umContador2.Valor);

                umContador2.Contar();
            }

            umSomador.Somar(positivoNegativo * (Pow(anguloEmRadianos, umContador1.Valor) / oFatorial.Valor));

            positivoNegativo = positivoNegativo * (-1);

            umContador1.Contar();
        }
        

        cosseno = cosseno + umSomador.Valor;

        return cosseno;
    }

    public double Pi()
    {
        double pi;
        
        var umContador = new Contador(1, numeroInteiro, 2);

        
        var umSomador = new Somatoria();

        int positivoNegativo = 1;

        while(umContador.Prosseguir())
        {
            umSomador.Somar(positivoNegativo  / Pow(umContador.Valor, 3));
            positivoNegativo = positivoNegativo * -1;
            umContador.Contar();
        }

        pi = Pow(32 * umSomador.Valor, (1.0 / 3.0));

        return pi;
    }

    public int ConverterBasesNumericas(int baseNumerica)
    {
        int dividendo = numeroInteiro;
        int divisor = baseNumerica;
        int quociente = 0;
        int resto = 0;
        int soma;

        int numeroBinario = 0;

        var umContador = new Contador(0, int.MaxValue, 1);

        var umSomador = new Somatoria();

        while (quociente != 1 && dividendo != 1)
        {

            quociente = dividendo / baseNumerica;
            resto = dividendo - quociente * baseNumerica;

            umSomador.Somar(resto * Pow(10, umContador.Valor));

            dividendo = quociente;

            umContador.Contar();

        }

        umSomador.Somar(1 * Pow(10, umContador.Valor));

        numeroBinario = Convert.ToInt32(umSomador.Valor);

        return numeroBinario;
    }

    public void Trocar( int SegundoValor)
    {
        int primeiroValor = numeroInteiro;
        int tercerioValor = primeiroValor;
        primeiroValor = SegundoValor;
        SegundoValor = tercerioValor;

    }

    public double RaizQuadrada()
    {
        double g = numeroInteiro;

        double x = 0.5 * (g + numeroInteiro / g);

        while (g / x - 1 > 0.0001)
        {
            g = x;

            x = 0.5 * (g + numeroInteiro / g);
        }

        return x;
    }


    public int ParaBinario()
    {
        int dividendo = numeroInteiro;
        int quociente = 0;
        int resto = 0;
        int soma;
       
        int numeroBinario = 0;

        var umContador = new Contador(0, int.MaxValue, 1);

        var umSomador = new Somatoria();

        while (quociente != 1 && dividendo != 1) 
        {
           
            quociente = dividendo / 2;
            resto = dividendo - quociente * 2;

            umSomador.Somar(resto * Pow(10, umContador.Valor));

            dividendo = quociente;

            umContador.Contar();

        }

        umSomador.Somar(1 * Pow(10, umContador.Valor));

        numeroBinario = Convert.ToInt32(umSomador.Valor);

        return numeroBinario;
    }

    public List<int> Fibonacci()
    {
        var lista = new List<int>(numeroInteiro) {1, 1};  // instância um objeto da classe List, que já se inicia com uma lista cujos os componenetes os dois primeiros números da série de Fibonnaci

        int numeroAnterior = 1; // essa variável guardará o número anterior da série pois ele precisará ser usado para calcular o próximo número da série
        int numeroAnteriorAoAnterior = 1; // penúltimo número da série que também será usado para calcular o próximo número

        for(int contador = 2; lista.Count() <= numeroInteiro; contador++)
        {
            if(contador == numeroAnterior + numeroAnteriorAoAnterior) // o contador é igual a soma dos dois números anteriores da sequência?
                                                                      // Se for verdadeiro, foi encontrado o prómixo número da série Fibonacci
            {
                numeroAnteriorAoAnterior = numeroAnterior; // Como foi encontrado o próximo número, então agora o penúltimo número da sequência passa a ser o que antes era o último número
                numeroAnterior = contador; // e o último número da sequência passa a ser o novo número encontrado

                lista.Add(contador); // adiciona a lista de números Fibonacci o novo número da série encontrado
            }
        }

        return lista;
    }

    public  double CalculoMMC(int outroValor)
    {
        int dividendo1 = numeroInteiro;
        int dividendo2 = outroValor;

        int quociente1 = 0;
        int quociente2 = 0;

        var oMMC = new Produtorio();

        for (int contador = 2; dividendo1 != 1 || dividendo2 != 1; contador++)
        {
            numeroInteiro = contador;
            if(EhPrimo())
            {
             
                while (dividendo1 % contador == 0 || dividendo2 % contador == 0)
                {
                    oMMC.Multiplicar(contador);

                    if (dividendo1 % contador == 0)
                    {
                        quociente1 = dividendo1 / contador;
                        dividendo1 = quociente1;
                        quociente1 = 0;
                    }

                    if (dividendo1 % contador == 0)
                    {
                        quociente2 = dividendo2 / contador;
                        dividendo2 = quociente2;
                        quociente2 = 0;
                    }
                }
            }
                
        }

        return oMMC.Valor;
    }


    public void LerDados(string nomeArquivo)
    {
        var leitorDeDados = new StreamReader(nomeArquivo);

        string linha, classe, registroAcademico;
        double nota;

        while(!leitorDeDados.EndOfStream)
        {
            linha = leitorDeDados.ReadLine();

            classe = linha.Substring(0, 6);
            registroAcademico = linha.Substring(6, 5);
            nota = int.Parse(linha.Substring(11, 4));
        }

    }
       
   


}

    


