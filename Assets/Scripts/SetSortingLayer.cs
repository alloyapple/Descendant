using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetSortingLayer : MonoBehaviour {
	
	// Use this for initialization
	public string sortingLayerName;
	public int sortingOrder;

	void Start () {

		if (sortingLayerName != null) GetComponent<Renderer>().sortingLayerName = sortingLayerName;
		if (sortingOrder != 0) GetComponent<Renderer>().sortingOrder = sortingOrder;
	}
}