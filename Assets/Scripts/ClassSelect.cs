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

	private int _currentClass;

	private void Start()
	{
		ClearAllVisuals();
		_currentClass = 0;
		_ancestorSelection.selectedAncestor = 0;
	}

	public void LoadScene(string sceneName)
	{
		if(_currentClass != 0){
			loadingImage.SetActive(true);
			StartCoroutine(LoadGameScene(sceneName));

			_ancestorSelection.selectedAncestor = _currentClass;
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

	public void SetHero(int ancestorNum)
	{
		_currentClass = ancestorNum;
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