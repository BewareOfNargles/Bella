using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public List<AudioClip> highlightSounds = new List<AudioClip>();
    public List<AudioClip> selectSounds = new List<AudioClip>();

    GameObject lastSelection;

    public GameObject levelButtonPrefab;
    public GameObject levelList;

    public int numSupportedLevels = 3;

    void Start()
    {
        int children = levelList.transform.childCount;
        for(int i = 0; i < children; i++)
        {
            Destroy(levelList.transform.GetChild(i).gameObject);
        }

        // Add all of our levels
        for(int i= 0; i < numSupportedLevels; i++)
        {
            AddLevel(i + 1);
        }
    }

    void AddLevel(int number)
    {
        if(levelButtonPrefab != null)
        {
            GameObject goNewLevel = Instantiate<GameObject>(levelButtonPrefab);
            goNewLevel.transform.SetParent(levelList.transform, false);
            LevelButton button = goNewLevel.GetComponent<LevelButton>();
            button.level = number;
            button.text.text = number.ToString();
            //button.SetStars
        }
    }

    public void StartLevel(int level)
    {   
        SceneManager.LoadScene("level" + level);
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != lastSelection)
        {
            // Selection has changed
            PlayHighlightSound();
        }
        lastSelection = EventSystem.current.currentSelectedGameObject;
    }

    public void Exit()
    {
        PlaySelectSound();
        SceneManager.LoadScene("level1");
    }

    public void PlayHighlightSound()
    {
        if (highlightSounds.Count < 1)
        {
            return;
        }

        AudioSource src = GetComponent<AudioSource>();
        if (!src)
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
