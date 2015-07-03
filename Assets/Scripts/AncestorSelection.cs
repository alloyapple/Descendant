using UnityEngine;
using System.Collections;

public class AncestorSelection : MonoBehaviour {

	public int selectedAncestor;

	void Awake ()
	{
		DontDestroyOnLoad(this);
	}

}
