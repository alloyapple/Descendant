using UnityEngine;
using System.Collections;

public class NoiseTransformRotate : MonoBehaviour {

	public Vector3 noiseTime = new Vector3(1f,1f,1f);
	public float noisePhase = 1f;
	public bool randomPhaseOnStartup = false;
	public Vector3 Axis;

	private Quaternion rot;
	// Use this for initialization
	void Start () {
		rot = transform.localRotation;
		if (randomPhaseOnStartup) noisePhase = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		
		float noise1 = Mathf.PerlinNoise((Time.time + noisePhase) * noiseTime.x,0);
		float noise2 = Mathf.PerlinNoise((Time.time + noisePhase + 0.25f) * noiseTime.y,0);
		float noise3 = Mathf.PerlinNoise((Time.time + noisePhase + 0.75f) * noiseTime.z,0);
		//noise = (noise - 0.5f) * 2.0f;

		Vector3 noise = new Vector3 ((noise1 - 0.5f) * 2.0f, (noise2 - 0.5f) * 2.0f, (noise3 - 0.5f) * 2.0f);
		transform.localRotation =  rot * Quaternion.Euler(Vector3.Scale(noise, Axis));
		
	}
}
