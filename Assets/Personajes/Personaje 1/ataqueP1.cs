using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueP1 : MonoBehaviour
{
    private Animator animacion;
    private KeyCode golpeBasico = KeyCode.Z;
    private KeyCode patadaBasica = KeyCode.X;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        combos();
    }

    void combos()
    {
        if (Input.GetKeyDown(golpeBasico))
        {
            animacion.SetTrigger("golpe_1");
        }

        if (Input.GetKeyDown(patadaBasica))
        {
            animacion.SetTrigger("patada_1");
        }
    }
}
