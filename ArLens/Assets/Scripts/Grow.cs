using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour, IGrabEffect
{
    public float scaleSpeed;
    public bool grow;
    public float setCooldown;
    public float cooldown { get; set; }

    public void effect()
    {
        Debug.Log("Grow");
        transform.localScale = transform.localScale * scaleSpeed;
        Debug.Log(transform.localScale);
    }
}
