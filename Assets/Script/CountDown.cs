using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class CountDown : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;
    public float FinishTime = 1.0f;
    public Text FinishTimeText;
    public Text GoneText;
    public float GoneTime = 0.0f;
    public bool startedProcess = false;
    public GameObject gmover;

    void Start()
    {
        currentDate = System.DateTime.Now;
        long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));
        DateTime oldDate = DateTime.FromBinary(temp);
        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Difference: " + difference);
        FinishTime -=    (difference.Seconds) + (difference.Minutes * 60) + (difference.Hours * 60 * 60) + (difference.Days * 60 * 60 * 24);
        GoneTime = (difference.Seconds) + (difference.Minutes * 60) + (difference.Hours * 60 * 60) + (difference.Days * 60 * 60 * 24);
    }

    // Update is called once per frame
    void Update()
    {
        GoneText.text = GoneTime.ToString();
        var timeSpan = System.TimeSpan.FromSeconds(FinishTime);
        if (FinishTime > 86400)
        {
            FinishTimeText.text =timeSpan.Days.ToString()+"D" + "" + timeSpan.Hours.ToString() + "H" + " " + timeSpan.Minutes.ToString() + "M" + " " + timeSpan.Seconds.ToString() + "S";
        }

       else if (FinishTime > 3600)
        {
            FinishTimeText.text = timeSpan.Hours.ToString() + "H" + " " + timeSpan.Minutes.ToString() + "M" + " " + timeSpan.Seconds.ToString() + "S";
        }
        else if (FinishTime > 60 && FinishTime < 3600)
        {
            FinishTimeText.text = timeSpan.Minutes.ToString() + "M" + " " + timeSpan.Seconds.ToString() + "S";
        }
        else if (FinishTime > 1 && FinishTime < 60)
        {
            FinishTimeText.text = timeSpan.Seconds.ToString() + "S";
        }
        else if (FinishTime < 1)
        {
            FinishTimeText.text = "Completed !";
        }
        if (startedProcess)
        {
            FinishTime = Mathf.Max(0, FinishTime - Time.deltaTime);
            if (FinishTime <= 0)
            {
                print("Finished");
                gmover.SetActive(true);
                startedProcess = false;
            }
        }
    }
    public void StartCountDown()
    {
        print("Started");
        startedProcess = true;
    }
    void OnApplicationQuit()
    {
        //Savee the current system time as a string in the player prefs class
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
        print("Saving this date to prefs: " + System.DateTime.Now);
    }
}