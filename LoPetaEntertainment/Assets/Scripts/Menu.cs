using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public AudioSource source;
	public AudioClip hover;
	public AudioClip click;
	
	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}

	public void OnHover()
	{
		source.PlayOneShot(hover);
	}
	public void OnClick()
	{
		source.PlayOneShot(click);

	}
}
