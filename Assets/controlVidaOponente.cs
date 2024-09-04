using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class controlVidaOponente : MonoBehaviour
{
    public Animator animator;
    public barraDeVida BarraDeVida;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damage(float damage)
    {
        BarraDeVida.vida -= damage;
        Debug.Log(BarraDeVida.vida);
    }
}
