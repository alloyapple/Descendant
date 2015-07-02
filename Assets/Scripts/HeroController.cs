using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HeroController : MonoBehaviour {

	public int _health;
	public int _armor;
	public int _damage;
	public int _actionPoints;

	EnemyController _enemyController;

	void Start()
	{
		_enemyController = GameContext.currentInstance.enemyController;
	}

	void Awake()
	{
		GameContext.currentInstance.descendantController = this;
	}

	public void TakeDamage(int damage)
	{
		_health = _health - damage;
	}

	public void AutoAttack ()
	{
		_enemyController.TakeDamage(5);
	}

	// TODO: Wrapper/Class needed for an attack, like an attack package

}
