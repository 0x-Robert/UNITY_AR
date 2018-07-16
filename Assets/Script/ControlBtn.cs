using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBtn : MonoBehaviour {

    public GameObject controlchild;
    
    public bool onclick;
   ///public Image firstImage;
   // public Image finaltImage;

    void Start ()
    {
        controlchild.SetActive(false);
    }
	
	
	
    public void OnMouseDown()
    {
      
        
        if (controlchild.activeSelf == false)
        {
            onclick = true;

            controlchild.SetActive(true);
        }
        else if (controlchild.activeSelf == true)
        {
            onclick = false;
            controlchild.SetActive(false);
        }




    }

}
