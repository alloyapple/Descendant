using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace pocketjam15.descendant
{
	public class CombatController : MonoBehaviour {

		//TODO: process Action/Input List

		public float _combatInterval;		//full interval used for this entity

		public List<Ancestor>		_ancestorList;
		public List<EntityWrapper> 	_actionList;
		public Queue<EntityWrapper>	_actionQueue;
		public GameObject			_playerGo;

		private float m_currentInterval;	//how far into the current interval are we?
		private bool m_instantAction;		//has the entity activated an instant action?
		private bool m_queuedAction;		//has the entity activated queued action?
		
		UIController m_uiController;

		// Use this for initialization
		void Start () {
			ResetInterval(); //Set up initial interval information
			m_uiController = GameContext.currentInstance.uiController;

			_actionList = new List<EntityWrapper> ();

			// TEST ONLY!
			for (int i = 0; i<3; i++) {

//				EntityWrapper newItem = new EntityWrapper(
			}
		}

		void Awake (){
			GameContext.currentInstance.combatController = this;
		}
		
		void Update () {
			RunInterval();
		}

		private void ResetInterval()
		{
			Debug.Log ("ResetInterval()");
			m_currentInterval = 0f;
			m_instantAction = false;
			m_queuedAction = false;
		}

		private void CompleteInterval()
		{
			if (m_queuedAction)
			{
				//activate queued attack
			}
			else if(!m_instantAction)
			{
				//activate auto attack
			}

			ResetInterval();
		}

		private void RunInterval()
		{
			m_currentInterval += Time.deltaTime;

			m_uiController.UpdateIntervalIndicator(m_currentInterval/_combatInterval);

			if (m_currentInterval >= _combatInterval)
			{
				CompleteInterval();
				ApplyQueuedActions();
			}
		}

		private void CollectInput()
		{
			// TEST ONLY INPUT
			if (Input.GetKeyUp (KeyCode.Space)) {

			}
		}

		private void ApplyQueuedActions()
		{
			for (int i = 0; i < _actionList.Count; i++) {

				EntityWrapper currentItem = _actionList[i];
				currentItem._actionType.ProcessAction(currentItem._actionType._type);
			}
		}


	}
}