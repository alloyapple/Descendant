using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionType					// TODO: Extend to receive what object/enemy/player etc. it gets applied to and where it came from (ancestor) ?
{
	
	public enum ActionTypeName
	{
		DealDamage,
		AddHealth,
		AddArmor
	}
	
	public bool 	_instantApply;
	
	public int 		_attackStrength;
	public int		_actionPoints;
	public float 	_coolDownTime;
	
	public float	_currentCoolDownTime;
	
	#region MainMethods
	
	public void ProcessAction( ActionTypeName currentAction)
	{
		switch(currentAction)
		{
			case ActionTypeName.DealDamage:
			{
				ApplyDamage();
				break;
			}
		
		}
	}
	
	#endregion
	
	#region AppliedMethods
	
	public void ApplyDamage()
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
