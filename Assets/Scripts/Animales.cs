using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Image imagenActual;

    private int indiceAnterior = -1;

    // Start is called before the first frame update
    void Start()
    {
        List<string> listaPalabras = new List<string>();
        for(int i = 0; i < animalesLetras.Length; i++)
        {
            if (animalesLetras[i].Contains("-"))
            {
                string[] vector = animalesLetras[i].Split('-');
                foreach(string item in vector)
                {
                    listaPalabras.Add(item);
                }
            }
            else
            {
                listaPalabras.Add(animalesLetras[i]);
            }
        }

        palabras[0] = listaPalabras.ToArray();

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
        if (palabraActual.Contains(palabra))
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
            indice = Random.Range(0, animalesLetras.Length);
        } while (indiceAnterior == indice);

        indiceAnterior = indice;

        palabraActual = animalesLetras[indice];
        imagenActual.sprite = animales[indice];
    }

    public void Salir()
    {
        Debug.Log("salir");
    }
}
