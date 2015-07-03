﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
	
	public GameObject ExitButton;
	public GameObject VictoryScreen;
	public GameObject LossScreen;
	
	
	public Slider _intervalIndicator;
	public Slider _heroHealth;
	public Slider _heroEnergy;
	public Slider _enemyHealth;

	public Image _playerIcon;
	public Image _button1;
	public Image _button2;
	public Image _button3;
	public Image _playerBg;

	Ancestor _ancestor;
	
	void Start()
	{
		//_ancestor = FindObjectOfType<Ancestor>();
		foreach(Ancestor ancestor in FindObjectsOfType<Ancestor>())
		{
			if (ancestor._isPlayer==true)
			{
				_ancestor = ancestor;
			}
		}
		_ancestor.PassUI(this);

		VictoryScreen.SetActive (false);
		
		_intervalIndicator.value = 0;
		_heroHealth.value = 1;
		_enemyHealth.value = 1;
		
		_playerIcon.transform.FindChild("Icon").GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._ancestorIcon;
		_playerIcon.transform.FindChild("Background").GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._ancestorBg;
		_button1.transform.FindChild("Icon").GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._action1._actionIcon;
		_button1.transform.FindChild("Background").GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._ancestorBg;
		_button2.transform.FindChild("Icon").GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._action2._actionIcon;
		_button2.transform.FindChild("Background").GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._ancestorBg;
		_button3.transform.FindChild("Icon").GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._action3._actionIcon;
		_button3.transform.FindChild("Background").GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._ancestorBg;
		ExitButton.transform.FindChild("Background").GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._ancestorBg;



	}
	
	public void ExitGame()
	{
		Application.LoadLevel("Menu");
		Destroy(FindObjectOfType<AncestorSelection>());
	}
	
	public void ActivateAction(int actionNum)
	{
		switch (actionNum) {
			case 1:
			{
			Debug.Log("SET THIS ACTION: "+actionNum);
			Debug.Log(_ancestor);
				Debug.Log(_ancestor._action1);
				_ancestor.SetAction(_ancestor._action1);
				break;
			}
			case 2:
			{
				_ancestor.SetAction(_ancestor._action2);
				break;
			}
			case 3:
			{
				_ancestor.SetAction(_ancestor._action3);
				break;
			}
		}
	}
	
	public void Victory()
	{
		VictoryScreen.SetActive (true);
	}

	public void Loss()
	{
		LossScreen.SetActive (true); // TODO: Link loss screen
	}
	
	public void UpdateIntervalIndicator(float m_progress)
	{
		_intervalIndicator.value = m_progress;
	}
	
	public void SetIntervalIndicatorState(bool active)
	{
		if(active)
		{
			
		}else{
			
		}
	}
	
	public void UpdateEnemyHealth(float health)
	{
		_enemyHealth.value = health;
	}
	
	public void UpdateHeroHealth(float health)
	{
		_heroHealth.value = health;
	}
	
}