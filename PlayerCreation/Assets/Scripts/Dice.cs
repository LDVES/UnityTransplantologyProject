using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite[] diceSprites;
    public GameControl gameControl;
    private SpriteRenderer renderer;
    private int whosTurn = 1;
    private bool isRollAllowed = true;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = diceSprites[5];
    }


    void OnMouseDown()
    {
        if (!gameControl.GameOver && isRollAllowed)
        {
            StartCoroutine("Roll");
        }
    }

    private IEnumerator Roll()
    {
        isRollAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            renderer.sprite = diceSprites[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        gameControl.diceSideThrown = randomDiceSide + 1;
        if (whosTurn == 1)
        {
            gameControl.MovePlayer(1);
        }
        else if (whosTurn == -1)
        {
            gameControl.MovePlayer(2);
        }
        whosTurn *= -1;
        isRollAllowed = true;

    }
}
