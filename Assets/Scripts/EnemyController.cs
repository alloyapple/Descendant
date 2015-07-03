using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	// EnemeyController type is very similar to Ancestor function
	public ActionType		_autoAction;
	public ActionType		_action1;
	public ActionType		_action2;

	public float			_attackRate;

	public GameObject		_target;
	public GameObject		_instanceRef;
	public CombatController _combatController;

	public ActionType	_actionToPassCombat;

	public EnemyManager _enemyManger; // TODO: !!!!!!!! use this to execute death mode, also known 

	private EntityMain _EntityController;

	private float 		m_currentInterval; //how far into the current interval are we?
	private bool 		m_hasAction; //has the entity activated an action?

	private ActionType	m_queuedAction;

	private UIController m_uiController;
	private AniStateController m_aniController;

	#region Interval Methods

	void Start()
	{
		_target = FindObjectOfType<HeroController> ().gameObject;
		_actionToPassCombat = _autoAction;
		_EntityController = this.gameObject.GetComponent<EntityMain> ();
		m_aniController = gameObject.GetComponent<AniStateController> ();

		if (m_aniController == null)
			Debug.LogWarning ("No Animation Controller on Enemy!");
	}

	
	void Update () 
	{
		if ( _EntityController.Death() ) 
		{
			Debug.LogWarning("Enemy killed!!!!");

			if (m_aniController!=null)
			{
				m_aniController.StartCoroutine("DeathState", 0.25f );
			}

			Destroy (this.gameObject);
			_enemyManger.SpawnNewEnemy();
		}

		RunInterval();
		if(m_uiController != null)
		{
			m_uiController.UpdateEnemyHealth((float)_EntityController._health / _EntityController._healthMax);
		}
	}

	public void PassUI(UIController ui)
	{
		m_uiController = ui;
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
//		if(_actionToPassCombat==null)
//		{
//			//No action has been activated yet - ie. no instant action!
		ActivateAction(_actionToPassCombat);
//		}
		// TODO: Figure out Activate Action Integration so hero can take damage
		ResetInterval();
	}
	
	private void ResetInterval()
	{
		m_hasAction = false;
		m_currentInterval = 0f;
		SetQueuedAction(_autoAction);
//		_actionToPassCombat = null;
	}
	
	#endregion

	public void ActivateAction(ActionType action)
	{
//		Debug.LogWarning("Enemy Action!! " + action + " Gameobject " + _instanceRef);
		
		//Activate the player action
		_actionToPassCombat = action;	// TODO: just pass action straight on to combatcontroller

		_actionToPassCombat._actionCaster = _instanceRef;

		_combatController.AddActionToEnemyQueue (_actionToPassCombat);
	}

	public void SetQueuedAction(ActionType action)
	{
//		m_queuedAction = action;
	}

	// TODO: !!!!!!!!!!! add death situation here, remove enemy and speak to enemy manger to spawn a new one
}
