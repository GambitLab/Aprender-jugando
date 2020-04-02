using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.Events;

public class Animales : MonoBehaviour
{
    private ReconocimientoVoz reconocimiento;

    public string[][] palabras = { null,
                                   new string[] { "salir" } };

    private string[] acciones = { "EscuchadoAnimal",
                                 "Salir" };

    public Sprite[] animales;
    public string[] animalesLetras;

    private string palabraActual;
    public Sprite imagenActual;

    private int indiceAnterior = -1;

    // Start is called before the first frame update
    void Start()
    {
        palabras[0] = animalesLetras;
        reconocimiento = new ReconocimientoVoz(palabras, acciones, this);
        CambiarAnimal();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EscuchadoAnimal()
    {
        string palabra = reconocimiento.reconocido;
        if (palabra == palabraActual)
        {
            //Le pego
            CambiarAnimal();
        }
        else
        {
            //No le pego
            Debug.Log("sos malisimo, pa tu casa");
        }
    }

    public void CambiarAnimal()
    {
        int indice;
        do
        {
            indice = Random.Range(0, palabras[0].Length);
        } while (indiceAnterior == indice);

        indiceAnterior = indice;

        palabraActual = palabras[0][indice];
        
    }

    public void Salir()
    {
        Debug.Log("salir");
    }
}
