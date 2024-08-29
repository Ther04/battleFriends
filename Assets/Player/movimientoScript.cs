using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoScript : MonoBehaviour
{
    [Header("movimiento")]
    public float speed = 5f;
    public float jumpForce = 20f;
    public float moverHorizontal; 
    private Rigidbody2D rb;
    private Vector3 velocidad = Vector3.zero;
    [Range(0, 0.3f)] public float suavizado;
    private bool isGrounded = true;
    private bool derecha = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        
        saltar();
        mover();
    }

    private void FixedUpdate()
    {
        
    }

    void mover()
    {


        if (moverHorizontal < 0 && derecha)
        {
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
            derecha = false;
        }
        else if (moverHorizontal > 0 && !derecha)
        {
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
            derecha = true;
        }
        Vector2 movimiento = new Vector2(moverHorizontal * speed, rb.velocity.y);
        rb.velocity = movimiento;
        //rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector2(moverHorizontal * speed, rb.velocity.y), ref velocidad, suavizado);
    }

    void saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false; // Evita saltos múltiples
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void girar()
    {

    }
}
