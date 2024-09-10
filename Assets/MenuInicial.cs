using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicial : MonoBehaviour
{
    public void Jugar()
    {
        Debug.Log("Jugar");
    }

    public void Instrucciones()
    {
        Debug.Log("Instrucciones");
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }
}
