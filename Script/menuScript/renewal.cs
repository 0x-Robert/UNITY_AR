using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renewal : MonoBehaviour
{

    public GameObject pooPOPUP;


    private void Start()
    {
        pooPOPUP.SetActive(false);
    }
    public void OnMouseDown()
    {
        pooPOPUP.SetActive(true);
    }
}