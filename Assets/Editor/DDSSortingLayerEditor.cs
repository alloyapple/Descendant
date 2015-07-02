using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof (DDSSortingLayer))]

public class DDSSortingLayerEditor : Editor
{
	private DDSSortingLayer layer = null;
	
	public void OnEnable ()
	{
		this.layer = (DDSSortingLayer)target;
	}
	
	public override void OnInspectorGUI ()
	{
		if (this.layer == null)
			return;
		
		int _index = LayerMask.NameToLayer (this.layer.currentLayer);
		
		_index = EditorGUILayout.Popup (_index, this.layer.layerNames, GUILayout.ExpandWidth (true));
		
		this.layer.currentLayer = LayerMask.LayerToName (_index);
		
		EditorUtility.SetDirty (target);
	}
}