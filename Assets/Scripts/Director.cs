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
	private EnemyManager m_currentEnemyManger;

	void Start()
	{
		_uiController = FindObjectOfType<UIController>();

		m_playerClassNum = GameObject.FindObjectOfType<AncestorSelection>().selectedAncestor;

		if(m_playerClassNum==0){
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

		m_currentEnemyManger = FindObjectOfType<EnemyManager>();
		if ( m_currentEnemyManger == null )
			Debug.LogWarning("Director couldn't find Enemy Manager");
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
		Debug.Log ("Victory! - End game screen to be called");
		_uiController.Victory();
	}

	public void Loss()
	{
		Debug.Log ("Game Over! - End game screen to be called");
		_uiController.Loss();
	}

}