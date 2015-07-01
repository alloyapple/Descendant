using UnityEngine;
using System.Collections;

namespace pocketjam15.descendant
{
	public class UIController : MonoBehaviour 
	{

		public GameObject ExitButton;

		public GameObject VictoryScreen;

		PlayerController _playerController;
		
		void Start()
		{
			_playerController = GameContext.currentInstance.playerController;
			VictoryScreen.SetActive (false);
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

	}
}
