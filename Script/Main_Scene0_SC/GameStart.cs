using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

    public GameObject myGameOBJ;
  

    public void OnMouseDown()
    {
        myGameOBJ.SetActive(false);
    }
}
