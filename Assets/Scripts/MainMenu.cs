using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu_Controller : MonoBehaviour
{

    [Tooltip("_soundButtons define the SoundOn[0] and SoundOff[1] Button objects.")]
    public Button[] _soundButtons;
    [Tooltip("_audioClip defines the audio to be played on button click.")]
    public AudioClip _audioClip;
    [Tooltip("_audioSource defines the Audio Source component in this scene.")]
    public AudioSource _audioSource;

    //The private variable 'scene' defined below is used for example/development purposes.
    //It is used in correlation with the Escape_Menu script to return to last scene on key press.
    UnityEngine.SceneManagement.Scene scene;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("_Mute"))
        {
            PlayerPrefs.SetInt("_Mute", 0);
        }

        scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        PlayerPrefs.SetString("_LastScene", scene.name.ToString());
        //Debug.Log(scene.name);
    }

    public void PlayGame()
    {
        _audioSource.PlayOneShot(_audioClip);
        SceneManager.LoadScene("Play");
    }

    public void Mute()
    {
        _audioSource.PlayOneShot(_audioClip);
        _soundButtons[0].interactable = true;
        _soundButtons[1].interactable = false;
        PlayerPrefs.SetInt("_Mute", 1);
    }

    public void Unmute()
    {
        _audioSource.PlayOneShot(_audioClip);
        _soundButtons[0].interactable = false;
        _soundButtons[1].interactable = true;
        PlayerPrefs.SetInt("_Mute", 0);
    }

    public void QuitGame()
    {
        _audioSource.PlayOneShot(_audioClip);
#if !UNITY_EDITOR
			Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public override bool Equals(object obj)
    {
        var controller = obj as Menu_Controller;
        return controller != null &&
               base.Equals(obj) &&
               EqualityComparer<Button[]>.Default.Equals(_soundButtons, controller._soundButtons) &&
               EqualityComparer<AudioClip>.Default.Equals(_audioClip, controller._audioClip) &&
               EqualityComparer<AudioSource>.Default.Equals(_audioSource, controller._audioSource);
    }

    public override int GetHashCode()
    {
        var hashCode = -2107568422;
        hashCode = hashCode * -1521134295 + base.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<Button[]>.Default.GetHashCode(_soundButtons);
        hashCode = hashCode * -1521134295 + EqualityComparer<AudioClip>.Default.GetHashCode(_audioClip);
        hashCode = hashCode * -1521134295 + EqualityComparer<AudioSource>.Default.GetHashCode(_audioSource);
        hashCode = hashCode * -1521134295 + EqualityComparer<Scene>.Default.GetHashCode(scene);
        return hashCode;
    }
}
