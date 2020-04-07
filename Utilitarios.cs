using System;
using static System.Console;

public static class Utilitarios
{
    public static void WriteXY(int col, int lin, string texto)
    {
        SetCursorPosition(col, lin);
        Write(texto);
    }
    public static void EsperarEnter()
    {
        WriteLine("\nPressione [Enter] para prosseguir");
        ReadLine();
    }
}