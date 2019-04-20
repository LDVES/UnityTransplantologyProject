using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    public PlayerCreationScript playerCreation;
    public Button StartGameBtn;

    private SceneManagerScript sceneManager;

    private void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SceneManagerScript>();
        StartGameBtn.onClick.RemoveAllListeners();

        StartGameBtn.onClick.AddListener(() => { sceneManager.StartGame(); playerCreation.CreatePlayers(); });
    }
}
