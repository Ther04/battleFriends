using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class manejoRound : MonoBehaviour
{
    [Header("rounds")]
    private GameObject cuadradoP1_0;
    private GameObject cuadradoP1_1;
    private GameObject cuadradoP2_0;
    private GameObject cuadradoP2_1;

    [Header("vida/Ganador")]
    private barraDeVida[] barrasPersonajes = new barraDeVida[2];
    private int ganoP1 = 0;
    private int ganoP2 = 0;

    [Header("personajes")]
    private movimientoScript[] movPers = new movimientoScript[2];
    private instanciarPlayer posicionJugadores;
    private bool seAcaboLaPelea = false;

    // Start is called before the first frame update
    void Start()
    {
        cuadradoP1_0 = GameObject.Find("Cuadrado1_0");
        cuadradoP1_1 = GameObject.Find("Cuadrado1_1");
        cuadradoP2_0 = GameObject.Find("Cuadrado2_0");
        cuadradoP2_1 = GameObject.Find("Cuadrado2_1");

        barrasPersonajes[0] = GameObject.FindGameObjectWithTag("Player").GetComponent<barraDeVida>();
        barrasPersonajes[1] = GameObject.FindGameObjectWithTag("Enemy").GetComponent<barraDeVida>();

        movPers[0] = GameObject.FindGameObjectWithTag("Principal").GetComponent<movimientoScript>();
        movPers[1] = GameObject.FindGameObjectWithTag("Secundario").GetComponent<movimientoScript>();

        posicionJugadores = GameObject.Find("InstanciarPersonajes").GetComponent<instanciarPlayer>();

        cuadradoP1_0.SetActive(false);
        cuadradoP1_1.SetActive(false);
        cuadradoP2_0.SetActive(false);
        cuadradoP2_1.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        comprobarVida();
    }
    
    void comprobarVida()
    {
        if(barrasPersonajes[0].vida <= 0 )
        {
            switch (ganoP2) 
            {
                case 0:
                    cuadradoP2_0.SetActive(true);
                    barrasPersonajes[0].vida = 100f;
                    barrasPersonajes[1].vida = 100f;
                    movPers[0].reestablecerPosicion(posicionJugadores.posP1);
                    movPers[1].reestablecerPosicion(posicionJugadores.posP2);
                    ganoP2++;

                    break;

                case 1:
                    cuadradoP2_1.SetActive(true);
                    seAcaboLaPelea = true;
                    movPers[0].terminoCombate(seAcaboLaPelea);
                    movPers[1].terminoCombate(seAcaboLaPelea);
                    break;

                default:
                    break;
            }
        }else if (barrasPersonajes[1].vida <= 0 )
        {
            switch (ganoP1)
            {
                case 0:
                    cuadradoP1_0.SetActive(true);
                    barrasPersonajes[0].vida = 100f;
                    barrasPersonajes[1].vida = 100f;
                    movPers[0].reestablecerPosicion(posicionJugadores.posP1);
                    movPers[1].reestablecerPosicion(posicionJugadores.posP2);
                    ganoP1++;
                    break;

                case 1:
                    cuadradoP1_1.SetActive(true);
                    seAcaboLaPelea = true;
                    movPers[0].terminoCombate(seAcaboLaPelea);
                    movPers[1].terminoCombate(seAcaboLaPelea);
                    break;

                default:
                    break;
            }
        }
    }
}
