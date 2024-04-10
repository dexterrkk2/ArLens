using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class killTarget1 : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem hitEffect;
    public float timeToSelect = 3.0f;
    public int score;
    public Transform Camera;
    private float countDown;
    public ISelelectEffect effect;
    public TextMeshProUGUI scoreText;
    public LineRenderer renderer;
    public bool isGrabbing;
    void Start()
    {
        if (Camera == null)
        {
            Camera = UnityEngine.Camera.main.transform;
        }
        score = 0;
        countDown = timeToSelect;
        effect = GetComponent<ISelelectEffect>();
    }
    void Update()
    {
        int rendNumber = renderer.positionCount-1;
        Camera.transform.position = renderer.GetPosition(rendNumber);
        bool isHitting = false;
        Ray ray = new Ray(Camera.position, Camera.rotation *Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag != "Obstacle")
            {
                isHitting = true;
            }
            //Debug.DrawRay(transform.position, hit.point);
        }
        if (isHitting)
        {
            if (countDown > 0.0f)
            {
                // on target
                countDown -= Time.deltaTime;
                // print (countDown);
                hitEffect.transform.position = hit.point;
                if (hitEffect.isStopped)
                {
                    hitEffect.Play();
                }
            }
            else
            {
                // killed
                effect.effect(hit);
                countDown = timeToSelect;
                //score += 1;
                if (scoreText != null)
                {
                    scoreText.text = "Score: " + score;
                }
            }
        }
        else
        {
            // reset
            countDown = timeToSelect;
            if (hitEffect != null)
            {
                hitEffect.Stop();
            }
        }
        if(score > 30)
        {
            SceneManager.LoadScene(1);
        }
    }
}
