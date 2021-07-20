using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{

    public Animator animCtrl;

    public Slider LvPlusSlider;
    //슬라이더 변수선언 

    //
    // public int bathplus;
    //  public Slider bathslider;
    //  public int bathtouchmount = 10;

    public int startingLvPlus = 0;
    public int currentLvPlus;
    bool LvComplete;
    bool Touch;
    public int TouchAmount = 10;
    public InputField userId;

    public static Player1 instance = null;
    public static bool AnimOnOff;

   // public GameObject petFood1;
    private float interval;
    //  public GameObject bathDisplay;


    void Awake()
    {
        animCtrl = GetComponent<Animator>();
        //애니메이터 컴포넌트를 animCtrl변수 설정

       // petFood1.SetActive(false);
        // animCtrl.enabled = false;
        startingLvPlus = currentLvPlus;
        userId.text = PlayerPrefs.GetString("USER_ID", userId.text);

        //Start 함수 시작되기전에 불러오기 
        instance = this;
        //싱글톤 설정 


        animCtrl.SetBool("BathOn0", false);
        //애니메이션 bool값을 false
        //비활성화 
        animCtrl.SetBool("TrashAnim", false);
    }
    public static Player1 GetInstance()
    {
        return instance;

    }
    float distance = 3;

    void Update()
    {
        PlayerPrefs.SetString("USER_ID", userId.text);
        Debug.Log("EatOn");
        Debug.Log("Play Start");





    }

    /* IEnumerator bathFeedback()
    {
        yield return new WaitForSeconds(0.5f);

        animCtrl.SetBool("BathOn", true);
        //bath밸류값이 100됬을때 bath 애니메이션 실행 

        yield return new WaitForSeconds(6.0f);
        bathDisplay.SetActive(false);
        yield break;
    }*/


    void OnMouseDrag()
    {

        Touch = true;
        currentLvPlus += TouchAmount;
        LvPlusSlider.value = currentLvPlus;

        if (currentLvPlus == 1000)
        {
            Debug.Log("Love 1000 Complete");
        }

        animCtrl.SetBool("IdleOn", true);
        //드래그계속 눌르면 아이들 애니메이션 값을 true로 


        animCtrl.SetBool("TrashAnim", false);

        //드래그 누르면서 먹는 애니메이션값은 false로 설정

        // animCtrl.SetBool("EatOn", false);
        //  animCtrl.enabled = true;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;




    }
    public void OnMouseUp()
    {
        //   animCtrl.SetTrigger()
        // animCtrl.enabled = false;
        // animCtrl.SetTrigger("Total");
        animCtrl.SetBool("IdleOn", false);
    }

}