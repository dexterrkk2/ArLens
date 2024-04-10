using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Zombie : MonoBehaviour, INPC
{
    public int maxHp;
    public int hp;
    public Slider HealthBar;
    public killTarget1 killTarget1;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        HealthBar.maxValue = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthBar != null)
        {
            HealthBar.value = hp;
        }
    }
    public void TakeDamage(int damage)
    {
        hp-= damage;
        if (hp < 0)
        {
            die();
        }
    }
    void OnCollisionEnter(Collision collider)
    {
        if(collider.transform.tag != "Obstacle")
        {
            //TakeDameage(1);
        }
    }
    void die()
    {
        SetRandomPosition();
        killTarget1.score++;
    }
    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-25.0f, 5.0f);
        transform.position = new Vector3(x, 0.0f, z);
        Start();
    }
}
