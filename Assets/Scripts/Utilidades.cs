using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public static class Utilidades
{
    public static UnityAction stringFunctionToUnityAction(object target, string functionName)
    {
        UnityAction action = (UnityAction)Delegate.CreateDelegate(typeof(UnityAction), target, functionName);
        return action;
    }

    public static void cambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public static string[] convertirMatrizAVector(string[][] matriz)
    {
        List<string> palabras = new List<string>();
        for (int i = 0; i < matriz.Length; i++)
        {
            for (int j = 0; j < matriz[i].Length; j++)
            {
                palabras.Add(matriz[i][j]);
            }
        }

        return palabras.ToArray();
    }
}
