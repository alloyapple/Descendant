using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClassSelect : MonoBehaviour
{
	public Slider loadingBar;
	public GameObject loadingImage;
	
	private AsyncOperation async;
	
	public GameObject _buttonWarrior;
	public GameObject _buttonPriest;
	public GameObject _buttonMage;
	public GameObject _buttonRogue;

	public AncestorSelection _ancestorSelection;

	private Ancestor _currentClass;

	private void Start()
	{
		ClearAllVisuals();
		_currentClass = null;
		_ancestorSelection.selectedAncestor = null;
	}

	public void LoadScene(string sceneName)
	{
		if(_currentClass != null){
			loadingImage.SetActive(true);
			StartCoroutine(LoadGameScene(sceneName));

			Ancestor newAncestor = new Ancestor();
			newAncestor = _currentClass;

			_ancestorSelection.selectedAncestor = newAncestor;
		}
	}
	
	IEnumerator LoadGameScene(string sceneName)
	{
		async = Application.LoadLevelAsync(sceneName);
		while (!async.isDone)
		{
			loadingBar.value = async.progress;
			yield return null;
		}
	}

	public void SetHero(Ancestor ancestor)
	{

		_currentClass = ancestor;

	}

	public void UpdateButtonVisual(GameObject selectedButton)
	{
//		selectedButton
		ClearAllVisuals();
		foreach(Transform child in selectedButton.transform)
		{
			if(child.gameObject.name == "Flag")
			{
				child.gameObject.SetActive(true);
			}
		}
	}

	private void ClearAllVisuals()
	{
		
		ClearVisuals(_buttonWarrior);
		ClearVisuals(_buttonPriest);
		ClearVisuals(_buttonMage);
		ClearVisuals(_buttonRogue);
	}

	private void ClearVisuals(GameObject selectedButton)
	{
		
		foreach(Transform child in selectedButton.transform)
		{
			if(child.gameObject.name == "Flag")
			{
				child.gameObject.SetActive(false);
			}
		}
	}

}