using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;



public class DayNightCycle : MonoBehaviour {

	static DayNightCycle _instance = null;

	public static DayNightCycle Instance()
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

	public int guiWidth = 500;
	//Defines GUI Label width

	public int guiHeight = 250;
	//Defines GUI Label height

	public DayPhases _dayPhases;
	//Define naming convention for the phases of the day

	public GameObject Popup;
	public enum DayPhases
	//enum for day phases
	{
		Dawn,
		Day,
		Dusk,
		Night
	}



	void Start ()
	{
		Popup.SetActive(false);
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

		//date.time.now 현재시간 가져오기
		//저장기능 가져오기 

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
			if(_currentDay >= _saveDay)
			{ currentDay += saveDay;

			}
		}
	}

	void Update ()
	{
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

		if(_seconds == 30)
		{
			Popup.SetActive(true);

		}
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
		_seconds =(int) _counter;
		//Seconds equals counter cast to an int

		if (_counter < 60)    //if counter is less than 60
			return; //then do nothing and return

		if (_counter > 60) //if counter is greater than 60
			_counter = 60; //then make counter equal to 60

		if (_counter == 60) //if counter is equal to 60
			MinutesCounter(); //call MinutesCounter function



	}

	void MinutesCounter()
	{
		Debug.Log("MinutesCounter");

		_minutes++;       //Increase minutes counter

		if(_minutes == 60)   //if minutes counter equals sixty
		{
			HoursCounter();
			//Call HoursCounter function
			_minutes = 0;
			//and then make minutes equal zero
			Popup.SetActive(true);
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

		if(_hours == _dayStartTime && _hours < _duskStartTime)
			//if hours equals day start time and hours is still 
			//less than dusk start time
		{
			_dayPhases =  DayPhases.Day;
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