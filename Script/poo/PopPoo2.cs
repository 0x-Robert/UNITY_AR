using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopPoo2 : MonoBehaviour
{


    public GameObject popupOn;
    public GameObject Pad;
    public GameObject Poop;
    public GameObject Poo4;

    private int waittime = 6;


    //  public Transform playertr;


    public Image PoPIMG;
    //팝업창이미지
    //public Text SecondText;
    //public Text bonText;

    public Image btnImg;

  

    void Start()
    {
        //popupOn.SetActive(false);
      //  PopPoo3Btn.SetActive(false);
        Pad.SetActive(false);
        Poop.SetActive(false);

    }

    void InitPopup()
    {
        Color img = PoPIMG.color;
        img.a = 1;
        PoPIMG.color = img;


        //bonText.color = new Color(0, 0, 0, 1);
       // SecondText.color = new Color(0, 0, 0, 1);


        Color img2 = btnImg.color;
        img2.a = 1;
        btnImg.color = img2;
    }


    public void OnMouseDown()
    {

       // Player1.instance.transform.position = new Vector3(x, y, z);
        //새위치 설정 스크립트


        //  
        //  popupOn.SetActive(true);
        StartCoroutine(startpoo2());

        Color img = PoPIMG.color;
        img.a = 0;
        PoPIMG.color = img;


        //bonText.color = new Color(0, 0, 0, 0);
        //SecondText.color = new Color(0, 0, 0, 0);


        Color img2 = btnImg.color;
        img2.a = 0;
        btnImg.color = img2;



        //playertr.transform= new Transform()
        // img변수에 PoPIMG.color;설정
        //img의 알파값을 0으로 설정
        //PoPIMG.color=img값 설정으로 알파값 0임을 설정 

    }

    IEnumerator startpoo2()
    {
        //추가 테스트로 만드는거
        //  Player1.instance.animCtrl.SetBool("sick", false);
        Poop.SetActive(true);
        Pad.SetActive(true);
       // Player1.instance.animCtrl.SetBool("poo1", false);
        Player1.instance.animCtrl.SetBool("poo2", true);
        // Player1.instance.animCtrl.SetBool("sick", false);
        yield return new WaitForSeconds(7.0f);
        //  Player1.instance.animCtrl.SetBool("sick", false);

        Poop.SetActive(false);
        Pad.SetActive(false);
        popupOn.SetActive(false);
        Player1.instance.animCtrl.SetBool("poo2", false);
        InitPopup();

        Poo4.SetActive(true);
      
        yield break;

    }
}