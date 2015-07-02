﻿using UnityEngine;
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

	public AncestorClasses	_playerAncestor;

	public GameObject 	_ancestorGo;				// handle gfx etc.
	public int 			_attackPoints;
	public int			_armorAddition;
	public int			_healthAddition;

	// Armor buffs can be percentages and then we can round up or down to an int value
	public float 		_armorBuff;					
	public float		_healthBuff;
	
	public ActionType	_autoAction;
	public ActionType	_action1;
	public ActionType	_action2;
	public ActionType	_action3;

	public ActionType	_actionToPassCombat;
	private ActionType	m_queuedAction;

	// TODO: List for actionTypes

	UIController m_uiController;
	
	public float _combatInterval; //full interval used for this entity

	private EntityMain	m_target;
	private float 		m_currentInterval; //how far into the current interval are we?
	private bool 		m_hasAction; //has the entity activated an action?

	public void Start()
	{
		m_uiController = GameContext.currentInstance.uiController;
		SetQueuedAction(_autoAction);
		m_hasAction = false;
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

	//Interval System
	
	void Update () 
	{
		RunInterval();
	}
	public void SetAction(ActionType pendingAction)
	{
		//TODO: When we have energy add check here
		if (!m_hasAction)
		{
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

	public void SetQueuedAction(ActionType action)
	{
		m_queuedAction = action;
	}

	public void ActivateAction(ActionType action)
	{
		Debug.Log("POW! Attack");
		//Activate the player action
		_actionToPassCombat = action;
	}
	
	private void ResetInterval()
	{
		m_hasAction = false;
		m_currentInterval = 0f;
		SetQueuedAction(_autoAction);
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
	
	private void RunInterval()
	{
		//Debug.Log ("RunInterval()");
		m_currentInterval += Time.deltaTime;
		
		m_uiController.UpdateIntervalIndicator(m_currentInterval/_combatInterval);
		
		if (m_currentInterval >= _combatInterval)
		{
			CompleteInterval();
		}
	}

}

