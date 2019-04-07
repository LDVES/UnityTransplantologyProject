using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int TurnIndex = 0;
    public Dice dice;
    public TextMeshProUGUI InfoText;
    public SpawnPlayerScript SpawnScript;
    public TogglePanel TogglePanelScript;
    public TextMeshProUGUI QuizTopText;

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
        
        QuizTopText.text = "Pytanie dla: " + SpawnScript.PlayerGameObjectList[TurnIndex].name;
        dice.isDiceRollAllowed = true;
    }

    IEnumerator ShowPopup()
    {
        TogglePanelScript.ShowInfoPanel();
        InfoText.text = "Teraz kolej: " + SpawnScript.PlayerGameObjectList[TurnIndex].name;
        yield return new WaitForSeconds(1.5f);
        TogglePanelScript.HideInfoPanel();
        StopCoroutine("ShowPopup");
    }
}