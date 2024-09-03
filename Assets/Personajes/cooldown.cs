using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cooldown
{
    [SerializeField] private float time;
    private float _siguenteAtaque;

    public bool noPuedeGolpear => Time.time < _siguenteAtaque;
    public void empezarCooldown() => _siguenteAtaque = Time.time + time;
}
