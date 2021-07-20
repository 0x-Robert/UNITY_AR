using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopWalkBall : MonoBehaviour
{

    
    public GameObject Ball;
    private int waittime = 6;


    //  public Transform playertr;


    public Image PoPIMG;
    //팝업창이미지
    //public Text SecondText;
    //텍스트2번
    //public Text bonText;
    //텍스트 1번
    public Image btnImg;
    //이미지1번
    private float x = 0.08f;
    private float y = 0.39f;
    private float z = -0.49f;
    //플레이어 새로운 위치 
    public GameObject popclick;
    //팝클릭 오브젝트

    public bool click;

    void Start()
    {

       // InitPopup();
        click = false;
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

     
        StartCoroutine(startWalkBall());
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

    IEnumerator startWalkBall()
    {
        //코루틴 비동기함수 startChip
        Ball.SetActive(true);
     
      
        Player1.instance.animCtrl.SetBool("walkball", true);
       
        yield return new WaitForSeconds(waittime);
        Player1.instance.animCtrl.SetBool("walkball", false);
        Ball.SetActive(false);

         InitPopup();
        //  click = true;
        popclick.SetActive(false);
          yield break;

    }
}