using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class controlVida : MonoBehaviour
{
    private Animator animator;
    private barraDeVida BarraDeVida;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        BarraDeVida = GetComponent<barraDeVida>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void damage(float damage)
    {
        BarraDeVida.vida -= damage;
        animator.SetTrigger("golpeado");
        Debug.Log(BarraDeVida.vida);
    }
}