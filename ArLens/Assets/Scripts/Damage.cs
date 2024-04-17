using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour, IGrabEffect
{
    public INPC npc;
    public int damage;
    public float setCooldown;
    public float cooldown { get; set; }
    public void Start()
    {
        npc = GetComponent<INPC>();
        cooldown = setCooldown;
    }
    public void effect()
    {
        npc.TakeDamage(damage);
    }
}
