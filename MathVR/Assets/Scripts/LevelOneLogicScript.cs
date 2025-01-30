using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LevelOneLogicScript : MonoBehaviour
{
    public int rounds = 3;
    public int counter;
    [SerializeField] private TextMeshPro equationText;
    [SerializeField] private List<GameObject> answerTexts;

    public void StartGame()
    {
        counter = rounds;
        SetEquation();
    }

    public void SetEquation()
    {
        counter--;
        if (counter <= 0)
        {
            equationText.text = "To DooDoolet Khordan Dare o========D";
            for (int i = 0; i < answerTexts.Count; i++)
            {
                answerTexts[i].GetComponent<LevelOneTargerScript>().targetText.text = "YAM";
                answerTexts[i].GetComponent<LevelOneTargerScript>().isCorrectAnswer = false;
            }
            return;
        }
        var (equation, correctAnswer, answers) = MathGenerator.GenerateEquation(
            MathGenerator.Difficulty.Normal,
            numOfChoices: 3
        );
        if (equationText != null)
        {
            equationText.text = $"Solve: {equation}";
        }
        for (int i = 0; i < answers.Count; i++)
        {
            if (i < answerTexts.Count && answerTexts[i] != null)
            {
                answerTexts[i].GetComponent<LevelOneTargerScript>().targetText.text = answers[i].ToString();
                answerTexts[i].GetComponent<LevelOneTargerScript>().isCorrectAnswer = false;
                if (correctAnswer == answers[i])
                {
                    answerTexts[i].GetComponent<LevelOneTargerScript>().isCorrectAnswer = true;
                }
            }
        }
        Debug.Log($"Equation: {equation} = {correctAnswer}  |  Answers: {string.Join(", ", answers)}");

    }
}
