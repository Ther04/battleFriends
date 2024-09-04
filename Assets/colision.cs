using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colision : MonoBehaviour
{
    private controlVidaOponente oponente;
    // Start is called before the first frame update
    void Start()
    {
        oponente = GameObject.FindGameObjectWithTag("Enemy").GetComponent<controlVidaOponente>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Superior"))
        {
            oponente.damage(20);
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Superior"))
    //    {
    //        oponente.damage(20);
    //    }
    //}
}
