using UnityEngine;
using System.Collections;

namespace pocketjam15.descendant
{
	public class PlayerController : MonoBehaviour {

		DescendantController _descendantController;
		
		void Start()
		{
			_descendantController = GameContext.currentInstance.descendantController;
		}

		void Awake()
		{
			GameContext.currentInstance.playerController = this;
		}

		public void ActivateAbility(int abilityNum)
		{
			_descendantController.AutoAttack();
		}

	}
}
