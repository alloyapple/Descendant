using UnityEngine;
using System.Collections;

namespace pocketjam15.descendant
{

	public class EntityMain : MonoBehaviour {

		public int 		_health;
		public int 		_damage;
		public int		_armor;

		public int 		_healthMax;
		public int		_damageMax;
		public int 		_armorMax;

		void Start () 
		{
		
		}
		
		void Update ()
		{

		}

		public void ApplyDamage(int amount)
		{
			if (_health > 0)
				_health -= amount;
		}
		public void AddHealth(int amount)
		{
			if (_health >= 0 && _health < _healthMax) {
				_health += amount;

				if( _health > _healthMax )
					_health = _healthMax;
			}
		}
		public void AddArmor(int amount)
		{
			if (_armor >= 0 && _armor < _armorMax) {
				_armor += amount;

				if (_armor > _armorMax )
					_armor = _armorMax;
			}
		}
		public void DetractArmor(int amount)
		{
			if (_armor >= 0) {
				_armor -= amount;
			}
		}
	}

	public class EntityWrapper
	{
		public EntityMain _entity;
		public ActionType _actionType;
		public Ancestor	  _castingAncestor;

		public EntityWrapper( EntityMain Entity, ActionType Action ) // Ancestor Caster
		{
			_entity 			= Entity;
			_actionType 		= Action;
	//		_castingAncestor 	= Caster;
		}
	}
}