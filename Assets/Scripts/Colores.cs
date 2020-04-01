using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.Events;

public class Colores : MonoBehaviour
{
    public KeywordRecognizer keywordRecognizer;
    public string[] palabras;
    public Color[] colores;
    private string palabraActual;
    private int indiceAnterior = -1;

    // Start is called before the first frame update
    void Start()
    {
        CambiarColor();
        
        keywordRecognizer = new KeywordRecognizer(palabras);
        keywordRecognizer.OnPhraseRecognized += reconocer;
        keywordRecognizer.Start();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void reconocer(PhraseRecognizedEventArgs escuchado)
    {
        string palabra = escuchado.text;
        if(palabra == palabraActual)
        {
            //Le pego
            CambiarColor();
        }
        else
        {
            //No le pego

        }
    }

    public void CambiarColor()
    {
        int indice;
        do {
            indice = Random.Range(0, palabras.Length);
        } while (indiceAnterior == indice);

        indiceAnterior = indice;

        palabraActual = palabras[indice];
        Camera.main.backgroundColor = colores[indice];
    }
}
