using UnityEngine;

namespace PocketShooter
{

public class ObjectRotator : MonoBehaviour
{
	public float degreeInSec;
	public Space space = Space.Self;
	public Vector3 axis;

	//private float spintime;
	//private Quaternion rot;

	//private void Start()
	//{
		//rot = transform.localRotation;
		//axis = axis * degreeInSec;
	//}

	private void Update()
	{
		//spintime += degreeInSec * Time.deltaTime;
		//transform.localRotation = rot * Quaternion.Euler(Axis * spintime);

		Vector3 axisMul = axis * degreeInSec;
		transform.Rotate(axisMul * Time.deltaTime, space);
	}
}

}
