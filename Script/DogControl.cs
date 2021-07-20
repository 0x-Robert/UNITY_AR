using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DogControl : MonoBehaviour


{
    enum DOGSTATE
    {
        IDLE = 0,
        EAT,
        BATH,
        CHIP,
        TRASH
    }
    DOGSTATE dogState = DOGSTATE.IDLE;

    static public bool idle = false;
    static public bool eat = false;
    static public bool bath = false;
    static public bool chip = false;
    static public bool trash = false;

    public Animation anim;

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

   
    public static bool AnimOnOff;

    public GameObject petFood1;
    private float interval;

    float distance = 3;
    public static DogControl instance = null;

    private void Awake()
    {
        //  animCtrl = GetComponent<Animator>();
        //애니메이터 컴포넌트를 animCtrl변수 설정


        // animCtrl.enabled = false;
        startingLvPlus = currentLvPlus;
        userId.text = PlayerPrefs.GetString("USER_ID", userId.text);

        //Start 함수 시작되기전에 불러오기 
        instance = this;
        //싱글톤 설정 



    }
    void InitDog()
    {
        dogState = DOGSTATE.IDLE;
    }
    void Start ()

    {
		
	}
	
	
	void Update () {
        switch (dogState)
        {
            case DOGSTATE.IDLE :
                {

                    if (eat == true && idle==false)
                    {
                        dogState = DOGSTATE.EAT;

                    }
                    else if (eat == false)
                    {
                        idle = true;
                    }

                }
                break;
            case DOGSTATE.EAT:
                {
                   
                  
                }
                break
                ;
            case DOGSTATE.BATH:
                { }
                break;
            case DOGSTATE.CHIP:
                { }
                break;
            case DOGSTATE.TRASH:
                { }
                break;
        }


    }



    void OnMouseDrag()
    {
        idle = true;
        Touch = true;
        currentLvPlus += TouchAmount;
        LvPlusSlider.value = currentLvPlus;

        if (currentLvPlus == 1000)
        {
            Debug.Log("Love 1000 Complete");
        }

        anim.Play("Idle");



          // animCtrl.SetBool("EatOn", false);
          //  animCtrl.enabled = true;

          Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;




    }
    public void OnMouseUp()
    {
        idle = false;
        //   animCtrl.SetTrigger()
        // animCtrl.enabled = false;
        // animCtrl.SetTrigger("Total");
     
        
    }



}
