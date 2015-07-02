using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatController : MonoBehaviour {

	//TODO: process Action/Input List
	//TODO: let attackrate set combatInterval

	public float _combatIntervalHero;		//full interval used for this entity

	public List<Ancestor>		_ancestorList;
	public List<EntityWrapper> 	_actionList;
//	public Queue<EntityWrapper>	_actionQueue;
	public Queue<ActionType>	_actionQueue;
	public Queue<ActionType>	_enemyActionQueue;	// TODO: add dequeue method when enemy dies
	
	public GameObject			_TestplayerGo;
	public GameObject			_TestenemyGo;	// TODO: Find Enemy, or spawn enemy and add to combatController
	public GameObject			_TestActionGo;

	public HeroController		_HeroMain;		// TODO: take Hero Controller attackRate as queue workdown

	private float m_currentInterval;	//how far into the current interval are we?
	private bool m_instantAction;		//has the entity activated an instant action?
	private bool m_queuedAction;		//has the entity activated queued action?

	private EntityMain 			m_currentTestPlayerEntity;
	private EntityMain 			m_currentTestEnemyEntity;
	private ActionType			m_currentTestAction;
	
//	UIController m_uiController;

	// Use this for initialization
	void Start () 
	{
		ResetInterval(); //Set up initial interval information

//		m_uiController = GameContext.currentInstance.uiController;
//		_actionQueue = new Queue<EntityWrapper> ();
		_actionQueue = new Queue<ActionType> ();
		_enemyActionQueue = new Queue<ActionType> ();

		_HeroMain = FindObjectOfType<HeroController> ();

		if (_HeroMain != null) 
		{
			_combatIntervalHero = _HeroMain._attackRate;
		} 
		else 
		{
			Debug.LogWarning("No HeroController found for CombatController to work with");
		}

		// TEST ONLY!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		// TODO: Remove Test Cases
//		m_currentTestPlayerEntity = _TestplayerGo.GetComponent<EntityMain> ();
//		m_currentTestEnemyEntity = _TestenemyGo.GetComponent<EntityMain> ();
//		m_currentTestAction = _TestActionGo.GetComponent<ActionType> ();
//		
//
//		if (m_currentTestPlayerEntity != null && m_currentTestEnemyEntity != null && m_currentTestAction != null) 
//		{
//			_actionList = new List<EntityWrapper> ();
//
//			for (int i = 0; i < 3; i++) 
//			{
//				EntityWrapper newItem = new EntityWrapper( m_currentTestPlayerEntity, m_currentTestAction );
//				_actionList.Add(newItem);
//			}
//		} 
//		else 
//		{
//			Debug.LogWarning("There are no entities to Test with");
//		}

		// TEST END ////////////////////////////////////////////////////
	}

	void Awake ()
	{
//		GameContext.currentInstance.combatController = this;
	}
	
	void Update () 
	{
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

//		if(m_uiController != null)
//			m_uiController.UpdateIntervalIndicator(m_currentInterval/_combatInterval);

		if (m_currentInterval >= _combatIntervalHero)
		{
			CompleteInterval();
			ApplyQueuedAction();
		}
	}

	private void CollectInput()
	{
		// TODO: expand to mouse input
	}

	private void ApplyQueuedAction()
	{
//		for (int i = 0; i < _actionList.Count; i++) {
//
//			EntityWrapper currentItem = _actionList[i];
//			currentItem._actionType.ProcessAction(currentItem._actionType._type);
//		}
		if (_actionQueue.Count > 0) 
		{
			ActionType currentAction = _actionQueue.Dequeue();

			currentAction.SetCasterReceiver( _HeroMain.gameObject, _TestenemyGo );
			currentAction.ProcessAction( currentAction._type );
		} 
		else 
		{
			Debug.LogWarning("No Actions in Queue");
		}
	}

	private void ApplyEnemyAction()
	{
		if (_enemyActionQueue.Count > 0) 
		{
			ActionType currentAction = _enemyActionQueue.Dequeue();
			
			currentAction.SetCasterReceiver( currentAction._actionCaster, _HeroMain.gameObject );
			currentAction.ProcessAction( currentAction._type );
		} 
		else 
		{
			Debug.LogWarning("No Actions in Queue");
		}
	}

//	public void AddActionToQueue( EntityWrapper actionToAdd)
//	{
//		_actionQueue.Enqueue (actionToAdd);
//	}
	public void AddActionToPlayerQueue( ActionType actionToAdd)
	{
		_actionQueue.Enqueue (actionToAdd);
	}
	public void AddActionToEnemyQueue( ActionType actionToAdd)
	{
		_enemyActionQueue.Enqueue (actionToAdd);
	}



}