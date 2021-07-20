using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_Sick : MonoBehaviour
{


    private int waittime = 6;
    public GameObject hospitalBtn;
    public Animator sideMenuAniCtrl;
    public GameObject slideMenu;
    bool onclick;

    private float x = 0.08f;
    private float y = 0.39f;
    private float z = -0.49f;


    private void Start()
    {

        // hospitalBtn.SetActive(false);
        slideMenu = GetComponent<GameObject>();
        sideMenuAniCtrl = GetComponentInParent<Animator>();
        onclick = false;

    }


    public void OnMouseDown()
    {

        Player1.instance.transform.position = new Vector3(x, y, z);

        StartCoroutine(startHoapital());

        Debug.Log("CloseTouch");
        onclick = true;
        sideMenuAniCtrl.SetTrigger("SlideOff");

    }

    IEnumerator startHoapital()
    {

        Player1.instance.animCtrl.SetBool("sick2", true);

        yield return new WaitForSeconds(waittime);


        hospitalBtn.SetActive(true);
        yield break;

    }
}