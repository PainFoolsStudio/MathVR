using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LevelSecondLogicScript : MonoBehaviour
{
    public int rounds = 3;
    public int counter;
    public bool sendOn = false;
    public List<GameObject> answerTexts;
    [SerializeField] private TextMeshPro equationText;

    public void StartGame()
    {
        counter = rounds;
        sendOn = true;
    }

    public void SetEquation()
    {
        counter--;
        if (counter <= 0)
        {
            equationText.text = "To DooDoolet Khordan Dare o========D";
            for (int i = 0; i < answerTexts.Count; i++)
            {
                answerTexts[i].GetComponent<LevelSecondTargerScript>().targetText.text = "YAM";
                answerTexts[i].GetComponent<LevelSecondTargerScript>().isCorrectAnswer = false;
            }
            return;
        }
        var (equation, correctAnswer, answers) = MathGenerator.GenerateEquation(
            MathGenerator.Difficulty.Normal,
            numOfChoices: 2
        );
        if (equationText != null)
        {
            equationText.text = $"Solve: {equation}";
        }
        for (int i = 0; i < answers.Count; i++)
        {
            if (i < answerTexts.Count && answerTexts[i] != null)
            {
                answerTexts[i].GetComponent<LevelSecondTargerScript>().targetText.text = answers[i].ToString();
                answerTexts[i].GetComponent<LevelSecondTargerScript>().isCorrectAnswer = false;
                if (correctAnswer == answers[i])
                {
                    answerTexts[i].GetComponent<LevelSecondTargerScript>().isCorrectAnswer = true;
                }
            }
        }
        Debug.Log($"Equation: {equation} = {correctAnswer}  |  Answers: {string.Join(", ", answers)}");

    }
}
