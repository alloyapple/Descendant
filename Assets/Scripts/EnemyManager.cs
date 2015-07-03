using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyManager : MonoBehaviour {

	// TODO: Expand Enemy Controller class, it's the equivilant to the Hero controller

	public List<GameObject>	_enemyList;
	public Transform _enemyPosition;
	public CombatController _combatController;			// TODO: Cast combat controller to enemy controller on spawn
	public int _spawnIntervals;
	private int m_currentSpawnInterval;

	private Queue<GameObject> m_currentEnemySpawnQueue;
	private Director m_director;
//	private GameObject m_currentEnemy;

	void Start () 
	{
		m_director = FindObjectOfType<Director>();
		if ( m_director == null )
			Debug.LogWarning("Enemy Manger is not finding the director");

		if (_enemyList.Count == 0) 
		{
			Debug.LogWarning ("No Enemies in EnemySpawner List, please populate and maybe create a prefab");
		}
		else
		{
			m_currentEnemySpawnQueue = new Queue<GameObject>();

			for ( int i = 0; i < _enemyList.Count; i++ )
			{
				// Fill Enemy Queue for the first time
				m_currentEnemySpawnQueue.Enqueue( _enemyList[i] );
			}

			if ( _enemyList.Count == 0 )
				Debug.LogWarning("Enemey Manger Enemy List is empty, please populate");
		}

		_combatController = FindObjectOfType<CombatController>();

		if (_combatController == null)
			Debug.LogWarning ("Enemy Manager couldn't find a combatcontroller!");

		m_currentSpawnInterval = 0;

		if ( _enemyPosition == null )
			_enemyPosition = GameObject.Find("EnemyPosition").transform;
		else
			Debug.LogWarning ("No Enemey Position found, please add Gameobject to scene as transform reference on Enemy Manger");

		SpawnNewEnemy ();
	}

	public void SpawnNewEnemy()
	{
//		if (m_currentEnemy == null || m_currentEnemySpawnQueue.Count > 0) 

		if ( m_currentSpawnInterval > _spawnIntervals )
		{
			// All Enemies Spawned aka. killed em all aka. you win
			// TODO: Loose sate ?????
			m_director.Victory();
			Debug.LogWarning("VICTORY");
		}

		if (m_currentEnemySpawnQueue.Count > 0) {
			Debug.Log ("Spawning new Enemy");

			GameObject object2Spawn = m_currentEnemySpawnQueue.Dequeue ();
			GameObject newSpawnedObject = GameObject.Instantiate ( object2Spawn, _enemyPosition.position, Quaternion.identity ) as GameObject;
			
			EnemyController object2SpawnController = newSpawnedObject.GetComponent<EnemyController>();

			if ( object2SpawnController != null )
			{
				object2SpawnController._combatController = _combatController;
				object2SpawnController._enemyManger = this;
				object2SpawnController._instanceRef = newSpawnedObject;
				_combatController._TestenemyGo = newSpawnedObject;
			}
			else
			{
				Debug.LogWarning("There is no EnemyController Assigned to this enemy: " + object2Spawn.name);		// TODO: do this check on start
			}

		} 
		else 
		{
			m_currentSpawnInterval++;
			if (_enemyList.Count == 0) 
			{
				Debug.LogWarning ("No Enemies in EnemySpawner List, please populate and maybe create a prefab");
			}
			else
			{
				m_currentEnemySpawnQueue = new Queue<GameObject>();
				
				for ( int i = 0; i < _enemyList.Count; i++ )
				{
					// Fill Enemy Queue for the first time
					m_currentEnemySpawnQueue.Enqueue( _enemyList[i] );
				}
				
				if ( _enemyList.Count == 0 )
					Debug.LogWarning("Enemey Manger Enemy List is empty, please populate");
			}
			Debug.Log ("Next Enemy Spawn Interval");
		}
	}
}
