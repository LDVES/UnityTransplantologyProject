using System.Collections;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int TurnIndex = 0;
    public Dice dice;
    public TextMeshProUGUI InfoText;
    public SpawnPlayerScript SpawnScript;
    public TogglePanel TogglePanelScript;

    public void NextTurn()
    {
        TurnIndex++;
        if (TurnIndex > GameManagerScript.PlayerList.Count - 1)
            TurnIndex = 0;
        StartCoroutine("ShowPopup");
        
        dice.isDiceRollAllowed = true;
        dice.StartBlinkAnimation();
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