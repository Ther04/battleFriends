using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMusic : MonoBehaviour
{
    private AudioSource fondo;
    public AudioClip[] canciones;
    
    // Start is called before the first frame update
    void Start()
    {
        fondo = GetComponent<AudioSource>();
        elegirCancion();
}

    // Update is called once per frame
    void Update()
    {
        
    }

    void elegirCancion()
    {
        
        int num = Random.Range(0, canciones.Length);
        switch (num) 
        {
            case 0:
                fondo.clip = canciones[0];
                fondo.Play();
                break;

            case 1:
                fondo.clip = canciones[1];
                fondo.Play();
                break;

            case 2:
                fondo.clip = canciones[2];
                fondo.Play();
                break;

            case 3:
                fondo.clip = canciones[3];
                fondo.Play();  
                break;

            default:
                break;
        }
    }
}
