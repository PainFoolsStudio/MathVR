using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class LevelThreeLogicScript : MonoBehaviour
{
    public int rounds = 3;
    public int counter;
    [SerializeField] private TextMeshPro equationText;
    [SerializeField] private List<LevelThreeTargetScript> answerTexts;

    public void StartGame()
    {
        counter = rounds;
        StartCoroutine(WaitAndSetEquation());
    }
    public IEnumerator WaitAndSetEquation()
    {
        yield return new WaitForSeconds(1f);
        SetEquation();
    }
    public void SetEquation()
    {
        counter--;
        for (int i = 0; i < answerTexts.Count; i++)
        {
            answerTexts[i].gameObject.SetActive(true);
        }
        if (counter <= 0)
        {
            equationText.text = "To DooDoolet Khordan Dare o========D";
            for (int i = 0; i < answerTexts.Count; i++)
            {
                answerTexts[i].targetText.text = "YAM";
                answerTexts[i].isCorrectAnswer = false;
            }
            return;
        }
        for (int j = 0; j < answerTexts.Count; j++)
        {
            answerTexts[j].gameObject.GetComponent<Collider>().enabled = true;
        }
        var (equation, correctAnswer, answers) = EquationGenerator.Generate(Random.Range(1, 5));
        if (equationText != null)
        {
            equationText.text = equation;
        }
        for (int i = 0; i < answers.Count; i++)
        {
            answerTexts[i].targetText.text = answers[i].ToString();
            answerTexts[i].isCorrectAnswer = false;
            if (correctAnswer.Contains(answers[i]))
            {
                answerTexts[i].isCorrectAnswer = true;
                print("Correct:" + answers[i]);
            }
        }
        Debug.Log($"Equation: {equation} =  {string.Join(", ", correctAnswer)}  |  Answers: {string.Join(", ", answers)}");
    }
    public void CheckAnswers()
    {
        bool isEnd = true;
        for (int i = 0; i < answerTexts.Count; i++)
        {
            if (!answerTexts[i].gameObject.activeSelf)
            {
                if (!answerTexts[i].isCorrectAnswer)
                {
                    counter = rounds;
                    // Add Material
                    for (int j = 0; j < answerTexts.Count; j++)
                    {
                        answerTexts[j].gameObject.GetComponent<Collider>().enabled = false;
                        answerTexts[j].targetText.text = "X";
                    }
                    StartCoroutine(WaitAndSetEquation());
                }
            }
            if (answerTexts[i].gameObject.activeSelf && answerTexts[i].isCorrectAnswer)
            {
                isEnd = false;
            }
        }
        if (isEnd)
        {
            StartCoroutine(WaitAndSetEquation());
        }
    }
}
