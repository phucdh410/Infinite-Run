using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadSingleton : MonoBehaviour
{
    public TextMeshProUGUI txt;

    void Start(){
        txt.text = SingletonSample.Instance.GetTempInt().ToString();
    }
}
