using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScan : MonoBehaviour {

    public GameObject Startscan;
    public GameObject myObj;
    private void Start()
    {
        Startscan.SetActive(false);
    }

    public void OnMouseDown()
    {

        Startscan.SetActive(true);
        myObj.SetActive(false);
    }
}
