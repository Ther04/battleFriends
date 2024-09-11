using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciarPlayer : MonoBehaviour
{

    public GameObject[] personajesP1;
    public GameObject[] personajesP2;
    public Vector2 posP1;
    public Vector2 posP2;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(personajesP1[0], posP1, transform.rotation);
        Instantiate(personajesP2[2], posP2, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
