using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTurret : MonoBehaviour, IGrabEffect
{
    public GameObject turretPrefab;
    ITurret turretScript;
    public float setCooldown;
    public GameManager manager;
    public TextMeshProUGUI text;
    public float cooldown { get; set; }
    public int cost;
    public void Start()
    {
        cooldown = setCooldown;
    }
    public void effect()
    {
        if (manager.score >= cost)
        {
            Quaternion direction = Quaternion.Euler(0, 270, 0);
            GameObject turret = Instantiate(turretPrefab, transform.position, direction);
            turretScript = turret.GetComponent<ITurret>();
            Debug.Log("SpawnedTurret");
            turretScript.Activate();
            manager.score -= cost;
            cost += cost;
        }
    }
    public void Update()
    {
        text.text = "Click me to buy a turret. Costs " + cost + " Score";
    }
}
