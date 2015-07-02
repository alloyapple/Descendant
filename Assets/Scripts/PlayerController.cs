using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	HeroController _descendantController;
	
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
