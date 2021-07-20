using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbage_can : MonoBehaviour {

    private int count;
    public GameObject garbagecan;
    public GameObject TrashOBJ1;
    public GameObject TrashOBJ2;
    public GameObject TrashOBJ3;
    private float x1 = 0.33f;
    private float y1 = 0.693f;
    private float z1 = -0.715f;

    private float x2 = 0.12f;
    private float y2 = 0.693f;
    private float z2 = -0.715f;

    private float x3 = -0.086f;
    private float y3 = 0.693f;
    private float z3 = -0.715f;




    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Object:" + other.gameObject.name);

        if (other.CompareTag("Trash"))
        {
            
            Debug.Log("Collider");
            count++;
            Debug.Log("Collider");
        }
        

    }

     void Update()
    {
        if (count == 3)
        {
            garbagecan.SetActive(false);
            count = 0;
            Debug.Log("count" + count);

            if (count == 0)
            {

                TrashOBJ1.transform.position = new Vector3(x1, y1, z1);
                TrashOBJ2.transform.position = new Vector3(x2, y2, z2);
                TrashOBJ3.transform.position = new Vector3(x3, y3, z3);

            }




            return;
        }
    }

}
