using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colision : MonoBehaviour
{
    [SerializeField] private string oponenteNombre;
    [SerializeField] private string oponenteObjeto;
    [SerializeField] private string jugadorNombre;
    private controlVida oponente;
    private movimientoScript mov;
    private golpes Golpes;
    [SerializeField]private int damage;
    // Start is called before the first frame update
    void Start()
    {
        oponente = GameObject.FindGameObjectWithTag(oponenteNombre).GetComponent<controlVida>();
        mov = GameObject.FindGameObjectWithTag(oponenteObjeto).GetComponent<movimientoScript>();
        Golpes = GameObject.FindGameObjectWithTag(jugadorNombre).GetComponent<golpes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Superior"))
        {
            if("combo1_2" == "combo1_" + Golpes.getCombo1())
            {
                //rb.velocity = new Vector2(fuerzaEmpuje,rb.velocity.y);
                mov.recibioGolpeFuerte();
                oponente.damage(5);
            }
            else
            {
                oponente.damage(damage);
            }
            
        }

        if (collision.collider.CompareTag("Inferior"))
        {
            oponente.damage(damage);
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
