using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;



public class DayNightCycle2 : MonoBehaviour
{

    static DayNightCycle2 _instance = null;

    public static DayNightCycle2 Instance()
    {
        return _instance;
    }
 


    public int _days;
    //Defines naming convention for the days
    public int _hours;
    //Defines naming convention for the _hours
    public int _minutes;
    //Defines naming convention for the _minutes
    public int _seconds;
    //Defines naming convention for the _seconds
    public float _counter;
    //Defines naming convention for the _counter

    public int _dawnStartTime = 6;
    //Defines dawn start
    public int _dayStartTime = 8;
    //Defines day start
    public int _duskStartTime = 18;
    //Defines dusk start
    public int _nightStartTime = 20;
    //Defines night start

    public float _sunDimTime = 0.01f;
    //speed at which sun dims
    public float _dawnSunIntensity = 0.5f;
    //Down sun strenghth
    public float _daySunIntensity = 1f;
    //Day sun strength
    public float dusksunIntensity = 0.25f;
    //Dusk sun strength
    public float _nightSunIntensity = 0f;
    // Night sun strength 
    public Text daycount;
    public Text mincount;
  //  public Text saveTime;
    public int guiWidth = 500;
    //Defines GUI Label width

    public int guiHeight = 250;
    //Defines GUI Label height

    public DayPhases _dayPhases;
    //Define naming convention for the phases of the day


    public GameObject Tu1;
    public GameObject Tu2;
    public GameObject Tu3;
    public GameObject Tu4;
    public GameObject Tu5;
    public GameObject Tu6;
    public GameObject Tu7;
    public GameObject Tu8;



    public Player1 player1Script;
    

    private float timekey;

    public enum DayPhases
    //enum for day phases
    {
        Dawn,
        Day,
        Dusk,
        Night
    }



    void Start()
    {



        GETdata();
        Tu1.SetActive(false);
        Tu2.SetActive(false);
        Tu3.SetActive(false);
        Tu4.SetActive(false);
        Tu5.SetActive(false);
        Tu6.SetActive(false);
        Tu7.SetActive(false);
        Tu8.SetActive(false);
        




        StartCoroutine("TimeOfDayFiniteStateMachine");
        //Start TimeOfDayFiniteStateMachine on Start up

        _dayPhases = DayPhases.Night;
        //Set day phase to night on start up

        _hours = 0;
        //hours equal five on start up
        _minutes = 0;
        //minutes equals fifty nine on start up
        _counter = 0;
        //Counter equals fifty nine on start up



        _days = 1;
        //Days equal one on start up

        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);

    }

    int _saveDay = 0;
    int _currentDay = 0;

    public int saveDay
    {
        get
        {
            return _saveDay;
        }
    }

    public int currentDay
    {
        get
        {
            return _currentDay;

        }

        set
        {
            _currentDay = value;
            if (_currentDay >= _saveDay)
            {
                currentDay += saveDay;

            }
        }
    }

    void Update()
    {
        PlayerPrefs.Save();

        SetData();
        SecondsCounter();//Start SecondCounter function

        daycount.text = "Day" + _days;
        mincount.text = _hours + ":" + _minutes + ":" + _seconds;
        if (_minutes < 10)
        {
            mincount.text = _hours + ":" + 0 + _minutes + ":" + _seconds;

        }
        if (_days == 30)
        {
            Debug.Log("gameOver");
        }
        //_counter값 저장

     //   saveTime.text = "save" + timekey;

        //   PlayerPrefs.Save();
    }
    private void GETdata()
    {
        PlayerPrefs.GetFloat("timekey", _counter);
    }
    private void SetData()
    {
        PlayerPrefs.SetFloat("timekey", _counter);
    }
    IEnumerator TimeOfDayFiniteStateMachine()
    {
        while (true)
        {
            switch (_dayPhases)
            {
                case DayPhases.Dawn:
                    Dawn();
                    break;
                case DayPhases.Day:
                    Day();
                    break;
                case DayPhases.Dusk:
                    Dusk();
                    break;
                case DayPhases.Night:
                    Night();
                    break;

            }
            yield return null;
        }
    }


    void SecondsCounter()
    {
        Debug.Log("SecondsCounter");


        if (_counter == 60) //if the counter equal 60
            _counter = 0; //then make counter equal to 0

        _counter += Time.deltaTime;
        //counter plus time sync to pc speed
        _seconds = (int)_counter;
        //Seconds equals counter cast to an int


        /*5초일때 먹이 팝업 생성*/
        if (_seconds == 2)
        {
            Tu1.SetActive(true);
         

        }



        if (_seconds == 5)
        {
            Tu2.SetActive(true);
        }


        if (_seconds == 8)
        {
            Tu3.SetActive(true);
        }


        if (_seconds == 11)
        {
            Tu4.SetActive(true);
           
        }


        if (_seconds == 14)
        {
            Tu5.SetActive(true);
        }

        if (_seconds == 17)
        {
            Tu6.SetActive(true);
        }


        if (_seconds == 20)
        {
            Tu7.SetActive(true);
        }

        if (_seconds == 23)
        {
            Tu8.SetActive(true);
        }



        if (_counter < 60)    //if counter is less than 60
                              //  return; //then do nothing and return

            if (_counter > 60) //if counter is greater than 60
                _counter = 60; //then make counter equal to 60

        if (_counter == 60) //if counter is equal to 60
            MinutesCounter(); //call MinutesCounter function






    }

    void MinutesCounter()
    {
        Debug.Log("MinutesCounter");

        _minutes++;       //Increase minutes counter

        if (_minutes == 60)   //if minutes counter equals sixty
        {
            HoursCounter();
            //Call HoursCounter function
            _minutes = 0;
            //and then make minutes equal zero

        }

    }

    void HoursCounter()
    {
        Debug.Log("HoursCounter");

        _hours++;       //Increase hours counter

        if (_hours == 24)   //if _hours counter equals twenty four

        {
            DaysCounter();
            //Call DayCounter function
            _hours = 0;
            //and then make hours equal zero

        }
    }
    void DaysCounter()
    {
        Debug.Log("DaysCounter");
        _days++;       //Increase _days counter
    }



    void Dawn()
    {
        Debug.Log("Dawn");

        if (_hours == _dayStartTime && _hours < _duskStartTime)
        //if hours equals day start time and hours is still 
        //less than dusk start time
        {
            _dayPhases = DayPhases.Day;
            //set day phase to day 
        }
    }
    void Day()
    {
        Debug.Log("Day");


        if (_hours == _duskStartTime && _hours < _nightStartTime)
        //if hours equals dusk start time and hours is still 
        //less than night start time
        {
            _dayPhases = DayPhases.Dusk;
            //set day phase to dusk 
        }
    }
    void Dusk()
    {
        Debug.Log("Dusk");

        if (_hours == _nightStartTime)
        //if hours equals night start time 
        {
            _dayPhases = DayPhases.Night;
            //set day phase to Night 
        }
    }

    void Night()
    {
        Debug.Log("Night");

        if (_hours == _dawnStartTime && _hours < _dayStartTime)
        //if hours equals down start time and hours is still 
        //less than day start time
        {
            _dayPhases = DayPhases.Dawn;
            //set day phase to Dawn 
        }
    }


    /*  void OnGUI()
    {
        //create gui label to dislay number of days
        GUI.Label(new Rect(Screen.width- 50, 5, guiWidth, guiHeight),"Day" + _days);


        //if minutes is less than 10 display our clock with extra zero

        if(_minutes <10)
        {
            GUI.Label(new Rect(Screen.width - 50, 25, guiWidth, guiHeight), _hours + ":" + 0 + _minutes + ":" + _seconds);

        }

        //else just display our clock

        else
        GUI.Label(new Rect(Screen.width - 50, 25, guiWidth, guiHeight), _hours + ":" + _minutes + ":" + _seconds);

    }*/

}
