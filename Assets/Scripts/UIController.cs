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
	
	Ancestor _ancestor;
	
	void Start()
	{
		_ancestor = GameContext.currentInstance.ancestor;
		
		VictoryScreen.SetActive (false);
		
		_intervalIndicator.value = 0;
		_heroHealth.value = 1;
		_enemyHealth.value = 1;
	}
	
	void Awake()
	{
		GameContext.currentInstance.uiController = this;
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
				break;
			}
			case 2:
			{
				break;
			}
			case 3:
			{
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