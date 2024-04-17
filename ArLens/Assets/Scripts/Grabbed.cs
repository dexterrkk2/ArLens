using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbed : MonoBehaviour
{
    bool grabbed;
    public IGrabEffect grabEffect;
    float timer;
    private void Start()
    {
        grabEffect = GetComponent<IGrabEffect>();
        //timer = grabEffect.cooldown;
    }
    public void OnGrabbed()
    {
        grabbed = true;
    }

    public void OffGrabbed()
    {
        grabbed = false;
    }
    public void Update()
    {
        timer -= Time.deltaTime;
        if (grabbed && timer<=0)
        {
            grabEffect.effect();
            timer = grabEffect.cooldown;
        }
    }
}
