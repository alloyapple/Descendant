using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Director : MonoBehaviour 
{

	UIController _uiController;
	
	void Start()
	{
		_uiController = GameContext.currentInstance.uiController;
	}

	void Awake()
	{
		Application.LoadLevelAdditive("UI");
		GameContext.currentInstance.director = this;
	}


	public void Victory()
	{
		Debug.Log (_uiController);
		_uiController.Victory();
	}

}