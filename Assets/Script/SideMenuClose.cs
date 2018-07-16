using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideMenuClose : MonoBehaviour {

   
    public Animator sideMenuAniCtrl;
    public GameObject slideMenu;
    
    bool onclick;

    void Start()
    {

        slideMenu = GetComponent<GameObject>();
       
        //    sideMenuAniCtrl = GetComponent<Animator>();
      //  sideMenuAniCtrl = GetComponent<Animator>();
        sideMenuAniCtrl = GetComponentInParent<Animator>();
        onclick = false;

    }


    public void OnMouseDown()
    {
        Debug.Log("CloseTouch");
        onclick = true;
        sideMenuAniCtrl.SetTrigger("SlideOff");

    }
}
