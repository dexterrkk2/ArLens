using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEffect : MonoBehaviour, ISelelectEffect
{
    public GameObject turretPrefab;
    ITurret turretScript;
    public void Start()
    {
    }
    public void effect(RaycastHit hit)
    {
        Quaternion direction = Quaternion.Euler(0, 270, 0);
        GameObject turret =Instantiate(turretPrefab, hit.point, direction);
        turretScript = turret.GetComponent<ITurret>();
        Debug.Log("SpawnedTurret");
        turretScript.Activate();
    }
}
