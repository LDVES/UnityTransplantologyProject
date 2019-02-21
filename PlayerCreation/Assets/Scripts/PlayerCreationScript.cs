using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreationScript : MonoBehaviour
{
    public GameObject PlayerPanelPrefab;
    public GameObject PlayerGridLayout;
    //public because it will be easier to edit the game from the inspector
    public int playerAmount;
    public int maxPlayerAmount;

    public void AddNewPlayer()
    {
        if (playerAmount < maxPlayerAmount)
        {
            Instantiate(PlayerPanelPrefab, PlayerGridLayout.transform);
            playerAmount++;
        }
    }

}
