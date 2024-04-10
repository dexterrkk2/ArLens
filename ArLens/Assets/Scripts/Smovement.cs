using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Smovement : MonoBehaviour
{
    public float maxspeed;
    public bool isSeeking;
    public Vector3 defaultDirection;
    public Transform target;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Move(Vector3 direction)
    {
        transform.Rotate(transform.position, getDirection(direction, 1f));
        rb.AddForce(direction * maxspeed*Time.deltaTime*1000);
    }
    float getDirection(Vector3 direction, float current)
    {
        if (direction.sqrMagnitude > 0)
        {
            return Mathf.Atan2(direction.x, direction.y);
        }
        else
        {
            return current;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isSeeking)
        {
            Move(defaultDirection);
        }
        else
        {
            defaultDirection = new Vector3(target.position.x - transform.position.x, 0, target.position.z - transform.position.z);
            defaultDirection.Normalize();
            Move(defaultDirection);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            defaultDirection = -defaultDirection;
        }
        else if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
}
