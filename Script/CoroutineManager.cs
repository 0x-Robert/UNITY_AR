using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour {

    public GameObject obj1;
    public GameObject obj2;

    public GameObject obj3;




    void Start ()
    {
        obj1.SetActive(false);
        obj2.SetActive(false);
        obj3.SetActive(false);
        StartCoroutine(testCoroutine());
	}
	
   public  IEnumerator testCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        obj1.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        obj2.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        obj3.SetActive(true);
        yield break;
    }
	
}
