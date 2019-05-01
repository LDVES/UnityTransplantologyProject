using System.Collections;
using System.Linq;
using UnityEngine;

public class QuizButton : MonoBehaviour
{
    public Quiz QuizScript;

    private Animator buttonAnimator;
    private TogglePanel toggleScript;
    private TurnManager turnManger;

    private void Start()
    {
        toggleScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<TogglePanel>();
        turnManger = GameObject.FindGameObjectWithTag("GameBoard").GetComponent<TurnManager>();
        buttonAnimator = gameObject.GetComponent<Animator>();
    }

    public IEnumerator GoodAnswer()
    {
        QuizScript.SetQuizTopText("Dobra odpowiedź!");
        buttonAnimator.Play("QuizButtonGoodAnswer");
        yield return new WaitForSeconds(buttonAnimator.runtimeAnimatorController.animationClips.First(x => x.name == "QuizButtonGoodAnswer").length + 0.5f);
        toggleScript.HideQuizPanel();
        QuizScript.MovePlayer();
        StopCoroutine("GoodAnswer");
    }

    public IEnumerator BadAnswer()
    {
        QuizScript.SetQuizTopText("Zła odpowiedź!");
        buttonAnimator.Play("QuizButtonBadAnswer");
        yield return new WaitForSeconds(buttonAnimator.runtimeAnimatorController.animationClips.First(x => x.name == "QuizButtonBadAnswer").length + 0.5f);
        toggleScript.HideQuizPanel();
        turnManger.NextTurn();
        StopCoroutine("BadAnswer");
    }

    public void StartGoodAnswer()
    {
        StartCoroutine("GoodAnswer");
    }

    public void StartBadAnswer()
    {
        StartCoroutine("BadAnswer");
    }

}
