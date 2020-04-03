using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Numeros : MonoBehaviour
{
    private ReconocimientoVoz reconocimiento;

    public string[][] palabras = { null,
                                   new string[] { "salir" } };

    private string[] acciones = { "EscuchadoNumero",
                                 "Salir" };

    public Text textoNumeros;
    public string[] numeros;
    public string[] numerosLetras;

    private string palabraActual;
    private int indiceAnterior = -1;

    // Start is called before the first frame update
    void Start()
    {
        palabras[0] = numerosLetras;
        reconocimiento = new ReconocimientoVoz(palabras, acciones, this);
        CambiarNumero();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EscuchadoNumero()
    {
        string palabra = reconocimiento.reconocido;
        if (palabra == palabraActual)
        {
            //Le pego
            CambiarNumero();
        }
        else
        {
            //No le pego
            Debug.Log("sos malisimo, pa tu casa");
        }
    }

    public void CambiarNumero()
    {
        int indice;
        do
        {
            indice = Random.Range(0, palabras[0].Length);
        } while (indiceAnterior == indice);

        indiceAnterior = indice;

        palabraActual = palabras[0][indice];
        textoNumeros.text = numeros[indice];
       
    }

    public void Salir()
    {
        Debug.Log("salir");
    }
}
