using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Director : MonoBehaviour 
{

	UIController _uiController;
	
	void Start()
	{
		_uiController = FindObjectOfType<UIController>();
	}

	void Awake()
	{
		Application.LoadLevelAdditive("UI");
	}


	public void Victory()
	{
		Debug.Log (_uiController);
		_uiController.Victory();
	}

}