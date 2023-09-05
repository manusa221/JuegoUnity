using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class General //creamos un script generaral statico con estas variables
{
    private static int segundos = 10;
    private static int maxSegundos = 10;//variable para poder restaurar el valor
    private static int numPalomitasDestruidas = 0;


    //creamos los metodos get y setters

    public static int GetSegundos()
    {
        return segundos;
    }

    public static void SetSegundos(int s )
    {
        segundos = s;
    }

    public static int GetMaxSegundos()
    {
        return maxSegundos;
    }

    public static void SetMaxSegundos(int s)
    {
        maxSegundos = s;
    }


    public static int GetNumPalomitasDestruidas()
    {
        return numPalomitasDestruidas;
    }
    public static void SetNumPalomitasDestruidas(int p)
    {
        numPalomitasDestruidas = p;
    }
}
