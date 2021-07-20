using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icon_X : MonoBehaviour
{

    public GameObject pooPOPUP;
    public Animator sideMenuAniCtrl;
    public GameObject slideMenu;
    bool onclick;
    public GameObject Xbtn;
    private void Start()
    {
        pooPOPUP.SetActive(false);
        Xbtn.SetActive(false);
    }
    public void OnMouseDown()
    {
        Xbtn.SetActive(true);
        pooPOPUP.SetActive(true);
        Debug.Log("CloseTouch");
        onclick = true;
        sideMenuAniCtrl.SetTrigger("SlideOff");
    }
}