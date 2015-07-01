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
		AddArmor,
		DetractArmor
	}
	
	public bool 			_instantApply;

	public ActionTypeName	_type;
	
	public int 		_damageAmount;
	public int 		_damageAmountOT;			// TODO: OT = over time, test if work while being processed in list
	public int		_healAmount;
	public int		_healAmountOT;
	public int 		_armorAdd;
	public int 		_armorAddOT;
	public int		_armorDetract;
	public int		_armorDetractOT;

	public int		_actionPoints;				// TODO: Counter Calculate Cost of action
	
	public float 	_coolDownTime;
	public float	_currentCoolDownTime;

	private GameObject m_ActionCaster;
	private GameObject m_ActionReceiver;
	private EntityMain m_ActionCasterEntity;
	private EntityMain m_ActionReceiverEntity;

	public ActionType ( GameObject CasterGo, GameObject ReceiverGo )
	{
		// TODO: Have list for multiple receivers

		m_ActionCaster = CasterGo;
		m_ActionReceiver = ReceiverGo;

		if (m_ActionCaster != null && m_ActionReceiver != null) 
		{
			m_ActionCasterEntity = m_ActionCaster.GetComponent<EntityMain>();
			m_ActionReceiverEntity = m_ActionCaster.GetComponent<EntityMain>();
		}
	}

	#endregion
	
	#region MainMethods
	
	public void ProcessAction( ActionTypeName currentAction)
	{
		switch (currentAction) {
		case ActionTypeName.DealDamage:
			{
				if (m_ActionReceiverEntity != null)
				{
					m_ActionReceiverEntity.ApplyDamage(_damageAmount);
				}
				break;
			}
		case ActionTypeName.AddHealth:
			{
				if (m_ActionCasterEntity != null)
				{
					m_ActionCasterEntity.AddHealth(_healAmount);
				}
				break;
			}
		case ActionTypeName.AddArmor:
			{
				if (m_ActionCasterEntity != null)
				{
				m_ActionCasterEntity.AddArmor(_armorAdd);
				}
				break;
			}

		case ActionTypeName.DetractArmor:
			{
				if (m_ActionReceiverEntity != null)
				{
					m_ActionReceiverEntity.DetractArmor(_armorDetract);
				}
				break;
			}
		}
	}
	
	#endregion
	
	#region AppliedMethods

	public bool CoolDownRunning()						// TODO: GFX tie in
	{
		if (!_instantApply) 
		{
			_currentCoolDownTime = _coolDownTime;
		
			while (_currentCoolDownTime > 0f) {
				_currentCoolDownTime -= Time.deltaTime;
			
				return true;
			}
			return false;
		}
		return false;
	}
	
	#endregion
	
}
