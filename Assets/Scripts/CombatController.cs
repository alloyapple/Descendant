using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatController : MonoBehaviour {

	//TODO: process Action/Input List

	public float _combatInterval;		//full interval used for this entity

	public List<Ancestor>		_ancestorList;
	public List<EntityWrapper> 	_actionList;
	public Queue<EntityWrapper>	_actionQueue;
	public GameObject			_TestplayerGo;
	public GameObject			_TestenemyGo;
	public GameObject			_TestActionGo;
	

	private float m_currentInterval;	//how far into the current interval are we?
	private bool m_instantAction;		//has the entity activated an instant action?
	private bool m_queuedAction;		//has the entity activated queued action?

	private EntityMain 			m_currentTestPlayerEntity;
	private EntityMain 			m_currentTestEnemyEntity;
	private ActionType			m_currentTestAction;
	
	UIController m_uiController;

	// Use this for initialization
	void Start () {
		ResetInterval(); //Set up initial interval information
		m_uiController = GameContext.currentInstance.uiController;

		// TEST ONLY!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		
		m_currentTestPlayerEntity = _TestplayerGo.GetComponent<EntityMain> ();
		m_currentTestEnemyEntity = _TestenemyGo.GetComponent<EntityMain> ();
		m_currentTestAction = _TestActionGo.GetComponent<ActionType> ();
		

		if (m_currentTestPlayerEntity != null && m_currentTestEnemyEntity != null && m_currentTestAction != null) 
		{
			_actionList = new List<EntityWrapper> ();

			for (int i = 0; i < 3; i++) 
			{
				EntityWrapper newItem = new EntityWrapper( m_currentTestPlayerEntity, m_currentTestAction );
				_actionList.Add(newItem);
			}
		} 
		else 
		{
			Debug.LogWarning("There are no entities to Test with");
		}
	}

	void Awake (){
		GameContext.currentInstance.combatController = this;
	}
	
	void Update () {
		RunInterval();
		CollectInput();

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

		if(m_uiController != null)
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
		if (Input.GetKeyUp (KeyCode.Space)) 
		{
			ApplyQueuedActions();
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