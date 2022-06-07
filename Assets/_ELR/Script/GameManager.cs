using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //public bool isOver;
    public int score = 0;
    public TextMeshProUGUI txt;
  
  
    void Update()
    {
        txt.text = "Score " + score.ToString();
    }

    public void setScore()
    {
        score++;
    }
    
    public void ChangeScene(){
        SceneManager.LoadScene("SampleScene");
    }
}

