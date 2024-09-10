using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class controlVida : MonoBehaviour
{
    private Animator animator;
    private barraDeVida BarraDeVida;
    private movimientoScript mov;
    [SerializeField] private string tagNombre;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        BarraDeVida = GetComponent<barraDeVida>();
        mov = GameObject.FindGameObjectWithTag(tagNombre).GetComponent<movimientoScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void damage(float damage)
    {
        BarraDeVida.vida -= damage;
        animator.SetTrigger("golpeado");
        mov.setDefendiendo(false);
        Debug.Log(BarraDeVida.vida);
    }
}