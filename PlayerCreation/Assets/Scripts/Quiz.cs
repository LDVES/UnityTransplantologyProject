using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public TurnManager turnManger;
    public SpawnPlayerScript spawnScript;
    public TextMeshProUGUI TopText;
    public TextMeshProUGUI QuestionText;
    public GameObject[] Buttons;
    public QuestionsTable Questions;

    private PlayerMovement currentPlayerMovement;
    private List<string> answers = new List<string>();

    private void SetCurrentPlayerText()
    {
        //Change top text to current player
        SetQuizTopText("Pytanie dla: " + spawnScript.PlayerGameObjectList[turnManger.TurnIndex].name);
    }

    public void MovePlayer()
    {
        spawnScript.PlayerGameObjectList[turnManger.TurnIndex].GetComponent<PlayerMovement>().FinishWaypointIndex = spawnScript.PlayerGameObjectList[turnManger.TurnIndex].GetComponent<PlayerMovement>().waypointIndex + GameObject.FindGameObjectWithTag("Dice").GetComponent<Dice>().GetDiceResult();
        spawnScript.PlayerGameObjectList[turnManger.TurnIndex].GetComponent<PlayerMovement>().Move();
    }

    public void SetQuizTopText(string topText)
    {
        TopText.text = topText;
    }

    public void ShowRandomQuestion()
    {
        SetCurrentPlayerText();

        //get random question
        int randomId = Random.Range(1, Questions.GetRowList().Count);
        QuestionsTable.Row _currentQuestion = Questions.Find_Id(randomId.ToString());

        QuestionText.text = _currentQuestion.Question;

        //set and display answers
        answers.Add(_currentQuestion.Answer_1);
        answers.Add(_currentQuestion.Answer_2);
        answers.Add(_currentQuestion.Answer_3);

        int answersAmount = answers.Count;
        for (int i = 0; i < answersAmount; i++)
        {
            int randomAnswer = Random.Range(0, answers.Count);

            if (answers[randomAnswer].Contains("_"))
            {
                Buttons[i].GetComponent<Button>().onClick.RemoveAllListeners();
                Buttons[i].GetComponent<Button>().onClick.AddListener(Buttons[i].GetComponent<QuizButton>().StartGoodAnswer);
                Buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = answers[randomAnswer].TrimStart('_');
            }
            else
            {
                Buttons[i].GetComponent<Button>().onClick.RemoveAllListeners();
                Buttons[i].GetComponent<Button>().onClick.AddListener(Buttons[i].GetComponent<QuizButton>().StartBadAnswer);
                Buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = answers[randomAnswer];
            }

            answers.Remove(answers[randomAnswer]);
        }
    }
}