using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_Hospital : MonoBehaviour
{

    public GameObject popupOn;
    public GameObject popDisplay_chip;
    private int waittime = 6;


    //  public Transform playertr;


    public Image PoPIMG;
    //팝업창이미지
    // public Text SecondText;
    //텍스트2번
    // public Text bonText;
    //텍스트 1번
    public Image btnImg;
    //이미지1번
    private float x = 0.08f;
    private float y = 0.39f;
    private float z = -0.49f;
    //플레이어 새로운 위치 
    //public GameObject popclick;
    //팝클릭 오브젝트
    public GameObject joosagi;
    public bool click;
    void Start()
    {
        // popupOn.SetActive(false);
        popDisplay_chip.SetActive(false);
        //초기에 비활성화 
        //gameObject.SetActive(false)=게임오브젝트 비활성화 
        click = false;
        joosagi.SetActive(false);
    }

    void InitPopup()//이미지 2개 텍스트 2개 초기화 함수 

    {
        Color img = PoPIMG.color;
        img.a = 1;
        PoPIMG.color = img;


        //bonText.color = new Color(0, 0, 0, 1);
        //SecondText.color = new Color(0, 0, 0, 1);


        Color img2 = btnImg.color;
        img2.a = 1;
        btnImg.color = img2;
    }

    private void Update()
    {
        if (click == true)
        {
            InitPopup();
        }
    }
    public void OnMouseDown()//버튼클릭시 작동하는 함수 
    {

        Player1.instance.transform.position = new Vector3(x, y, z);
        //플레이어 싱글톤( 모든스크립트에서 접근가능한 함수)
        //플레이어 위치 = 새로운위치 (x좌표, y좌표 ,z좌표)

        //새위치 설정 스크립트
        popDisplay_chip.SetActive(true);

        //  
        //  popupOn.SetActive(true);
        StartCoroutine(startChip());
        //밑에있는 IEnumerator startChip()함수 실행 해라

        Color img = PoPIMG.color;
        img.a = 0;
        PoPIMG.color = img;
        //이미지 칼라 알파값을 0으로함 투명으로 변함 

        //bonText.color = new Color(0, 0, 0, 0);
        //텍스트 알파값 0으로 함 

        //SecondText.color = new Color(0, 0, 0, 0);


        Color img2 = btnImg.color;
        img2.a = 0;
        btnImg.color = img2;



        //playertr.transform= new Transform()
        // img변수에 PoPIMG.color;설정
        //img의 알파값을 0으로 설정
        //PoPIMG.color=img값 설정으로 알파값 0임을 설정 

    }

    IEnumerator startChip()
    {
        Player1.instance.animCtrl.SetBool("sick2", false);
        //플레이어 애니메이션 컨트롤러중 파라미터 값중 sick bool값중 sick을 false로 설정 
        joosagi.SetActive(true);
        Player1.instance.animCtrl.SetBool("chip", true);
        //플레이어 애니메이션 컨트롤러 


        yield return new WaitForSeconds(waittime);
        Player1.instance.animCtrl.SetBool("chip", false);
        popDisplay_chip.SetActive(false);
        popupOn.SetActive(false);
        joosagi.SetActive(false);
        InitPopup();
        //여기서 알파값 0만드는 함수 부분 초기화 시킴
        yield break;

    }
}