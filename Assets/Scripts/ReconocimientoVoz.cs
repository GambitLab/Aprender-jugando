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


    public ReconocimientoVoz(string[][] keywords, string[] palabrasAcciones, Object instance)
    {
        UnityAction[] acciones = new UnityAction[palabrasAcciones.Length];
        for(int i = 0; i < palabrasAcciones.Length; i++)
        {
            acciones[i] = Utilidades.stringFunctionToUnityAction(instance, palabrasAcciones[i]);
        }

        List<string> palabras = new List<string>();
        for (int i = 0; i < keywords.Length; i++)
        {
            for(int j = 0; j < keywords[i].Length; j++)
            {
                diccionario.Add(keywords[i][j], acciones[i]);
                palabras.Add(keywords[i][j]);
            }
        }

        keywordRecognizer = new KeywordRecognizer(palabras.ToArray());
        keywordRecognizer.OnPhraseRecognized += reconocer;
        keywordRecognizer.Start();
    }

    public void reconocer(PhraseRecognizedEventArgs escuchado)
    {
        reconocido = escuchado.text;
        UnityAction accion;
        diccionario.TryGetValue(reconocido, out accion);
        accion.Invoke();
    }
}