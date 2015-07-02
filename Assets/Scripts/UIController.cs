using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
	
	public GameObject ExitButton;
	public GameObject VictoryScreen;
	
	public Slider _intervalIndicator;
	public Slider _heroHealth;
	public Slider _heroEnergy;
	public Slider _enemyHealth;

	public Image _playerIcon;
	public Image _button1;
	public Image _button2;
	public Image _button3;

	Ancestor _ancestor;
	
	void Start()
	{
		_ancestor = FindObjectOfType<AncestorSelection>().selectedAncestor;

		VictoryScreen.SetActive (false);
		
		_intervalIndicator.value = 0;
		_heroHealth.value = 1;
		_enemyHealth.value = 1;
		
		_playerIcon.transform.GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._ancestorIcon;
		_button1.transform.GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._action1._actionIcon;
		_button2.transform.GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._action2._actionIcon;
		_button3.transform.GetComponent<UnityEngine.UI.Image>().sprite = _ancestor._action3._actionIcon;

	}
	
	public void ExitGame()
	{
		Application.LoadLevel("Menu");
	}
	
	public void ActivateAction(int actionNum)
	{
		switch (actionNum) {
			case 1:
			{
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