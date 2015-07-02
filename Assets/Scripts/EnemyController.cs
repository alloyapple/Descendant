using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	public ActionType		_autoAction;
	public ActionType		_action1;
	public ActionType		_action2;

	public float			_attackRate;

	public GameObject		_target;
	public CombatController _combatController;

	public ActionType	_actionToPassCombat;

	public EnemyManager _enemyManger;

	private float 		m_currentInterval; //how far into the current interval are we?
	private bool 		m_hasAction; //has the entity activated an action?

	private ActionType	m_queuedAction;

	#region Interval Methods

	void Start()
	{
		_target = FindObjectOfType<HeroController> ().gameObject;
	}
	
	private void RunInterval()
	{
		//Debug.Log ("RunInterval()");
		m_currentInterval += Time.deltaTime;
		
		//		m_uiController.UpdateIntervalIndicator(m_currentInterval/_combatInterval);
		
		if (m_currentInterval >= _attackRate)
		{
			CompleteInterval();
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

	public void ActivateAction(ActionType action)
	{
		Debug.Log("Enemy Action!!");
		
		//Activate the player action
		_actionToPassCombat = action;	// TODO: just pass action straight on to combatcontroller

		_actionToPassCombat._actionCaster = this.gameObject;

		_combatController.AddActionToEnemyQueue (_actionToPassCombat);
	}

	public void SetQueuedAction(ActionType action)
	{
		m_queuedAction = action;
	}
}
