using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace pocketjam15.descendant
{
	public class LoadingHandler : MonoBehaviour
	{
		
		public const string GAME_SCENE = "Game";
		
		public Slider loadingBar;
		public GameObject loadingImage;

		private AsyncOperation async;

		public void LoadScene()
		{
			loadingImage.SetActive(true);
			StartCoroutine(LoadGameScene());
		}
		
		IEnumerator LoadGameScene()
		{
			async = Application.LoadLevelAsync(GAME_SCENE);
			while (!async.isDone)
			{
				loadingBar.value = async.progress;
				yield return null;
			}
		}
	}
}