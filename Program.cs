using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
using static Utilitarios;
using System.IO;

namespace _20146_20728_Projeto1
{
    class Program
    {
       public static void EscolherOpcao()
        {
            int qualOpcao;

            do
            {
                WriteXY(2, 2, "Opções que podem ser escolhidas:");
                WriteXY(5, 5, "1 - MMC entre dois valores digitados");
                WriteXY(5, 6, "2 - Números Centrais");
                WriteXY(5, 7, "3 - Cálculos di pi");
                WriteXY(5, 8, "4 - Lista de númerosde Fibonacci");
                WriteXY(5, 9, "5 - Raiz quadrada de um número real digitado");
                WriteXY(5, 10, "6 - Processamento de dados armazenados em um arquivo de texto em disco");
                WriteXY(5, 11, "99 - Terminar este programa");
                WriteXY(2, 14, "Querido usuário, por favor, selecione alguma das opções desejadas:");
                qualOpcao = int.Parse(ReadLine());

                switch(qualOpcao)
                {
                    case 1: MMCEntreDoisValores(); break;
                    case 2: NumerosCentrais(); break;
                    case 3: CalculosDePi(); break;
                    case 4: ListaDeNumerosFibonnaci(); break;
                    case 5: RaizQuadradaNumeroReal(); break;
                    case 6: ProcessamentoDeDadosEmArquivoTexto(); break;
                }
            }
            while (qualOpcao != 99);
        }

        public static void MMCEntreDoisValores()
        {

        }

        public static void NumerosCentrais()
        {

        }

        public static void CalculosDePi()
        {

        }

        public static void ListaDeNumerosFibonnaci()
        {
            Clear();

            WriteXY(2, 2, "Série de Fibonacci");

            WriteXY(5, 5, "Querido usuário, por favor, informe a quantidade de números desejados na sequência:");
            int numeroInteiro = int.Parse(ReadLine());

            var umMatematico = new Matematica(numeroInteiro);

            Clear();

            WriteXY(2, 2, "Lista de Fibonnaci");

            WriteLine($"\n\n\n {umMatematico.Fibonacci()}");

            EsperarEnter();
        }

        public static void RaizQuadradaNumeroReal()
        {

        }

        public static void ProcessamentoDeDadosEmArquivoTexto()
        {

        }
        static void Main(string[] args)
        {
            EscolherOpcao();
        }
    }
}
