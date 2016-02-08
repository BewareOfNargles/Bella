using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    public List<AudioClip> highlightSounds = new List<AudioClip>();
    public List<AudioClip> selectSounds = new List<AudioClip>();

    GameObject lastSelection;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(EventSystem.current.currentSelectedGameObject != lastSelection)
        {
            // Selection has changed
            PlayHighlightSound();
        }
        lastSelection = EventSystem.current.currentSelectedGameObject;
	}

    public void ExitGame()
    {
        PlaySelectSound();
        Application.Quit();
    }

    public void StartGame()
    {
        PlaySelectSound();
        SceneManager.LoadScene("level1");
    }

    public void OpenOptions()
    {
        PlaySelectSound();
        SceneManager.LoadScene("Options");
    }

    public void PlayHighlightSound()
    {
        if(highlightSounds.Count < 1)
        {
            return;
        }

        AudioSource src = GetComponent<AudioSource>();
        if(!src)
        {
            return;
        }

        src.PlayOneShot(PickRandom(highlightSounds));
    }

    public void PlaySelectSound()
    {
        if (selectSounds.Count < 1)
        {
            return;
        }

        AudioSource src = GetComponent<AudioSource>();
        if (!src)
        {
            return;
        }

        src.PlayOneShot(PickRandom(selectSounds));
    }

    AudioClip PickRandom(List<AudioClip> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}
