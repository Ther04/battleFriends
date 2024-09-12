using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciarPlayer : MonoBehaviour
{

    public GameObject[] personajesP1;
    public GameObject[] personajesP2;
    public GameObject round;
    public Vector2 posP1;
    public Vector2 posP2;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(personajesP1[SelectedCharacters.p1CharacterID], posP1, transform.rotation);
        Instantiate(personajesP2[SelectedCharacters.p2CharacterID], posP2, transform.rotation);
        Instantiate(round);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
