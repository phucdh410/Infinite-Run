using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptTemp : MonoBehaviour
{
    public TextMeshProUGUI TextMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeTextEdited()
    {
        TextMesh.text = "Hihi haha";
        TextMesh.color = Color.red;
    }
}
