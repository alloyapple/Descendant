using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ParticleSortingLayer : MonoBehaviour {

	public string sortinglayerName;
	public int sortingOrder;

	void Start ()
	{
		//Change Foreground to the layer you want it to display on 
		//You could prob. make a public variable for this
		if (sortinglayerName != null) GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = sortinglayerName;
		if (sortingOrder != 0) GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = sortingOrder;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
