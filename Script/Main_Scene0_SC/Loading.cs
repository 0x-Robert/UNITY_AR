using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{


    public GameObject loadingWindow;
    public GameObject selcetWindow;

    public Image welcome_img;
    private void Start()
    {
        selcetWindow.SetActive(false);

}


public void OnMouseDown()
    {

        if (loadingWindow.activeSelf == true)
        {
          
            Color img = welcome_img.color;
            img.a = 0;
            welcome_img.color = img;

            selcetWindow.SetActive(true);



        }
        else if (loadingWindow.activeSelf == false)
        {
           // selcetWindow.SetActive(true);
        }



    }
	
        
}
