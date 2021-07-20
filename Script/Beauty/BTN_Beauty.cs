using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_Beauty : MonoBehaviour
{


    public GameObject popDisplay_beauty;
    private int waittime = 10;
    public Animator sideMenuAniCtrl;
    public GameObject slideMenu;
    bool onclick;
    public GameObject petBeauty;

    private float x = 0.08f;
    private float y = 0.39f;
    private float z = -0.49f;


    private void Start()
    {

        popDisplay_beauty.SetActive(false);
        slideMenu = GetComponent<GameObject>();
        sideMenuAniCtrl = GetComponentInParent<Animator>();
        onclick = false;
        petBeauty.SetActive(false);


    }


    public void OnMouseDown()//버튼클릭시 작동하는 함수 
    {

        Player1.instance.transform.position = new Vector3(x, y, z);

        popDisplay_beauty.SetActive(true);

        StartCoroutine(startChip());

        Debug.Log("CloseTouch");
        onclick = true;
        sideMenuAniCtrl.SetTrigger("SlideOff");

    }

    IEnumerator startChip()
    {
        petBeauty.SetActive(true);
        Player1.instance.animCtrl.SetBool("beaty", true);

        yield return new WaitForSeconds(waittime);
        Player1.instance.animCtrl.SetBool("beaty", false);
        popDisplay_beauty.SetActive(false);
        petBeauty.SetActive(false);

        yield break;

    }
}