using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    private ReconocimientoVoz reconocimiento;

    private string[][] palabras = { null,
                                    new string[] { "salir" } };

    private string[] acciones = { "CambiarEscena",
                                 "Salir"};
    public string[] escenasPalabras;
    public string[] nombreEscenas;

    // Start is called before the first frame update
    void Start()
    {
        List<string> listaPalabras = new List<string>();
        for (int i = 0; i < escenasPalabras.Length; i++)
        {
            if (escenasPalabras[i].Contains("-"))
            {
                string[] vector = escenasPalabras[i].Split('-');
                foreach (string item in vector)
                {
                    listaPalabras.Add(item);
                }
            }
            else
            {
                listaPalabras.Add(escenasPalabras[i]);
            }
        }

        palabras[0] = listaPalabras.ToArray();
        reconocimiento = new ReconocimientoVoz(palabras, acciones, this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarEscena()
    {
        string palabra = reconocimiento.reconocido;
        for(int i = 0; i < escenasPalabras.Length; i++)
        {
            if (escenasPalabras[i].Contains(palabra))
            {
                SceneManager.LoadScene(nombreEscenas[i]);
                break;
            }
        }
    }

    public void Salir()
    {
        Debug.Log("salir");
    }
}
