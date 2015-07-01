using UnityEngine;
using System.Collections;

public class CombatController : MonoBehaviour {
	
	public float _combatInterval;
	private float m_currentInterval;

	private bool m_withinInterval = false;

	private Time m_enabledTime;

	// Use this for initialization
	void Start () {
		ResetInterval();
	}
	
	// Update is called once per frame
	void Update () {
		RunInterval();
	}

	private void ResetInterval()
	{
		Debug.Log ("ResetInterval()");
		m_currentInterval = _combatInterval;
	}

	private void RunInterval()
	{
		m_currentInterval -= Time.deltaTime;
		if (m_currentInterval <= 0f)
		{
			ResetInterval();
		}
	}

}
