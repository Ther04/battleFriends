using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golpes : MonoBehaviour
{
    [Header("contadores de combos")]
    private int combo1 = 0;

    [Header("condicionales")]
    public bool atacando = false;

    [Header("animacion")]
    public Animator animacion;
    public KeyCode golpeBasico = KeyCode.Z;
    public KeyCode patadaBasica = KeyCode.X;

    [Header("sonidos Animacion")]
    public AudioSource SonidoGolpe;
    public AudioClip[] miniSonidos;
    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        combos();
        Debug.Log(combo1);
    }


    public void empezarCombo()
    {
        //atacando = false;
        if(combo1 < 3)
        {
            combo1++;
        }
    }

    public void finalizarCombo()
    {
        //atacando = false;
        combo1 = 0;
    }

    void combos()
    {
        //combo golpe 1
        if (Input.GetKeyDown(golpeBasico) && !atacando)
        {
            //atacando = true;
            animacion.SetTrigger("combo1_"+combo1);
            
        }

        if (Input.GetKeyDown(patadaBasica))
        {
            animacion.SetTrigger("patada_1");
        }
    }
}
