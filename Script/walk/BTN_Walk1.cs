using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_Walk1 : MonoBehaviour
{



    public GameObject Neck;
    public GameObject ball;

    public Animator sideMenuAniCtrl;
    public GameObject slideMenu;
    bool onclick;

    public GameObject WalkBallBtn;
    private int waittime = 6;

    private float x = 0.08f;
    private float y = 0.39f;
    private float z = -0.49f;

     void Start()
    {

       
        Neck.SetActive(false);
        WalkBallBtn.SetActive(false);
    }


    public void OnMouseDown()
    {

        Player1.instance.transform.position = new Vector3(x, y, z);

        StartCoroutine(startWalkBall());

        Debug.Log("CloseTouch");
        onclick = true;
        sideMenuAniCtrl.SetTrigger("SlideOff");

    }

    IEnumerator startWalkBall()
    {
        //추가 테스트로 만드는거
        //  Player1.instance.animCtrl.SetBool("sick", false);
        Neck.SetActive(true);
      //  ball.SetActive(true);
        Player1.instance.animCtrl.SetBool("walk", true);
        // Player1.instance.animCtrl.SetBool("sick", false);
        yield return new WaitForSeconds(waittime);

        Player1.instance.animCtrl.SetBool("walk", false);

        Neck.SetActive(false);
     //   ball.SetActive(false);

        WalkBallBtn.SetActive(true);
        yield break;

    }
}