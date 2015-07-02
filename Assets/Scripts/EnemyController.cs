using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	private float startingHealth = 1000f;
	private float health;

	UIController m_uiController;

	void Start()
	{
		health = startingHealth;
		m_uiController = FindObjectOfType<UIController>();
	}

	public void TakeDamage(float damage)
	{
		health = health - damage;

		//Debug.Log(health+" / "+startingHealth);
		//HealthBar.value = (float)health/startingHealth;

		m_uiController.UpdateEnemyHealth(health);

		if(health<=0){
			Die();
		}

	}

	public void Die()
	{
		health = 0;
		FindObjectOfType<Director>().Victory();
	}

}
