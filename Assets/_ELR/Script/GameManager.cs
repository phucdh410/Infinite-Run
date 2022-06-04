using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    //public bool isOver;
    public int score;
    public TextMeshProUGUI txt;
    //void Start()
    //{
    //    isOver = false;
    //}
    void Update()
    {
        updateScore();
    }

    public void setScore()
    {
        score++;
    }
        
    public void updateScore()
    {
        txt.text = "Score: " + score;
    }

}

