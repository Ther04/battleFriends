using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golpes : MonoBehaviour
{
    [Header("Objeto Cooldown")]
    [SerializeField]private cooldown Cooldown;

    [Header("contadores de combos")]
    private int combo1 = 0;
    private int combo2 = 0;

    [Header("condicionales")]
    public bool atacando = false;
    private bool finalCombo = false;

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
        //Debug.Log(combo1);
    }

    private void FixedUpdate()
    {
        
    }

    public void empezarCombo()
    {
        if(!finalCombo)
        {
            atacando = false;
            if (combo1 < 2)
            {
                if (combo1 == 1)
                {
                    combo2 = 0;
                    finalCombo = true;
                }
                combo1++;
            }
        }
        
    }

    public void empezarCombo2()
    {
        if (!finalCombo)
        { 
        }
    }

    public void finalizarCombo()
    {
        atacando = false;
        finalCombo = false;
        combo1 = 0;
        combo2 = 0;
        Cooldown.empezarCooldown();
    }

    void combos()
    {
        if(Cooldown.noPuedeGolpear) return;
        //combo golpe 1
        if (Input.GetKeyDown(golpeBasico) && !atacando)
        {
            atacando = true;
            animacion.SetTrigger("combo1_"+combo1);
            
        }

        if (Input.GetKeyDown(patadaBasica))
        {
            animacion.SetTrigger("patada1_"+combo2);
        }
    }
}
