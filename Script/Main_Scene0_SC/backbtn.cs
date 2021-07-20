using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backbtn : MonoBehaviour {

    public GameObject childOBJ;

    private void Start()
    {
        childOBJ.SetActive(false);
    }
    public void OnMouseDown()
    {
        childOBJ.SetActive(true);
    }
}
