using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Director : MonoBehaviour 
{

	UIController _uiController;
	
	public Ancestor _warrior;
	public Ancestor _priest;
	public Ancestor _mage;
	public Ancestor _rogue;

	public Ancestor _selectedAncestor;

	private int m_playerClassNum;

	void Start()
	{
		_uiController = FindObjectOfType<UIController>();

		m_playerClassNum = GameObject.FindObjectOfType<AncestorSelection>().selectedAncestor;

		if(m_playerClassNum==null){
			m_playerClassNum = 1;
		}

		switch(m_playerClassNum){
			case 1:
		{
			_warrior._isPlayer = true;
			Instantiate(_warrior);
			_warrior._isPlayer = false;
				break;
			}
			case 2:
		{
			_priest._isPlayer = true;
			Instantiate(_priest);
			_priest._isPlayer = false;
				break;
			}
			case 3:
		{
			_mage._isPlayer = true;
			Instantiate(_mage);
			_mage._isPlayer = false;
				break;
			}
			case 4:
		{
			_rogue._isPlayer = true;
			Instantiate(_rogue);
			_rogue._isPlayer = false;
				break;
			}
		}
		AddOtherAncestors();
	}

	void AddOtherAncestors()
	{
		
		Instantiate(_priest);
		Instantiate(_mage);
		Instantiate(_rogue);
		Instantiate(_warrior);
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