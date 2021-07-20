using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bath_manager : MonoBehaviour
{

    public Player1 player1;
    public int bathplus;
    public Slider bathslider;
    public int bathtouchmount = 10;
    public GameObject bathDisplay;
    public GameObject player;

    void Start()
    {
        player1 = GetComponent<Player1>();
        player = GetComponent<GameObject>();
        bathslider.value = 0;

    }


    void Update()
    {
        if (bathslider.value == 100)
        {
            StartCoroutine(bathFeedback());


        }
    }

    IEnumerator bathFeedback()
    {
        yield return new WaitForSeconds(0.5f);

        Player1.instance.animCtrl.SetBool("BathOn", true);
        //bath밸류값이 100됬을때 bath 애니메이션 실행 

        yield return new WaitForSeconds(6.0f);
        Player1.instance.animCtrl.SetBool("BathOn", false);
        bathDisplay.SetActive(false);

        yield break;
    }
}