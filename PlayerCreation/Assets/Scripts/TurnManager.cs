using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int TurnIndex = 0;
    public Dice dice;
    public TextMeshProUGUI InfoText;
    public SpawnPlayerScript spawnScript;
    public TogglePanel togglePanelScript;

    private GameManagerScript gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    public void NextTurn()
    {
        StartCoroutine("ShowPopup");
        TurnIndex++;
        if (TurnIndex > gameManager.PlayerList.Count - 1)
            TurnIndex = 0;

        dice.isDiceRollAllowed = true;
    }

    IEnumerator ShowPopup()
    {
        togglePanelScript.ShowInfoPanel();
        InfoText.text = "Teraz kolej: " + spawnScript.PlayerGameObjectList[TurnIndex].name;
        yield return new WaitForSeconds(1.5f);
        togglePanelScript.HideInfoPanel();
        StopCoroutine("ShowPopup");
    }
}