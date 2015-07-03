using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// TODO: let HeroController maybe inherit from EntityMain
public class HeroController : MonoBehaviour {

//	public int 		_health;
//	public int 		_armor;
//	public int 		_damage;
//	public int 		_actionPoints;
	public float 	_attackRate;					// TODO: Inherit from Ancestor

	public List<Ancestor>	_ancestorList;			// TODO: Possible wrap layer for ancestor class to manage multiple players
	public List<EntityMain> _enemyList;		
	
	public List<GameObject> _animList;		

	public EntityMain		_localEntityMain;

	private int	m_maxHealth;
	private int m_maxArmor;
	private int m_maxDamage;

	private float m_animTiming;		
	public float m_fullAnimTiming;

//	EnemyController _enemyController;

	void Start()
	{
		//m_fullAnimTiming = 0.2f;
		m_animTiming = 0f;
		ResetAnimation();
	}

	void Awake()
	{

	}

	public void ActivateAnimation(int animNum)
	{
		Debug.Log (_animList[animNum]);
		_animList[0].SetActive(false);
		_animList[animNum].SetActive(true);
		m_animTiming = 0.01f;
	}

	public void ResetAnimation()
	{
		_animList[0].SetActive(true);
		for (int i = 1; i < _animList.Count; i++) 
		{
			_animList[i].SetActive (false);
		}
		m_animTiming = 0f;
	}

	void Update()
	{
		if(m_animTiming > 0f)
		{
			m_animTiming += Time.deltaTime;

			if(m_animTiming > m_fullAnimTiming){
				ResetAnimation();
			}
		}
	}

	public void CompileStatsFromAncestors()
	{
		// Setup base values of Hero before adding Ancestor additions
		// TODO: just use entityMain values instead of duplicating for herocontroller
		// TODO: add ancestor action points and attack rate to HeroController

		_localEntityMain = gameObject.GetComponent<EntityMain> ();

		if (_localEntityMain != null) 
		{
			for (int i = 0; i < _ancestorList.Count; i++) 
			{
				Ancestor currentItem = _ancestorList[i];
			
				_localEntityMain._armor += currentItem._armorAddition;
				_localEntityMain._health += currentItem._healthAddition;
				_localEntityMain._damage += currentItem._damageAddition;

				// TODO: Add extra values to local entity
			}
		}

//		if (_localEntityMain != null) 
//		{
//			_health = _localEntityMain._health;
//			m_maxHealth = _localEntityMain._healthMax;
//			_armor = _localEntityMain._armor;
//			m_maxArmor = _localEntityMain._armorMax;
//			_damage = _localEntityMain._damage;
//			m_maxDamage = _localEntityMain._healthMax;
//
//			// process Ancestor List and add up values
//			if ( _ancestorList.Count > 0 )
//			{
//				for (int i = 0; i < _ancestorList.Count; i++) 
//				{
//					Ancestor currentItem = _ancestorList[i];
//
//					_armor += currentItem._armorAddition;
//					_health += currentItem._healthAddition;
//				}
//
//				_localEntityMain._health = _health;
//				_localEntityMain._armor = _armor;
//
//				Debug.Log("Updated Hero states based on Ancestors");
//				
//			}
//			else
//			{
//				Debug.LogWarning("No Ancestor List to process for HeroController");
//			}
//		} 
//		else 
//		{
//			Debug.LogError("Couldn't find an EntityMain script on Hero gameobject");
//		}
	}

	// TODO: Wrapper/Class needed for an attack, like an attack package
	// TODO: Add Compile Values

}
