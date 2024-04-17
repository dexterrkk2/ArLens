using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public int gameEndScore;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= gameEndScore)
        {
            Debug.Log(score);
            SceneManager.LoadScene(1);
        }
        scoreText.text = "Score: " + score;
    }
}
