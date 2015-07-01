using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace pocketjam15.descendant
{
	public class EnemyController : MonoBehaviour {

		private int startingHealth = 100;
		private int health;
		
		public Slider HealthBar;

		void Start()
		{
			health = startingHealth;
		}

		void Awake()
		{
			GameContext.currentInstance.enemyController = this;
		}

		public void TakeDamage(int damage)
		{
			health = health - damage;

			//Debug.Log(health+" / "+startingHealth);
			HealthBar.value = (float)health/startingHealth;

			if(health<=0){
				Die();
			}

		}

		public void Die()
		{
			health = 0;
			GameContext.currentInstance.director.Victory();
		}

	}
}
