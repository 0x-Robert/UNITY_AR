using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bathmBTN : MonoBehaviour
{

    public GameObject bathDisplay;
 
    public Animator sideMenuAniCtrl;
    public GameObject slideMenu;
    bool onclick;
    private float x = 0.08f;
    private float y = 0.39f;
    private float z = -0.49f;


    private void Start()
    {
        bathDisplay.SetActive(false);
        slideMenu = GetComponent<GameObject>();
        sideMenuAniCtrl = GetComponentInParent<Animator>();
        onclick = false;
    }

    public void OnMouseDown()
    {
        bathDisplay.SetActive(true);
        Player1.instance.transform.position = new Vector3(x, y, z);
        Debug.Log("CloseTouch");
        onclick = true;
        sideMenuAniCtrl.SetTrigger("SlideOff");
    }
}