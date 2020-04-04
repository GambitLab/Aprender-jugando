using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.Events;

public class Colores : MonoBehaviour
{
    private ReconocimientoVoz reconocimiento;

    public string[][] palabras = { null,
                                   new string[] { "salir" } };
    
    private string[] acciones = { "EscuchadoColor",
                                 "Salir" };

    public Color[] colores;
    public string[] coloresLetras;

    private string palabraActual;
        private int indiceAnterior = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        palabras[0] = coloresLetras;
        reconocimiento = new ReconocimientoVoz(palabras, acciones, this);
        CambiarColor();      
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void EscuchadoColor()
    {
        string palabra = reconocimiento.reconocido;
        if(palabra == palabraActual)
        {
            //Le pego
            CambiarColor();
        }
        else
        {
            //No le pego
            Debug.Log("sos malisimo, pa tu casa");
        }
    }

    public void CambiarColor()
    {
        int indice;
        do {
            indice = Random.Range(0, palabras[0].Length);
        } while (indiceAnterior == indice);

        indiceAnterior = indice;

        palabraActual = coloresLetras[indice];
        Camera.main.backgroundColor = colores[indice];
    }

    public void Salir()
    {
        Debug.Log("salir");
    }
}
