using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour {


    
    public Animator sideMenuAniCtrl;
    public GameObject slideMenu;
    bool onclick;
   // public GameObject barOnOff;


    void Start()
    {
        slideMenu = GetComponent<GameObject>();
     //    sideMenuAniCtrl = GetComponent<Animator>();
        sideMenuAniCtrl = GetComponentInChildren<Animator>();

        onclick = false;

    }


    public void OnMouseDown()
    {
        Debug.Log("TouchMenu");
        onclick = true;
        sideMenuAniCtrl.SetTrigger("SlideOn");
      //  barOnOff.SetActive(false);
    }
}
