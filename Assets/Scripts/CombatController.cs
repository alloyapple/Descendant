using UnityEngine;
using System.Collections;

namespace pocketjam15.descendant
{
	public class CombatController : MonoBehaviour {
		
		public float _combatInterval;		//full interval used for this entity

		private float m_currentInterval;	//how far into the current interval are we?
		private bool m_instantAction;		//has the entity activated an instant action?
		private bool m_queuedAction;		//has the entity activated queued action?
		
		UIController m_uiController;

		// Use this for initialization
		void Start () {
			ResetInterval(); //Set up initial interval information
			m_uiController = GameContext.currentInstance.uiController;
		}

		void Awake (){
			GameContext.currentInstance.combatController = this;
		}
		
		// Update is called once per frame
		void Update () {
			RunInterval();
		}

		private void ResetInterval()
		{
			Debug.Log ("ResetInterval()");
			m_currentInterval = 0f;
			m_instantAction = false;
			m_intervalAction = false;
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
			}
		}

	}
}