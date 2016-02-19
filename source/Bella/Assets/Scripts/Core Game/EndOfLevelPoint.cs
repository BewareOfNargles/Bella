using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndOfLevelPoint : MonoBehaviour
{
    public bool endOfGame = false;
    public string nextLevel = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.GetComponent<Player>()  != null)
        {
            if (endOfGame)
            {
                SceneManager.LoadScene("WinLevel");
            }
            else
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}
