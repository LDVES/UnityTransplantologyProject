using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void StartGame()
    {
        switch (GameManagerScript.GameLength)
        {
            default:
                //MediumBoard
                LoadScene("MediumBoard");
                break;
            //short game
            case 17:
                LoadScene("ShortBoard");
                break;
            //medium game
            case 22:
                LoadScene("MediumBoard");
                break;
            //long game
            case 27:
                LoadScene("LongBoard");
                break;

        }
    }
}
