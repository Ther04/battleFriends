using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuInicial : MonoBehaviour
{
    public GameObject firstButton;
    public GameObject secondButton;
    private bool buttonSelected = false;
    private bool pressed = true;
    void Update()
    {
        if (Input.anyKeyDown&&buttonSelected==false)
        {
            EventSystem.current.SetSelectedGameObject(firstButton);
            buttonSelected = true;
        }else if(Input.anyKeyDown && pressed==false)
        {
            EventSystem.current.SetSelectedGameObject(secondButton);
            pressed=true;
        }
    }
    public void Jugar()
    {
        Debug.Log("Jugar");
    }

    public void Instrucciones()
    {
        Debug.Log("Instrucciones");
        pressed = false;
        buttonSelected = true;
    }
    public void Volver() {
        Debug.Log("Menú");
        pressed = true;
        buttonSelected = false;
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }
}
