using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movimientoScript : MonoBehaviour
{
    [Header("Teclas")]
    [SerializeField]private KeyCode derecha = KeyCode.A;
    [SerializeField]private KeyCode izquierda = KeyCode.D;
    [SerializeField] private KeyCode salto = KeyCode.W;
    [SerializeField] private KeyCode agachado = KeyCode.S;
    [SerializeField] private KeyCode defender = KeyCode.C;

    [Header("Objeto Cooldown")]
    [SerializeField] private cooldown Cooldown;

    //posicion objeto
    private Transform pos;

    [Header("movimiento")]
    public float speed = 5f;
    public float jumpForce = 20f;
    public float moverHorizontal; 
    private Rigidbody2D rb;
    private Vector3 velocidad = Vector3.zero;
    [Range(0, 0.3f)] public float suavizado;
    private bool isGrounded = true;
    [SerializeField]private bool derechaEsCierto = false;
    private Transform posOtro = null;
    [SerializeField] private string TagOtro;
    private bool combateFin = false;

    [Header("personaje")]
    [SerializeField] private string nombre;
    private Animator animator;
    private golpes combo;
    private bool estaAgachado = false;
    private bool defendiendo = false;

    [Header("impulsos")]
    private bool isGolpeado = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GameObject.FindGameObjectWithTag(nombre).GetComponent<Animator>();
        posOtro = GameObject.FindGameObjectWithTag(TagOtro).GetComponent<Transform>();
        combo = GameObject.FindGameObjectWithTag(nombre).GetComponent<golpes>();
        pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //moverHorizontal = Input.GetAxis("Horizontal");
        if (!combateFin)
        {


            moverHorizontal = 0f;
            if (Input.GetKey(izquierda))
            {
                moverHorizontal = -1f;
            }
            else if (Input.GetKey(derecha))
            {
                moverHorizontal = 1f;
            }
            girar();
            defenderse();
            if (!defendiendo)
            {
                agacharse();
                if (!estaAgachado)
                {
                    saltar();
                    mover();
                }
            }
        }
        
    }

    private void FixedUpdate()
    {
        
    }

    void agacharse()
    {
        if (Input.GetKey(agachado))
        {
            estaAgachado = true;
            animator.SetBool("agachado", estaAgachado);
        }
        else
        {
            estaAgachado = false;
            animator.SetBool("agachado", estaAgachado);
        }
    }
    void mover()
    {
        if (isGolpeado)
        {

        }
        else
        {
            Vector2 movimiento = new Vector2(moverHorizontal * speed, rb.velocity.y);
            rb.velocity = movimiento;
        }
        
        //rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector2(moverHorizontal * speed, rb.velocity.y), ref velocidad, suavizado);
    }

    void saltar()
    {
        if (Input.GetKeyDown(salto) && isGrounded)
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
        if (collision.gameObject.CompareTag("Wall"))
        {

        }
    }

    void girar()
    {
        if(transform.position.x < posOtro.position.x && derechaEsCierto)
        {
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
            derechaEsCierto = false;
        }
        else if(transform.position.x > posOtro.position.x && !derechaEsCierto)
        {
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
            derechaEsCierto = true;
        }
    }

    void defenderse()
    {
        if (Cooldown.noPuedeGolpear) return;
        if (Input.GetKey(defender) && combo.getPuedeDefender())
        {
            defendiendo = true;
            animator.SetBool("defensa", defendiendo);
            combo.terminoDefensa();
        }
        else
        {
            defendiendo = false;
            animator.SetBool("defensa", defendiendo);
        }
    }

    public void recibioGolpeFuerte()
    {
        isGolpeado = true;
        if (!derechaEsCierto)
        {
            rb.AddForce(new Vector2(-1000, 0), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(1000, 0), ForceMode2D.Impulse);
        }
        
        StartCoroutine(reiniciarGolpeado());
        
    }

    public void golpeado()
    {
        isGolpeado = true;
        StartCoroutine(reiniciarGolpeado());
    }

    IEnumerator reiniciarGolpeado()
    {
        yield return new WaitForSeconds(0.80f);

        isGolpeado = false;
    }

    public bool isAgachado()
    {
        return estaAgachado;
    }

    public bool getDefendiendo() {  return defendiendo; }

    public void setDefendiendo(bool defen)
    {
        defendiendo = defen;
    }

    public void cooldownDefensa()
    {
        Cooldown.empezarCooldown();
    }

    public void reestablecerPosicion(Vector2 posVec)
    {
        transform.position = posVec;
    }

    public void terminoCombate(bool termino)
    {
        combateFin = termino;
    }

    public bool getCombateFin() { return combateFin; }
}
