using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ActionType			
{
	#region Variables and Constructors

	public enum ActionTypeName
	{
		None,
		DealDamage,
		AddHealth,
		AddArmor
	}
	
	public bool 	_instantApply;
	
	public int 		_attackStrength;
	public int 		_attackStrengthOT;
	public int		_healAmount;
	public int		_healAmountOT;
	public int		_actionPoints;				// TODO: Counter Calculate Cost of action
	
	public float 	_coolDownTime;
	public float	_currentCoolDownTime;

	private GameObject m_ActionCaster;
	private GameObject m_ActionReceiver;

	public ActionType ( GameObject CasterGo, GameObject ReceiverGo )
	{
		// TODO: Have list for multiple receivers
		
	}

	#endregion
	
	#region MainMethods
	
	public void ProcessAction( ActionTypeName currentAction)
	{
		switch (currentAction) {
		case ActionTypeName.DealDamage:
			{
				ApplyDamage ();
				break;
			}
		case ActionTypeName.AddHealth:
			{
				AddHealth ();
				break;
			}
		case ActionTypeName.AddHealth:
			{
				AddArmor ();
				break;
			}
		}
	}
	
	#endregion
	
	#region AppliedMethods
	
	public void ApplyDamage()
	{
														// TODO: receive objects to apply etc.
	}
	public void AddHealth()
	{
	
	}
	public void AddArmor()
	{

	}
	
	public bool CoolDownRunning()						// TODO: GFX tie in
	{
		_currentCoolDownTime = _coolDownTime;
		
		while (_currentCoolDownTime > 0f) 
		{
			_currentCoolDownTime -= Time.deltaTime;
			
			return true;
		}
		
		return false;
	}
	
	#endregion
	
}
