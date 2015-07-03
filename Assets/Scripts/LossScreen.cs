using UnityEngine;
using System.Collections;

public class LossScreen : MonoBehaviour {

	void Start()
	{

	}

	public void LoadClassSelect()
	{
		Debug.Log("Hello");
		Application.LoadLevel ("ClassSelect");
	}
}
