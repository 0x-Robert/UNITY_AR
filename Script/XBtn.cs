using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBtn : MonoBehaviour {

    public GameObject obj;
    public GameObject Own;

    

	public void OnMouseDown()
    {
        obj.SetActive(false);//image
        Own.SetActive(false);
    }
}
