using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
   public PlayerController PlayerController;
   private string[] animArray = {"idle", "run", "jump", "double_jump", "fall"};
   void Update() {
      // if (Input.GetMouseButtonDown(0)) {
      //    Debug.Log("Mouse Input");
      //    PlayerController.GetToPlayAnim(animArray[1]);
      // }
   }
}

