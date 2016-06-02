using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;


public class GameOverManager : MonoBehaviour {

	[SerializeField] private Reticle m_Reticle;
	[SerializeField] private SelectionRadial m_Radial;
	[SerializeField] private UIFader m_BackToMenuFader;
	[SerializeField] private SelectionSlider m_BackToMenuSlider;
	[SerializeField] private UIFader m_ResumeGameFader;
	[SerializeField] private SelectionSlider m_ResumeGameSlider;

	private VREyeRaycaster eyeRay;

	void Awake () {

		eyeRay = GameObject.Find("Main Camera").GetComponent<VREyeRaycaster>();
	}


	IEnumerator Start () {
		
		if (eyeRay.CurrentInteractible.name == "BackToMenuSlider") {

			yield return StartCoroutine(m_BackToMenuFader.InteruptAndFadeIn());
			yield return StartCoroutine(m_BackToMenuSlider.WaitForBarToFill());
			yield return StartCoroutine(m_BackToMenuFader.InteruptAndFadeOut());

			SceneManager.LoadScene("Start Menu");
		}
		else {

			yield return StartCoroutine(m_ResumeGameFader.InteruptAndFadeIn());
			yield return StartCoroutine(m_ResumeGameSlider.WaitForBarToFill());
			yield return StartCoroutine(m_ResumeGameFader.InteruptAndFadeOut());

			SceneManager.LoadScene("tutorialLevel");
		}
	}
}
