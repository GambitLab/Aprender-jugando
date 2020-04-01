using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;

public abstract class ReconocimientoVoz : MonoBehaviour
{

    
    public Dictionary<string, UnityAction> diccionario = new Dictionary<string, UnityAction>();

    public ReconocimientoVoz(string[] keywords)
    {
        
    }

    
}