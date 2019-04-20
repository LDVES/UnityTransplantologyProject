using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI GameOverText;
    public GameObject GameOverPanel;
    public SpawnPlayerScript spawnScript;
    public TurnManager TurnManager;
    public SceneManagerScript SceneManager;
    public Animator GameOverAnimator;
    
    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
        GameOverText.text = spawnScript.PlayerGameObjectList[TurnManager.TurnIndex].name + " wygrywa!";
        GameOverAnimator.Play("ShowGameOverPanel");
    }

    public void RestartGame()
    {
        spawnScript.PlayerGameObjectList.Clear();
        SceneManager = GameObject.Find("GameManager").GetComponent<SceneManagerScript>();
        SceneManager.LoadScene("GameSetup");
    }
}
