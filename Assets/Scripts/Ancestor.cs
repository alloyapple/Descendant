using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace pocketjam15.descendant
{

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
		
		public ActionType	_autoAction;
		public ActionType	_action1;
		public ActionType	_action2;
		public ActionType	_action3;

		UIController m_uiController;
		
		public float _combatInterval; //full interval used for this entity

		private EntityMain target;

		private float m_currentInterval; //how far into the current interval are we?

		private bool m_hasInstant; //has the entity activated an instant action?
		private ActionType m_instantAction; 

		private bool m_hasQueued; //has the entity activated a queued action?
		private ActionType m_queuedAction;

		public void Start()
		{
			m_uiController = GameContext.currentInstance.uiController;
		}

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

		//Interval System
		
		void Update () 
		{
			RunInterval();
		}

		public void ActivateAutoAction()
		{
			Debug.Log("BOOM! Auto Attack");
			//process action
		}

		public void ActivateQueuedAction()
		{
			Debug.Log("POW! QUEUED Attack");
			//process action
		}

		public void ActivateInstantAction()
		{
			Debug.Log("BAMF! Instant Attack");
			m_hasInstant = true;
			//process action
		}

		public void QueueAction(ActionType action)
		{
			m_hasQueued = true;
			m_queuedAction = action;
		}

		private void ResetInterval()
		{
			//Debug.Log ("ResetInterval()");
			m_currentInterval = 0f;
			m_hasInstant = false;
			m_hasQueued = false;
		}
		
		private void CompleteInterval()
		{
			//Debug.Log ("CompleteInterval()");
			if (m_queuedAction)
			{
				ActivateQueuedAction();
			}
			else if(!m_instantAction)
			{
				ActivateAutoAction();
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

}

