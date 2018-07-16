using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDtn : MonoBehaviour {

	public GameObject obj;
	public GameObject Own;


	public void OnMouseDown()
	{

		obj.SetActive (false);
		Own.SetActive (false);


	}

}
