using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class PlayerCreationScript : MonoBehaviour
{
    public GameObject PlayerPanelPrefab;
    public GameObject PlayerGridLayout;
    //public because it will be easier to edit the game from the inspector
    public int playerAmount;
    public int maxPlayerAmount;

    private GameObject[] PlayerPanels;
    private int playerCounter = 1;
    private int spriteIndex = 0;

    private void ResetPlayerPanel()
    {
        playerCounter = 1;
        PlayerPanelPrefab.GetComponentsInChildren<TextMeshProUGUI>().First(x => x.gameObject.tag == "NickText").text = "Gracz " + playerCounter;
    }

    public void AddNewPlayer()
    {
        if (playerAmount < maxPlayerAmount)
        {
            playerCounter++;
            //create temporary player panel
            GameObject temporaryPanelPrefab = PlayerPanelPrefab.gameObject;
            //set different sprite and nick
            BrowsePlayersCountersScript browseScript = temporaryPanelPrefab.GetComponent<BrowsePlayersCountersScript>();

            if (spriteIndex < browseScript.CounterGraphics.Length - 1)
            {
                spriteIndex++;
                browseScript.SetPanelGraphics(spriteIndex);
            }
            else
            {
                spriteIndex = 0;
                browseScript. SetPanelGraphics(spriteIndex);
            }

            
            temporaryPanelPrefab.GetComponentsInChildren<TextMeshProUGUI>().First(x => x.gameObject.tag == "NickText").text = "Gracz " + playerCounter;
            Instantiate(temporaryPanelPrefab, PlayerGridLayout.transform);
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
            string nick = playerPanel.GetComponentsInChildren<TextMeshProUGUI>().First(x => x.gameObject.tag == "NickText").text;

            Sprite playerGraphics = playerPanel.FindComponentInChildWithTag<Image>("SelectedCounter").sprite;

            //adds player to gameManager's list so it can be spawned in next scene
            Player player = new Player(nick, playerGraphics);
            GameManagerScript.PlayerList.Add(player);
        }
    }
}
