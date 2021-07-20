using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_Start : MonoBehaviour {

    public GameObject objback;
   
	public void OnMouseDown()
    {
        objback.SetActive(false);
    }
}
