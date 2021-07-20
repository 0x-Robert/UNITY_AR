using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhateverScriptNameYouWant : MonoBehaviour {

   
        private static System.DateTime startDate;
        private static System.DateTime today;
    public Text dayCounter;


        void Start()
        {
            SetStartDate();
        }

        void SetStartDate()
        {
            if (PlayerPrefs.HasKey("DateInitialized")) //if we have the start date saved, we'll use that
                startDate = System.Convert.ToDateTime(PlayerPrefs.GetString("DateInitialized"));
            else //otherwise...
            {
                startDate = System.DateTime.Now; //save the start date ->
                PlayerPrefs.SetString("DateInitialized", startDate.ToString());
            }
        }

  

    public static string GetDaysPassed()
        {
            today = System.DateTime.Now;

            //days between today and start date -->
            System.TimeSpan elapsed = today.Subtract(startDate);

            double days = elapsed.TotalDays;

            return days.ToString("0");
        }

    
}

