using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_PopPoo1 : MonoBehaviour
{

   
    public GameObject Capet;
    public GameObject Table;
    public GameObject Tisue;
    public GameObject Poop;
    private int waittime = 5;

    public Animator sideMenuAniCtrl;
    public GameObject slideMenu;
    bool onclick;

   // private float x = 0.08f;
   // private float y = 0.39f;
   // private float z = -0.49f;

    public GameObject PopPoo2Btn;


    private void Start()
    {
       
        PopPoo2Btn.SetActive(false);

        Capet.SetActive(false);
        Table.SetActive(false);
        Tisue.SetActive(false);
        Poop.SetActive(false);

        slideMenu = GetComponent<GameObject>();
        sideMenuAniCtrl = GetComponentInParent<Animator>();
        onclick = false;


    }

    public void OnMouseDown()
    {

      //  Player1.instance.transform.position = new Vector3(x, y, z);

        StartCoroutine(startpoo2());
        Debug.Log("CloseTouch");
        onclick = true;
        sideMenuAniCtrl.SetTrigger("SlideOff");

    }

    IEnumerator startpoo2()
    {
        //추가 테스트로 만드는거
        //  Player1.instance.animCtrl.SetBool("sick", false);
        Capet.SetActive(true);
        Table.SetActive(true);
        Tisue.SetActive(true);
        
        Player1.instance.animCtrl.SetBool("poo1", true);
        yield return new WaitForSeconds(3.0f);
        Poop.SetActive(true);

        // Player1.instance.animCtrl.SetBool("sick", false);
        yield return new WaitForSeconds(waittime);
        //  Player1.instance.animCtrl.SetBool("sick", false);

        Capet.SetActive(false);
        Table.SetActive(false);
        Tisue.SetActive(false);
        Poop.SetActive(false);
        Player1.instance.animCtrl.SetBool("poo1", false); 
        PopPoo2Btn.SetActive(true);
        yield break;

    }
}