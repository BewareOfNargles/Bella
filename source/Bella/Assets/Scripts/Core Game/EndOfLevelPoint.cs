using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndOfLevelPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("WinLevel");
        }
    }
}
