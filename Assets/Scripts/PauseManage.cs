using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseManage : MonoBehaviour {

    private int buttonWidht = 200;
    private int buttonHeight = 50;
    private int groupWidht = 200;
    private int groupHeight = 170;
    bool paused = false;

    void Start ()
    {
        Screen.lockCursor = true;
        Time.timeScale = 1;
    }

    void OnGUI ()
    {
        if(paused)
        {
            GUI.BeginGroup(new Rect(((Screen.width / 2) - (groupWidht / 2)), ((Screen.height / 2) - (groupHeight / 2)), groupWidht, groupHeight));
            if (GUI.Button(new Rect(0, 0, buttonWidht, buttonHeight), "Main Menu"))
            {
                SceneManager.LoadScene("ABHMenu");
            }
            if (GUI.Button(new Rect(0, 60, buttonWidht, buttonHeight), "Restart Game"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            if (GUI.Button(new Rect(0, 120, buttonWidht, buttonHeight), "Quit Game"))
            {
                Application.Quit();
            }
            GUI.EndGroup();
        }
    }
	
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            paused = togglePause();
	}

    bool togglePause()
    {
        if(Time.timeScale == 0)
        {
            Screen.lockCursor = true;
            Time.timeScale = 1;
            return (false);
        }
        else
        {
            Screen.lockCursor = false;
            Time.timeScale = 0;
            return (true);
        }
    }
}
