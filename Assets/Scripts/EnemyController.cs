using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	public ActionType		_action1;
	public ActionType		_action2;

	public float			_attackRate;

	public GameObject		_target;
	public CombatController _combatController;

	#region Interval Methods
	
//	private void RunInterval()
//	{
//		//Debug.Log ("RunInterval()");
//		m_currentInterval += Time.deltaTime;
//		
//		//		m_uiController.UpdateIntervalIndicator(m_currentInterval/_combatInterval);
//		
//		if (m_currentInterval >= _combatInterval)
//		{
//			CompleteInterval();
//		}
//	}
//	
//	private void CompleteInterval()
//	{
//		if(_actionToPassCombat==null)
//		{
//			//No action has been activated yet - ie. no instant action!
//			ActivateAction(m_queuedAction);
//		}
//		ResetInterval();
//	}
//	
//	private void ResetInterval()
//	{
//		m_hasAction = false;
//		m_currentInterval = 0f;
//		SetQueuedAction(_autoAction);
//		_actionToPassCombat = null;
//	}
	
	#endregion

}
