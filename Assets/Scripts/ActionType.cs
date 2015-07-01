using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionType : MonoBehaviour
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

	public GameObject _actionCaster;
	public GameObject _actionReceiver;
	private EntityMain m_actionCasterEntity;
	private EntityMain m_actionReceiverEntity;

//	public ActionType ( GameObject CasterGo, GameObject ReceiverGo )
//	{
//		// TODO: Have list for multiple receivers
//
//		_actionCaster = CasterGo;
//		_actionReceiver = ReceiverGo;
//
//		if (_actionCaster != null && _actionReceiver != null) 
//		{
//			m_actionCasterEntity = _actionCaster.GetComponent<EntityMain>();
//			m_actionReceiverEntity = _actionReceiver.GetComponent<EntityMain>();
//
//			Debug.Log("Set Caster and Receiver");
//			
//		}
//	}

	void Start()
	{
		if (_actionCaster != null && _actionReceiver != null) 
		{
			m_actionCasterEntity = _actionCaster.GetComponent<EntityMain>();
			m_actionReceiverEntity = _actionReceiver.GetComponent<EntityMain>();
			
			Debug.Log("Set Caster and Receiver");
			
		}
	}

	#endregion
	
	#region MainMethods
	
	public void ProcessAction( ActionTypeName currentAction)
	{
		switch (currentAction) {
		case ActionTypeName.DealDamage:
			{
				if (m_actionReceiverEntity != null)
				{
					m_actionReceiverEntity.ApplyDamage(_damageAmount);
				}
				break;
			}
		case ActionTypeName.AddHealth:
			{
				if (m_actionCasterEntity != null)
				{
					m_actionCasterEntity.AddHealth(_healAmount);
				}
				break;
			}
		case ActionTypeName.AddArmor:
			{
				if (m_actionCasterEntity != null)
				{
				m_actionCasterEntity.AddArmor(_armorAdd);
				}
				break;
			}

		case ActionTypeName.DetractArmor:
			{
				if (m_actionReceiverEntity != null)
				{
					m_actionReceiverEntity.DetractArmor(_armorDetract);
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
