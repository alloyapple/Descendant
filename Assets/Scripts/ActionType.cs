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

	public Sprite	_actionIcon;

	public int		_energyCost;

	public float 	_coolDownTime;
	public float	_currentCoolDownTime;

	public GameObject _actionCaster;
	public GameObject _actionReceiver;
	private EntityMain m_actionCasterEntity;
	private EntityMain m_actionReceiverEntity;
	
	public GameObject 	_initialEffect;			//Effect cast on animation start
	public bool 		_initialEffectOnCaster;	//Is it on the caster?
	public GameObject 	_impactEffect;			//Effect cast on ability impact
	public bool 		_impactEffectOnCaster;	//Is it on the caster?
	
	private GameObject _initialHolder;
	private GameObject _impactHolder;

//	public ActionType ( GameObject CasterGo, GameObject ReceiverGo )
//	{

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
		SetCasterReceiver (_actionCaster, _actionReceiver);
	}

	#endregion
	
	#region MainMethods
	
	public void ProcessAction( ActionTypeName currentAction)
	{
		ProcessEffects ();

		switch (currentAction) {
		case ActionTypeName.DealDamage:
			{
				if (m_actionReceiverEntity != null)
				{
					m_actionReceiverEntity.ApplyDamage(_damageAmount);
					Debug.Log ("Damage Dealt to: " + _actionReceiver.name); 
				}
				break;
			}
		case ActionTypeName.AddHealth:
			{
				if (m_actionCasterEntity != null)
				{
					m_actionCasterEntity.AddHealth(_healAmount);
					Debug.Log ("Health added to: " + _actionCaster.name); 
				}
				break;
			}
		case ActionTypeName.AddArmor:
			{
				if (m_actionCasterEntity != null)
				{
					m_actionCasterEntity.AddArmor(_armorAdd);
					Debug.Log ("Armor added to: " + _actionCaster.name); 
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

	public void ProcessEffects()
	{
		Vector3 m_initialPosition;
		Vector3 m_impactPosition;

		Debug.Log (m_actionReceiverEntity);

		if(_initialEffectOnCaster)
		{
			m_initialPosition = m_actionCasterEntity.transform.position;
		}
		else
		{
			m_initialPosition = m_actionReceiverEntity.transform.position;
		}
		if(_impactEffectOnCaster)
		{
			m_impactPosition = m_actionCasterEntity.transform.position;
		}
		else
		{
			m_impactPosition = m_actionReceiverEntity.transform.position;
		}

		if(_initialEffect != null)
		{
			_initialHolder = (GameObject) Instantiate (_initialEffect,m_initialPosition,transform.rotation);
			Destroy (_initialHolder,1f);
		}
		
		if(_impactEffect != null)
		{
			_impactHolder = (GameObject) Instantiate (_impactEffect,m_impactPosition,transform.rotation);
			Destroy (_impactHolder, 1f);
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

	public void SetCasterReceiver(GameObject caster, GameObject receiver)
	{
		// TODO: Have list for multiple receivers

		if (_actionCaster != caster) 
		{
			_actionCaster = caster;
		}
		if (_actionReceiver != receiver) 
		{
			_actionReceiver = receiver;
		}

//		_actionCaster = caster;
//		_actionReceiver = receiver;

		if (_actionCaster != null && _actionReceiver != null) 
		{
			m_actionCasterEntity = _actionCaster.GetComponent<EntityMain> ();
			m_actionReceiverEntity = _actionReceiver.GetComponent<EntityMain> ();
			
			Debug.Log ("Set Caster and Receiver");
		}
		else
		{
			Debug.LogWarning ("No Caster and Receiver Set!");
		}
	}
	
	#endregion
	
}