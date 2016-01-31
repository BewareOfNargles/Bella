using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetFullscreen()
    {
        Resolution r = Screen.currentResolution;
        Screen.SetResolution(r.width, r.height, false);
    }

    public void SetWindowed()
    {
        Resolution r = Screen.currentResolution;
        Screen.SetResolution(r.width, r.height, false);
    }
}
