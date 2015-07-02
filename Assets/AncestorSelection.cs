using UnityEngine;
using System.Collections;

public class AncestorSelection : MonoBehaviour {

	public Ancestor selectedAncestor;

	void Awake ()
	{
		DontDestroyOnLoad(this);
	}

}
