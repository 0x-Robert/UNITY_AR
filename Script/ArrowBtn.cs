using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowBtn : MonoBehaviour
{

    public RectTransform rectTransform;
    public Image OwnObj;
    public static int count;
    public Animator ArrowAnim;
    public GameObject TransP;
    public static bool TransUpDown;
    public TransParent TransUD;
    void Start()
    {

        OwnObj = GetComponent<Image>();
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        ArrowAnim = GetComponent<Animator>();

    }



    public void OnMouseDown(bool DayUpDown)
    {
        Debug.Log("Click");

        OwnObj.rectTransform.Rotate(new Vector3(0, 0, -180));
        count++;

        if (count % 2 == 0)
        {

            TransUD.TransAnim.SetTrigger("TransDown");
            Debug.Log("TransDown");

        }
        else if (count % 2 == 1)
        {

            TransUD.TransAnim.SetTrigger("TransUp");
            Debug.Log("TransUp");


        }


    }
}