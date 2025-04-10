using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    private Animator animacion;
    public KeyCode golpeBasico = KeyCode.Z;
    public KeyCode patadaBasica = KeyCode.X;

    [Header("sonidos Animacion")]
    public AudioSource SonidoGolpe;
    public AudioClip[] miniSonidos;

    [Header("Jugador")]
    [SerializeField] private string nombre;
    private movimientoScript movimiento;
    private bool puedeDefender = true;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        movimiento = GameObject.FindGameObjectWithTag(nombre).GetComponent<movimientoScript>();
        SonidoGolpe = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!movimiento.getCombateFin() && !movimiento.getPausa())
        {
            combos();
        }
        
    }

    private void FixedUpdate()
    {
        
    }

    public void empezarCombo()
    {
        if(!finalCombo)
        {
            //UnityEngine.Debug.Log(combo1);
            atacando = false;
            if (combo1 < 3)
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
        Cooldown.empezarCooldown();
        atacando = false;
        finalCombo = false;
        combo1 = 0;
        combo2 = 0;
        movimiento.cooldownDefensa();
        puedeDefender = true;

    }

    public void terminoDefensa()
    {
        Cooldown.empezarCooldown();
        atacando = false;
        finalCombo = false;
        combo1 = 0;
        combo2 = 0;
        puedeDefender = true;
    }

    public void noPuedeGolpear() 
    {
        atacando = true;
    }

    public void puedeGolpear()
    {
        atacando = false;
        finalizarCombo();
    }

    void combos()
    {
        if(Cooldown.noPuedeGolpear) return;
        //combo golpe 1
        if (Input.GetKeyDown(golpeBasico) && !atacando)
        {
            atacando = true;
            puedeDefender = false;
            animacion.SetTrigger("combo1_"+combo1);
            SonidoGolpe.clip = miniSonidos[combo1];
            SonidoGolpe.Play();
            //tomarDamage();
        }

        if (Input.GetKeyDown(patadaBasica) && !movimiento.isAgachado() && !atacando)
        {
            atacando = true;
            puedeDefender = false;
            animacion.SetTrigger("patada1_"+combo2);
            SonidoGolpe.clip = miniSonidos[3];
            SonidoGolpe.Play();
        }
        if(Input.GetKeyDown(patadaBasica) && movimiento.isAgachado() && !atacando)
        {
            atacando= true;
            puedeDefender = false;
            animacion.SetTrigger("patadaBaja");
            SonidoGolpe.clip = miniSonidos[4];
            SonidoGolpe.Play();
        }
    }

    public int getCombo1() {  return combo1; }

    public bool getPuedeDefender() 
    {
        return puedeDefender; 
    }
}
