using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float scaleSpeed;
    public bool grow;
    void GrowObject()
    {
        Debug.Log("Grow");
        transform.localScale = transform.localScale * scaleSpeed;
        Debug.Log(transform.localScale);
    }
    public void OnGrow()
    {
        grow = true;
    }
    public void OffGrow()
    {
        grow = false;
    }
    private void Update()
    {
        if (grow)
        {
            GrowObject();
        }
    }
}
