using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private bool pausar = false;

    [Header("UI")]
    private GameObject avisos;

    [Header("efectosSonido")]
    private AudioSource sfx;
    
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

        sfx = GetComponent<AudioSource>();

        cuadradoP1_0.SetActive(false);
        cuadradoP1_1.SetActive(false);
        cuadradoP2_0.SetActive(false);
        cuadradoP2_1.SetActive(false);

        avisos = GameObject.Find("Avisos");
        if (avisos != null)
        {
            avisos.SetActive(false);
        }
        else
        {
            Debug.Log("Avisos Null");
        }
        StartCoroutine(empezarRound());
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
                    StartCoroutine(GestionarRound("Jugador 2", ganoP2));
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
                    StartCoroutine(GestionarRound("Jugador 2", ganoP2));
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
                    StartCoroutine(GestionarRound("Jugador 1", ganoP1));
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
                    StartCoroutine(GestionarRound("Jugador 1", ganoP1));
                    break;

                default:
                    break;
            }
        }
    }
    IEnumerator GestionarRound(string ganador, int gan)
    {
        if (gan == 0)
        {
            movPers[0].setPausa(true);
            movPers[1].setPausa(true);
            avisos.SetActive(true);
            avisos.GetComponent<Text>().text = "¡" + ganador + " ganó el round!";
            yield return new WaitForSeconds(2); // Pausa de 2 segundos para mostrar el ganador
            avisos.SetActive(false); // Ocultar el mensaje del ganador del round
        }

        if (seAcaboLaPelea)
        {
            avisos.SetActive(true);
            avisos.GetComponent<Text>().text = "¡"+ganador + " es el ganador!";
            yield return new WaitForSeconds(1.5f); // Pausa de 2 segundos antes de volver al menú
            SceneManager.LoadScene("Menu");
        }
        else
        {
            avisos.SetActive(true);
            for (int i = 3; i > 0; i--)
            {
                
                avisos.GetComponent<Text>().text = "" + (i);
                yield return new WaitForSeconds(1);
            }


            avisos.GetComponent<Text>().text = "FIGHT!";
            sfx.Play();
            yield return new WaitForSeconds(2); // Pausa de 2 segundos antes de reiniciar el round
            movPers[0].setPausa(false);
            movPers[1].setPausa(false);
            avisos.SetActive(false);
        }
    }

    IEnumerator empezarRound()
    {
        movPers[0].setPausa(true);
        movPers[1].setPausa(true);
        avisos.SetActive (true);
        for(int i = 3; i > 0;i--)
        {
            avisos.GetComponent<Text>().text = "" + (i);
            yield return new WaitForSeconds(1);
        }
        avisos.GetComponent<Text>().text = "FIGHT!";
        sfx.Play();
        yield return new WaitForSeconds(2); // Pausa de 2 segundos antes de reiniciar el round
        movPers[0].setPausa(false);
        movPers[1].setPausa(false);
        avisos.SetActive(false);
    }
}
