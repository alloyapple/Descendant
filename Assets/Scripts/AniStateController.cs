using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class AniStateController : MonoBehaviour {

	public GameObject _idleSprite;
	public GameObject _attackSprite;
	public GameObject _dieSprite;
	public GameObject _getHitSprite;
	
	// Use this for initialization
	void Start () 
	{
		SetIdle ();
	}

	void Update () 
	{
	
	}

	IEnumerator TakeHit(float duration)
	{

		_idleSprite.SetActive (false);
		_getHitSprite.SetActive (true);

		yield return new WaitForSeconds(duration);

		SetIdle ();

	}

	IEnumerator DeathState(float duration)
	{
		
		_idleSprite.SetActive (false);
		_dieSprite.SetActive (true);
		
		yield return new WaitForSeconds(duration);
		
		SetIdle ();
		
	}

	public void SetIdle()
	{
		_idleSprite.SetActive (true);
		
		_attackSprite.SetActive (false);
		_dieSprite.SetActive (false);
		_getHitSprite.SetActive (false);
	}


}
