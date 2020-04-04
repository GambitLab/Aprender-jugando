using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Windows.Speech;

public class ReconocimientoVoz
{
    public KeywordRecognizer keywordRecognizer;
    public string reconocido;
    public Dictionary<string, UnityAction> diccionario = new Dictionary<string, UnityAction>();


    public ReconocimientoVoz(string[][] keywords, string[] palabrasAcciones, object instance)
    {
        //Convertir las palabras de palabrasAcciones a funcion
        UnityAction[] acciones = new UnityAction[palabrasAcciones.Length];
        for(int i = 0; i < palabrasAcciones.Length; i++)
        {
            acciones[i] = Utilidades.stringFunctionToUnityAction(instance, palabrasAcciones[i]);
        }

        //Agregar al diccionario una funcion para a cada palabra
        List<string> palabras = new List<string>();
        for (int i = 0; i < keywords.Length; i++)
        {
            for(int j = 0; j < keywords[i].Length; j++)
            {
                diccionario.Add(keywords[i][j], acciones[i]);
                palabras.Add(keywords[i][j]); //El reconocimiento de voz pide un vector de string, hay que convertir la matriz a vector
            }
        }

        //Iniciar el reconocimiento de voz
        keywordRecognizer = new KeywordRecognizer(palabras.ToArray());
        keywordRecognizer.OnPhraseRecognized += reconocer; //La funcion que se va a ejecutar cada vez que se reconozca algo
        keywordRecognizer.Start();
    }

    public void reconocer(PhraseRecognizedEventArgs escuchado)
    {
        reconocido = escuchado.text;
        UnityAction accion;
        diccionario.TryGetValue(reconocido, out accion); //Consigue la funcion asociada a esa palabra en el diccionario
        accion.Invoke(); //Asi se llama a la funcion guardada dentro del UnityAction
    }
}