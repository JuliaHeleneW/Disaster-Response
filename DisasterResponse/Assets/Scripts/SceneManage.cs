using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {

    public string toLoad;

	// Use this for initialization
    public void LoadLevel(string valueName)
    {
        SceneManager.LoadScene(valueName);
    }
	void Start () {
		
	}

    public void Quit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            LoadLevel(toLoad);
        }
    }
}
