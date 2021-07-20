using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class BTN_Eat : MonoBehaviour

{
    private int waittime = 6;

    public Animator sideMenuAniCtrl;
    public GameObject slideMenu;
    bool onclick;
    public GameObject petFood;
    private float x = 0.08f;
    private float y = 0.50f;
    private float z = -0.19f;


   void Start()
    {

        slideMenu = GetComponent<GameObject>();
        sideMenuAniCtrl = GetComponentInParent<Animator>();
        onclick = false;
       // petFood.SetActive(false);
    }
    public void OnMouseDown()
    {
        Player1.instance.transform.position = new Vector3(x, y, z);
       
        Debug.Log("CloseTouch");
        onclick = true;
        sideMenuAniCtrl.SetTrigger("SlideOff");
        StartCoroutine(startEat());
    }

    IEnumerator startEat()
    {

        petFood.SetActive(true);
        Player1.instance.animCtrl.SetBool("EatOn", true);
        //플레이어 애니메이션 컨트롤러 

        /*
             * 3초후에 초기화함수 실행
            yield return new WaitForSeconds(3.0f);
            InitPopup();
            yield return new WaitForSeconds(5.0f);
            Player1.instance.animCtrl.SetBool("sick" ,true);
            yield break;
            함수 종료 
          */
        yield return new WaitForSeconds(waittime);
        Player1.instance.animCtrl.SetBool("EatOn", false);
        petFood.SetActive(false);
        //여기서 알파값 0만드는 함수 부분 초기화 시킴
        yield break;

    }
}