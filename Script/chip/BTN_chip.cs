using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_chip : MonoBehaviour
{

    public GameObject popDisplay_chip;
    private int waittime = 6;
    public Animator sideMenuAniCtrl;
    public GameObject slideMenu;
    bool onclick;
    public GameObject petChip;
    //  public Transform playertr;


    private float x = 0.08f;
    private float y = 0.39f;
    private float z = -0.49f;
    //플레이어 새로운 위치 


    private void Start()
    {

        popDisplay_chip.SetActive(false);
        slideMenu = GetComponent<GameObject>();
        sideMenuAniCtrl = GetComponentInParent<Animator>();
        onclick = false;
        petChip.SetActive(false);

    }


    public void OnMouseDown()//버튼클릭시 작동하는 함수 
    {

        Player1.instance.transform.position = new Vector3(x, y, z);
        popDisplay_chip.SetActive(true);
        Debug.Log("CloseTouch");
        onclick = true;
        sideMenuAniCtrl.SetTrigger("SlideOff");
        StartCoroutine(startChip());
        //밑에있는 IEnumerator startChip()함수 실행 해라



    }

    IEnumerator startChip()
    {
        //코루틴 비동기함수 startChip
        Player1.instance.animCtrl.SetBool("sick", false);
        //플레이어 애니메이션 컨트롤러중 파라미터 값중 sick bool값중 sick을 false로 설정 
        Player1.instance.animCtrl.SetBool("chip", true);
        //플레이어 애니메이션 컨트롤러 
        petChip.SetActive(true);
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
        Player1.instance.animCtrl.SetBool("chip", false);
        popDisplay_chip.SetActive(false);
        petChip.SetActive(false);
        yield break;

    }
}