using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms.Impl;

public class KillEffect : MonoBehaviour, ISelelectEffect
{
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    RaycastHit hit;
    public void effect(RaycastHit _hit)
    {
        hit = _hit;
        Instantiate(killEffect, _hit.transform.position, _hit.transform.rotation);
        INPC npc = hit.collider.GetComponent<INPC>();
        npc.die();
    }
}