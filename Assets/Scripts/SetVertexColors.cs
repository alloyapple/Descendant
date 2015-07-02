using UnityEngine;
using System.Collections;

public class SetVertexColors : MonoBehaviour {

	public Color meshcolor;

	void Start() {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Color[] colors = new Color[vertices.Length];
		int i = 0;
		while (i < vertices.Length) {
			colors[i] = meshcolor;
			i++;
		}
		mesh.colors = colors;
	}
}