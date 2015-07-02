using UnityEngine;
using System.Collections;


public class EntityWrapper
{
	public EntityMain _entity;
	public ActionType _actionType;
	public Ancestor	  _castingAncestor;
	
	public EntityWrapper( EntityMain Entity, ActionType Action ) // Ancestor Caster
	{
		_entity 			= Entity;
		_actionType 		= Action;
		//		_castingAncestor 	= Caster;			// TODO: Reactive casting Ancestor, was only turned off for testing
	}
}

