using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraDeVida : MonoBehaviour
{
    [Header("vida")]
    public Image barraVida;
    public float vida = 100f;
    public float vidaTotal = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount = vida/vidaTotal;
    }
}
