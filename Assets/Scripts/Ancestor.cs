using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ancestor : MonoBehaviour {

	// Abilities, point in time

	public enum AncestorClasses
	{
		Warrior,
		Healer,
		DPSMelee,
		DPSRange
	}

	public GameObject 	_ancestorGo;				// handle gfx etc.
	public int 			_attackPoints;
	public int			_armorAddition;
	public int			_healthAddition;

	// Armor buffs can be percentages and then we can round up or down to an int value
	public float 		_armorBuff;					
	public float		_healthBuff;

	public void UpdateAncestorStats()
	{
		// feeds in any values that are relevant to a stat change that then the player can execute
	}

	public void InstaAttack()
	{

	}

	public void QueuedAttack()
	{

	}

	public bool CriticalHit()
	{
		// find out if critical hit chance is given ?? TODO: Critical hit leave to later
		return false;
	}

}



