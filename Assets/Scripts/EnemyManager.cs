using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyManager : MonoBehaviour {

	// TODO: Expand Enemy Controller class, it's the equivilant to the Hero controller

	public List<GameObject>	_enemyList;
	public Transform _enemyPosition;
	public CombatController _combatController;			// TODO: Cast combat controller to enemy controller on spawn

	private Queue<GameObject> m_currentEnemySpawnQueue;

//	private GameObject m_currentEnemy;

	void Start () 
	{
		if (_enemyList.Count == 0) 
		{
			Debug.LogWarning ("No Enemies in EnemySpawner List, please create a prefab");
		}
		else
		{
			m_currentEnemySpawnQueue = new Queue<GameObject>();

			for ( int i = 0; i < _enemyList.Count; i++ )
			{
				// Fill Enemy Queue for the first time
				m_currentEnemySpawnQueue.Enqueue( _enemyList[i] );
			}
		}

		_combatController = FindObjectOfType<CombatController>();
	}
	
	void Update () 
	{
	
	}

	void SpawnNewEnemy()
	{
//		if (m_currentEnemy == null || m_currentEnemySpawnQueue.Count > 0) 
		if (m_currentEnemySpawnQueue.Count > 0) {
			Debug.Log ("Spawning new Enemy");

			GameObject object2Spawn = m_currentEnemySpawnQueue.Dequeue ();

			GameObject.Instantiate ( object2Spawn, _enemyPosition.position, Quaternion.identity );

		} else {
			Debug.Log ("No More Enemies to Spawn");
			
		}
	}
}
