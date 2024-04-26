using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Zombie : MonoBehaviour, INPC
{
    public int maxHp;
    int hp;
    public Slider HealthBar;
    public GameManager gameManager;
    public ISoundObject deathSound;
    // Start is called before the first frame update
    void Start()
    {
        deathSound = GetComponent<ISoundObject>();
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
        if (hp <= 0)
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
        deathSound.Play();
        SetRandomPosition();
        gameManager.score++;
    }
    void SetRandomPosition()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float z = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, 1f, z);
        Start();
    }
}
