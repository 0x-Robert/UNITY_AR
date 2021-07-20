using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransParent : MonoBehaviour {

    public Transform dayTrans;
    public Image DayImg;
    public Animator TransAnim;
    //public static bool DayUpDown;
    public ArrowBtn Arrow;

	
	void Start ()
    {
        dayTrans = GetComponent<Transform>();
        DayImg = GetComponent<Image>();
        TransAnim = GetComponent<Animator>();


    }
	
	
	
}
