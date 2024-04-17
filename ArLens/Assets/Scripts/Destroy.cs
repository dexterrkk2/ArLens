using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour, IGrabEffect
{
    public float setCooldown;
    public float cooldown { get; set; }

    public void effect()
   {
        Debug.Log("Off");
        gameObject.SetActive(false);
   }
}
