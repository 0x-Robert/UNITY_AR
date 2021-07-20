using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Trash : MonoBehaviour {
   float distance = 1;
    private Vector3 screenPoint;
    private Vector3 offset;
    //private float x = 0.08f;
  //  private float y = 0.39f;
  //  private float z = -0.49f;


    public GameObject trash;
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
 transform.position = curPosition;

    }



    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Object:" + other.gameObject.name);

        if (other.CompareTag("Garbage_can"))
        {
           

            trash.SetActive(false);
            Debug.Log("Collider");
        }
     

    }
  
}
