using UnityEngine;
using System.Collections;

namespace pocketjam15.descendant
{
	public class DescendantController : MonoBehaviour {

		private int health = 100;
		EnemyController _enemyController;

		void Start()
		{
			_enemyController = GameContext.currentInstance.enemyController;
		}

		void Awake()
		{
			GameContext.currentInstance.descendantController = this;
		}

		public void TakeDamage(int damage)
		{
			health = health - damage;
		}

		public void AutoAttack ()
		{
			_enemyController.TakeDamage(5);
		}

	}
}
