using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections.Generic;
using UnityEngine.XR;


public class UseMathScript : MonoBehaviour
{
    public int rounds = 3;
    public int counter;
    public InputActionReference aButtonAction;
    [SerializeField] private TextMeshPro equationText;
    [SerializeField] private List<GameObject> answerTexts;

    public void StartGame()
    {
        counter = rounds;
        SetEquation();
    }

    public void SetEquation()
    {
        print("AAA");
        counter--;
        if (counter <= 0)
        {
            equationText.text = "To DooDoolet Khordan Dare o========D";
            for (int i = 0; i < answerTexts.Count; i++)
            {
                answerTexts[i].GetComponent<TargerScript>().targetText.text = "YAM";
                answerTexts[i].GetComponent<TargerScript>().isCorrectAnswer = false;
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
                answerTexts[i].GetComponent<TargerScript>().targetText.text = answers[i].ToString();
                answerTexts[i].GetComponent<TargerScript>().isCorrectAnswer = false;
                if (correctAnswer == answers[i])
                {
                    answerTexts[i].GetComponent<TargerScript>().isCorrectAnswer = true;
                }
            }
        }
        Debug.Log($"Equation: {equation} = {correctAnswer}  |  Answers: {string.Join(", ", answers)}");

    }
}
