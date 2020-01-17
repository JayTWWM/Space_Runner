using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Controller : MonoBehaviour {

	[Tooltip("_sceneToLoadOnPlay is the name of the scene that will be loaded when users click play")]
	public string _sceneToLoadOnPlay = "Play";
	[Tooltip("_soundButtons define the SoundOn[0] and SoundOff[1] Button objects.")]
	public Button[] _soundButtons;
	[Tooltip("_audioClip defines the audio to be played on button click.")]
	public AudioClip _audioClip;
	[Tooltip("_audioSource defines the Audio Source component in this scene.")]
	public AudioSource _audioSource;
	
	//The private variable 'scene' defined below is used for example/development purposes.
	//It is used in correlation with the Escape_Menu script to return to last scene on key press.
	UnityEngine.SceneManagement.Scene scene;

    void Awake () {
		if(!PlayerPrefs.HasKey("_Mute")){
			PlayerPrefs.SetInt("_Mute", 0);
		}
		
		scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
		PlayerPrefs.SetString("_LastScene", scene.name.ToString()); 
		//Debug.Log(scene.name);
	}

    public void MainMenu ()
    {
        _audioSource.PlayOneShot(_audioClip);
        UnityEngine.SceneManagement.SceneManager.UnloadScene("Play");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Load");
    }

    public void MainMenuOver()
    {
        _audioSource.PlayOneShot(_audioClip);
        UnityEngine.SceneManagement.SceneManager.UnloadScene("Game_over");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Load");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Application.LoadLevelAdditive(2);
        /*if ()
        {
            Application.LoadLevelAdditive(2);
        }*/
    }

    public void ResumeGame()
    {
        _audioSource.PlayOneShot(_audioClip);
        Time.timeScale = 1;
        Destroy(gameObject);
        UnityEngine.SceneManagement.SceneManager.UnloadScene("Pause");
        /*if ()
        {
            UnityEngine.SceneManagement.SceneManager.UnloadScene("Pause");
        }*/
    }

	public void PlayGame ()
    {
        Time.timeScale = 1;
        _audioSource.PlayOneShot(_audioClip);
		PlayerPrefs.SetString("_LastScene", scene.name);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play");
    }
	
	public void Mute () {
		_audioSource.PlayOneShot(_audioClip);
		_soundButtons[0].interactable = true;
		_soundButtons[1].interactable = false;
		PlayerPrefs.SetInt("_Mute", 1);
	}
	
	public void Unmute () {
		_audioSource.PlayOneShot(_audioClip);
		_soundButtons[0].interactable = false;
		_soundButtons[1].interactable = true;
		PlayerPrefs.SetInt("_Mute", 0);
	}
	
	public void QuitGame () {
        _audioSource.PlayOneShot(_audioClip);
		#if !UNITY_EDITOR
			Application.Quit();
		#endif
		
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
}
