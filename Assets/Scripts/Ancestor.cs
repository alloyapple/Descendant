using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Ancestor : MonoBehaviour {

	// Abilities, point in time

	public enum AncestorClasses
	{
		Warrior,
		Healer,
		DPSMelee,
		DPSRange,
		Enemy01,
		Enemy02
	}

	public AncestorClasses	_playerAncestor;

//	public GameObject 	_ancestorGo;				// TODO: handle gfx etc. use later
	public int 			_damageAddition;
	public int			_armorAddition;
	public int			_healthAddition;

	// Armor buffs can be percentages and then we can round up or down to an int value
	public float 		_armorBuff;					
	public float		_healthBuff;
	
	public ActionType	_autoAction;
	public ActionType	_action1;
	public ActionType	_action2;
	public ActionType	_action3;

	public bool			_isPlayer;
	
	public Sprite	_ancestorIcon;
	public Sprite	_ancestorBg;

	public ActionType	_actionToPassCombat;
	private ActionType	m_queuedAction;

	private CombatController m_currentCombatController;
	private HeroController m_currentHeroController;

	// TODO: List for actionTypes

	public UIController _uiController;
	
	public float _combatInterval; //full interval used for this entity

	private EntityMain	m_target;
	private float 		m_currentInterval; //how far into the current interval are we?
	private bool 		m_hasAction; //has the entity activated an action?

	public void Awake()
	{


		SetQueuedAction(_autoAction);
		m_hasAction = false;


		RegisterWithControllers ();
	}

	public void PassUI(UIController ui)
	{
		_uiController = ui;
	}
	
	void Update () 
	{
		RunInterval();
	}

#region Action Type Manager

	public void SetAction(ActionType pendingAction)
	{
		Debug.Log("SET THIS ACTION: "+pendingAction);

		if (!m_hasAction)
		{
			if(pendingAction._energyCost < _uiController._currentEnergy)
			{
				_uiController.ReduceEnergy(pendingAction._energyCost);

				//No action has yet been set
				m_hasAction = true;
				
				if(pendingAction._instantApply)
				{
					//We have an instant action
					ActivateAction(pendingAction);
				}
				else
				{
					//We have a queued action
					SetQueuedAction(pendingAction);
				}
			}
		}
	}

	public void SetQueuedAction(ActionType action)
	{
		m_queuedAction = action;
	}

	public void ActivateAction(ActionType action)
	{
		Debug.Log("POW! Attack");

		//Activate the player action
		_actionToPassCombat = action;	// TODO: just pass action straight on to combatcontroller

		m_currentCombatController.AddActionToPlayerQueue (_actionToPassCombat);
	}

#endregion

#region Interval Methods

	private void RunInterval()
	{
		if(_uiController!=null)
		{
			m_currentInterval += Time.deltaTime;
			_uiController.UpdateIntervalIndicator(m_currentInterval/_combatInterval);
			
			if (m_currentInterval >= _combatInterval)
			{
				CompleteInterval();
			}
		}
	}

	private void CompleteInterval()
	{
		if(_actionToPassCombat==null)
		{
			//No action has been activated yet - ie. no instant action!
			ActivateAction(m_queuedAction);
		}
		ResetInterval();
	}

	private void ResetInterval()
	{
		m_hasAction = false;
		m_currentInterval = 0f;
		SetQueuedAction(_autoAction);
		_actionToPassCombat = null;
	}

#endregion

#region Placeholder methods and expansions

	public void RegisterWithControllers()
	{
		Debug.Log("RegisterWithControllers()");
		m_currentCombatController = FindObjectOfType<CombatController>();
		Debug.Log (m_currentCombatController);
		m_currentHeroController = FindObjectOfType<HeroController> ();

		if (m_currentCombatController == null || m_currentHeroController == null) {
			Debug.LogWarning ("No Hero and/or CombatController found!");
		}
		else
		{
			m_currentCombatController._ancestorList.Add ( this );
			m_currentHeroController._ancestorList.Add ( this );
		}
	}

	public void UpdateAncestorStats()
	{
		// feeds in any values that are relevant to a stat change that then the player can execute
	}
	
	public bool CriticalHit()
	{
		// find out if critical hit chance is given ?? TODO: Critical hit leave to later
		return false;
	}

#endregion
}

