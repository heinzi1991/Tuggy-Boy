using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class SettingsManager : MonoBehaviour {

	[SerializeField] private Reticle m_Reticle;
	[SerializeField] private SelectionRadial m_Radial;
	[SerializeField] private UIFader m_HowToUseFader;
	[SerializeField] private SelectionSlider m_HowToUseSlider;


	// Use this for initialization
	IEnumerator Start () {
	
		m_Reticle.Show();

		m_Radial.Hide();

		yield return StartCoroutine(m_HowToUseFader.InteruptAndFadeIn());
		yield return StartCoroutine(m_HowToUseSlider.WaitForBarToFill());
		yield return StartCoroutine(m_HowToUseFader.InteruptAndFadeOut());

		SceneManager.LoadScene("Start Menu");
	}
}
