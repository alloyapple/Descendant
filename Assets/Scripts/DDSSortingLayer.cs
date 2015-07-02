using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;

[ExecuteInEditMode]
#endif

[System.Serializable]
public class DDSSortingLayer : MonoBehaviour 
{
	[SerializeField] public string[] layerNames = null;
	[SerializeField] public string currentLayer = string.Empty;
	#if UNITY_EDITOR
	public void OnEnable()
	{
		this.ReinitLayerNames ();
		
		this.currentLayer = LayerMask.LayerToName (this.gameObject.layer);
		EditorApplication.update += CheckLayer;
	}
	//--------------------------------------------------------------
	public void ReinitLayerNames ()
	{
		if (this.layerNames != null)
			this.layerNames = null;
		
		for (int i = 0; i < 32; i++)
		{
			this.AddLayer (LayerMask.LayerToName (i));
		}
	}
	//--------------------------------------------------------------
	private void AddLayer (string layerToAdd = "")
	{
		if (this.layerNames == null || this.layerNames.Length == 0)
		{
			this.layerNames = new string[1];
			this.layerNames[0] = layerToAdd;
		}
		else
		{
			string[] tempArray = new string[this.layerNames.Length];
			
			for (int i = 0; i < this.layerNames.Length; i++)
			{
				tempArray[i] = this.layerNames[i];
			}
			
			this.layerNames = new string[tempArray.Length + 1];
			this.layerNames[tempArray.Length] = layerToAdd;
			
			for (int i = 0; i < tempArray.Length; i++)
			{
				this.layerNames[i] = tempArray[i];
			}
			
			tempArray = null;
		}
	}
	//--------------------------------------------------------------
	public void CheckLayer ()
	{
		this.ReinitLayerNames ();
		this.gameObject.layer = LayerMask.NameToLayer (this.currentLayer);
	}
	#endif
}