using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class DataMaster : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;
    public Text day;

    private string saveday_String; //Playerprefs key 값
    private float saveday_Float;// Playerprefs float
    private string myString;
    private string dataPlusdata;
    private Array data;
    private string plusdata;
    private string timedelta_Save;

    private float time_Follow;
public Array Data
    {
        get
        {
            return data;
        }

        set
        {
            data = value;
        }
    }

    void Start()
    {

        //Store the current time when it starts
        currentDate = System.DateTime.Now;

        //Grab the old time from the player prefs as a long
        long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));

        //Convert the old time from binary to a DataTime variable
        DateTime oldDate = DateTime.FromBinary(temp);
        print("oldDate: " + oldDate);

        //Use the Subtract method and store the result as a timespan variable
        TimeSpan difference = currentDate.Subtract(oldDate);
      
        //myString 값은 difference값을 string값으로 변환시킨것
        myString = string.Format("{0:c}", difference);

        print("Difference: " + difference);
       
        PlayerPrefs.GetString("saveday_String");
        //saveday_String값을 키로하고 저장소이고 myString이 매개변수
        //앞에서 문자열로 선언후 저장기능강화 가져온다 겟
        PlayerPrefs.GetString("dataPlusdata");
        plusdata = myString + Time.deltaTime+Time.time;


        PlayerPrefs.GetFloat("timedelta_Save");
    }

    private void Update()
    {
        time_Follow += Time.deltaTime;
        PlayerPrefs.SetString("saveday_String", "myString");
        PlayerPrefs.SetString("dataPlusdata", "plusdata");
        PlayerPrefs.SetFloat("timedelta_Save", time_Follow);
        Debug.Log("TimeDeltaSave" + timedelta_Save);


        PlayerPrefs.Save();
       // Debug.Log("dataPlusdata"+dataPlusdata);
        //셋팅한다 saveday_String키값에 myString매개변수를 이용해서 
        //  Debug.Log();
        Debug.Log("myString" + myString);
        PlayerPrefs.Save();
        day.text = "string" + myString;
        Debug.Log("oldDate+myString"+ oldDate + myString);
        Debug.Log("currentDate+myString" + currentDate + myString);
        Debug.Log("DataPlus" + plusdata);


    }
    void OnApplicationQuit()
    {
        //Savee the current system time as a string in the player prefs class
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());

        print("Saving this date to prefs: " + System.DateTime.Now);
    }

}