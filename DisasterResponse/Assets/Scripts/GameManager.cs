using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Canvas pause;
   // public Text pauseInfo;
    public Canvas Info;
    public Canvas masterUI;
    static float timer = 300.0f;
    public Text timerBox;
	// Use this for initialization
	void Start () {
        masterUI.enabled = false;
        pause.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
            pause.enabled = !pause.enabled;
        }

        if (timer <= 0.0f)
        {
            SceneManager.LoadScene("Game Over");
        }


    }

    public void removeInfoCanvas()
    {
        Info.enabled = !Info.enabled;
        masterUI.enabled = true;
        StartCountDown();
    }

    private void StartCountDown()
    {
        if(timerBox != null)
        {
            timerBox.text = "5:00:00";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }
    private void UpdateTimer()
    {
        if(timerBox != null)
        {
            timer -= Time.deltaTime;
            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");
            string fraction = ((timer * 100) % 100).ToString("00");
            timerBox.text = minutes + ":" + seconds + ":" + fraction;
        }
    }
}
