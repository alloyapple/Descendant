using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace pocketjam15.descendant
{
	public class UIController : MonoBehaviour 
	{

		public GameObject ExitButton;

		public GameObject VictoryScreen;

		public Slider _intervalIndicator;

		PlayerController _playerController;
		
		void Start()
		{
			_playerController = GameContext.currentInstance.playerController;
			VictoryScreen.SetActive (false);
			_intervalIndicator.value = 0;
		}

		void Awake()
		{
			GameContext.currentInstance.uiController = this;
		}

		public void ExitGame()
		{
			Application.LoadLevel("Menu");
		}

		public void Ability(int abilityNum)
		{
			_playerController.ActivateAbility(abilityNum);
		}

		public void Victory()
		{
			VictoryScreen.SetActive (true);
		}

		public void UpdateIntervalIndicator(float m_progress)
		{
			_intervalIndicator.value = m_progress;
		}

	}
}
