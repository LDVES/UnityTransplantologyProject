using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int TurnIndex = 0;
    public Dice dice;
    public GameObject InfoPanel;
    public TextMeshProUGUI InfoText;
    public SpawnPlayerScript spawnScript;

    private GameManagerScript gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
    }

    public void NextTurn()
    {
        StartCoroutine("ShowPopup");
        TurnIndex ++;
        if (TurnIndex > gameManager.PlayerList.Count - 1)
            TurnIndex = 0;

        dice.isDiceRollAllowed = true;      
    }

    IEnumerator ShowPopup()
    {
        InfoPanel.SetActive(true);
        InfoText.text = spawnScript.PlayerGameObjectList[TurnIndex].name;
        yield return new WaitForSeconds(2f);
        InfoPanel.SetActive(false);
        StopCoroutine("ShowPopup");
    }
}
