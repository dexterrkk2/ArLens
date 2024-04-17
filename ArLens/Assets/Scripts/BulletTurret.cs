using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurret : MonoBehaviour, ITurret
{
    public GameObject turretHead;
    public GameObject turretGunL;
    public GameObject turretGunR;
    public float rotationStart;
    public float rotationMax;
    public float roationTime;
    public float rayDistance;
    bool targetFound;
    float timer;
    public float attackDelay;
    public ISelelectEffect killTarget;
    public void Activate()
    {
        killTarget = GetComponent<ISelelectEffect>();
        InvokeRepeating("Seek", 0f, roationTime);
    }
    public void Seek()
    {
        Quaternion endRot = Quaternion.Euler(0, rotationStart +rotationMax, 0);
        StartCoroutine(RotateDuration(turretHead, endRot, roationTime));
        rotationMax = -rotationMax;
    }
    IEnumerator RotateDuration(GameObject rotateObject, Quaternion endRotate, float time)
    {
        Quaternion currentRot = rotateObject.transform.rotation;
        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            rotateObject.transform.rotation = Quaternion.Lerp(currentRot, endRotate, t);
            FindTarget(turretGunL.transform.position, turretGunL.transform.forward);
            FindTarget(turretGunR.transform.position, turretGunR.transform.forward);
            yield return null;
        }
    }
    public void FindTarget(Vector3 rayPosition, Vector3 rayDirection)
    {
        RaycastHit hit;
        Ray ray = new Ray(rayPosition, rayDirection);
        Debug.DrawRay(ray.origin, ray.direction*rayDistance, Color.red, .5f);
        if (Physics.Raycast(ray, out hit, rayDistance) && timer<=0)
        {
            timer = attackDelay;
            if (hit.collider.tag != "Obstacle")
            {
                killTarget.effect(hit);
                Fire();
            }
        }
    }
    public void Fire()
    {
        Debug.Log("Fire");
    }
    void Update()
    {
        timer-= Time.deltaTime;
    }
}
