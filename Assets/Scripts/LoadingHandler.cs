using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingHandler : MonoBehaviour
{
	public Slider loadingBar;
	public GameObject loadingImage;
	
	private AsyncOperation async;

	public void LoadScene(string sceneName)
	{
		loadingImage.SetActive(true);
		StartCoroutine(LoadGameScene(sceneName));
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
}