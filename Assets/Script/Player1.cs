using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour {

    public Animator animCtrl;
    public Slider LvPlusSlider;
    public int startingLvPlus=0;
    public int currentLvPlus;
    bool LvComplete;
    bool Touch;
    public int TouchAmount=10;
	public InputField userId;

     void Awake()
    {
        animCtrl = GetComponent<Animator>();
       // animCtrl.SetBool("Idle", false);
        animCtrl.enabled = false;
        startingLvPlus = currentLvPlus;
		userId.text = PlayerPrefs.GetString ("USER_ID", userId.text);
    }

    float distance = 3;

     void Update()
    {
        // animCtrl.SetBool("Idle", false);
        //  animCtrl.enabled = false;
       
		PlayerPrefs.SetString("USER_ID", userId.text);
    }


    void OnMouseDrag()
    {
        Touch = true;
        currentLvPlus += TouchAmount;
        LvPlusSlider.value = currentLvPlus;

        if(currentLvPlus ==1000)
        {
            Debug.Log("Love 1000 Complete");
        }

        // animCtrl.SetBool("Idle", true);
        animCtrl.enabled = true;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
    }
    void OnMouseUp()
    {
        animCtrl.enabled = false;
    }

}
