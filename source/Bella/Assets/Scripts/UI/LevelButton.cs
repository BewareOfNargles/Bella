using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{

    public int level = 1;
    public GameObject starElementPrefab;

    public GameObject starList;

    public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetStars(int numStars)
    {
        for(int i = 0; i < numStars; i++)
        {
            // Add a star to my list
            if (starElementPrefab)
            {
                GameObject goStar = Instantiate<GameObject>(starElementPrefab);
                goStar.transform.SetParent(transform, false);        
            }
        }
    }

    public void OnPressed()
    {
        FindObjectOfType<LevelSelect>().StartLevel(level);
    }
}
