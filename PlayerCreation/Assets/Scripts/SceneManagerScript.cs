using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public Animator SceneAnimator;

    private string sceneToLoadName;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void SwitchScene(string sceneName)
    {
        sceneToLoadName = sceneName;
        SceneAnimator.SetTrigger("StartFade");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoadName);
        SceneAnimator.SetTrigger("FadeIn");
    }

    public void StartGame()
    {
        switch (GameManagerScript.GameLength)
        {
            default:
            //MediumBoard
                SwitchScene("MediumBoard");
                break;
            //short game
            case 17:
                SwitchScene("ShortBoard");
                break;
            //medium game
            case 22:
                SwitchScene("MediumBoard");
                break;
            //long game
            case 27:
                SwitchScene("LongBoard");
                break;

        }
    }
}
