using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour, ISelelectEffect
{
    public int damage;
    public INPC nPC;
    public void effect(RaycastHit hit)
    {
        Debug.Log("works");
        nPC = hit.collider.GetComponent<INPC>();
        Debug.Log(nPC);
        if (nPC != null)
        {
            nPC.TakeDamage(damage);
        }
    }
}
