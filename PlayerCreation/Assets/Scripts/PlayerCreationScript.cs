using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCreationScript : MonoBehaviour
{
    public GameObject PlayerPanelPrefab;
    public GameObject PlayerGridLayout;
    //public because it will be easier to edit the game from the inspector
    public int playerAmount;
    public int maxPlayerAmount;

    private GameObject[] PlayerPanels;

    public void AddNewPlayer()
    {
        if (playerAmount < maxPlayerAmount)
        {
            Instantiate(PlayerPanelPrefab, PlayerGridLayout.transform);
            playerAmount++;
        }
    }

    public void CreatePlayers()
    {
       
        PlayerPanels = GameObject.FindGameObjectsWithTag("PlayerPanel");
        GameManagerScript.PlayerList.Clear();
        foreach (GameObject playerPanel in PlayerPanels)
        {
            //get player's attributes from ui elements on PlayerPanels
            string nick = playerPanel.GetComponentInChildren<InputField>().text;
            Sprite playerGraphics = playerPanel.FindComponentInChildWithTag<Image>("SelectedCounter").sprite;

            //adds player to gameManager's list so it can be spawned in next scene
            Player player = new Player(nick, playerGraphics);
            GameManagerScript.PlayerList.Add(player);
        }
    }
}
