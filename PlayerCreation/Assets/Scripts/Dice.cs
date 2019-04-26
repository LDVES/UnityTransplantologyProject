using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite[] diceSprites;
    //public GameControl gameControl;
    public bool isDiceRollAllowed = true;
    public Quiz quizScript;
    public TogglePanel togglePanel;
    public Animator DiceAnimator;

    private SpriteRenderer diceRenderer;
    private int randomDiceResult;

    void Start()
    {
        diceRenderer = GetComponent<SpriteRenderer>();
        diceRenderer.sprite = diceSprites[5];
    }


    void OnMouseDown()
    {
        if (isDiceRollAllowed)
        {
            StopBlinkAnimation();
            StartCoroutine("Roll");
        }
    }

    private IEnumerator Roll()
    {
        isDiceRollAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 15; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            diceRenderer.sprite = diceSprites[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
        randomDiceResult = randomDiceSide + 1;
        quizScript.ShowRandomQuestion();
        togglePanel.ShowQuizPanel();
    }

    public int GetDiceResult()
    {
        return randomDiceResult;
    }

    public void StartBlinkAnimation()
    {
        DiceAnimator.SetBool("IsBlinking", true);
        DiceAnimator.Play("DiceBlink");
    }

    public void StopBlinkAnimation()
    {
        DiceAnimator.SetBool("IsBlinking", false);
        DiceAnimator.Play("DiceDefault");
    }
}