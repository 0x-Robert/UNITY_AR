using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CountDown30 : MonoBehaviour {

    public Text DayCount;
    private bool gameEnd;
    int finalDay = 30;




	
    /*유니티 30일 카운트 다운 시작
       
         
      처음에 앱을 틀자마자 시작된날짜를 저장 
        이후 30일을 오프라인에서도 돌아가게끔 구현하는게 목적
        
         이때 구동할때마다 차이만큼 계속 감소 
         

        day 30은 처음 틀고 나서 현재흘러가는 시간만큼 계속감소
        그리고 감소된 값 저장

        두번째 구동 앞에서나온 시간차를 계산후 두번째값에 적용후 저장
        감소후 저장

        세번째 구동 두번째값과 비교후 현재시간을 계산해서 저장하고 연산 처리 그리고 출력

        이를위해서는 코루틴함수가 좋을것같음

        date time = 30설정
        date time -= sytem.date.now 계산
        text daycount = "day" + time;

        timespan
        time.ticks
        diff

        값이 두개 필요 항상

        처음에 구동한날짜 계산
        두번째 세번째 구동할때마다 차이만큼 감소 

        처음에 구동한날짜 = Day 30 설정
        두번째 구동한날짜 =Day 30 - 두번째실행한날짜 차이만큼 감소 그리고 출력 
        세번째 구동한날짜 =두번째날짜- 세번째 실행한날짜 차이만큼 감소


         
         */


	void Start ()
    {
        DayCount.text = "Day" + finalDay;
        StartCoroutine("timeChecker");
	}
	
    IEnumerator timeChecker()
    {
        while (!gameEnd)
        {
            yield return new WaitForSecondsRealtime(1.0f);
            DateTime now = System.DateTime.Now;

        }

      

    }
	
    void GameOver()
    {
        gameEnd = true;

    }

	void Update ()
    {
		
	}
}
