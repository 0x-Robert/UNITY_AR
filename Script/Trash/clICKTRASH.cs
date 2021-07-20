using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clICKTRASH : MonoBehaviour {

   
    public GameObject TrashCan;
    public GameObject trash1;
    public GameObject trash2;
    public GameObject trash3;


    public Animator sideMenuAniCtrl;
    public GameObject slideMenu;
    public GameObject Playertrash;
    public bool animclose;
    void Start ()

    {
        Playertrash.SetActive(false);
           slideMenu = GetComponent<GameObject>();
        sideMenuAniCtrl = GetComponentInParent<Animator>();
        Player1.instance.animCtrl.SetBool("TrashAnim", false);
       // Player1.instance.animCtrl.SetBool("chip", false);

        TrashCan.SetActive(false);
        trash1.SetActive(false);
        trash2.SetActive(false);
        trash3.SetActive(false);

    }

    public void OnMouseDown()
    {
        Playertrash.SetActive(true);
        StartCoroutine(animTrashStart());
        //Player1.instance.animCtrl.SetBool("TrashAnim", true);
        sideMenuAniCtrl.SetTrigger("SlideOff");
        animclose = false;
        
    }
    IEnumerator animTrashStart() { 
    
        yield return new WaitForSeconds(1.0f);
        Player1.instance.animCtrl.SetBool("TrashAnim", true);
        TrashCan.SetActive(true);
        trash1.SetActive(true);
        trash2.SetActive(true);
        trash3.SetActive(true);

        yield return new WaitForSeconds(6.0f);
        Player1.instance.animCtrl.SetBool("TrashAnim", false);
       // TrashCan.SetActive(false);
        Playertrash.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        yield break;
    }



}
