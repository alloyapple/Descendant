using UnityEngine;

public class NoiseTransformMove : MonoBehaviour
{
	public float noiseTime = 1f;
	public float noisePhase = 1f;
	public Vector3 Axis;
	private Vector3 pos;

	private void Start()
	{
		pos = transform.localPosition;
	}
	
	private void Update()
	{
		float noise1 = Mathf.PerlinNoise((Time.time + noisePhase) * noiseTime,0);
		float noise2 = Mathf.PerlinNoise((Time.time + noisePhase + 0.25f) * noiseTime,0);
		float noise3 = Mathf.PerlinNoise((Time.time + noisePhase + 0.75f) * noiseTime,0);

		Vector3 noise = new Vector3 ((noise1 - 0.5f) * 2.0f, (noise2 - 0.5f) * 2.0f, (noise3 - 0.5f) * 2.0f) ;
		//noise = (noise - 0.5f) * 2f;

		transform.localPosition = pos + Vector3.Scale(noise, Axis);
	}
}
