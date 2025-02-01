using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LevelOneLogicScript : MonoBehaviour
{
    public int rounds = 3;
    public int counter;
    [SerializeField] private TextMeshPro equationText;
    private bool gameStarted;
    [SerializeField] private GameObject startLevel;
    [SerializeField] private List<GameObject> answerTexts;
    [SerializeField] private GameObject equipment;
    public GameObject axePrefab;
    public  bool IsGameStarted()
    {
        return gameStarted;
    }

    public void CreateAxe()
    {
        var currentEquipment = Instantiate(axePrefab, equipment.transform.position, equipment.transform.rotation);
        Destroy(equipment);
        equipment = currentEquipment;
    }

    public void StartGame()
    {
        counter = rounds;
        SetEquation();
        gameStarted = true;
        CreateAxe();

    }

    public void SetEquation()
    {
        counter--;
        if (counter <= 0)
        {
            equationText.text = "You win";
            CreateAxe();
            gameStarted = false;
            for (int i = 0; i < answerTexts.Count; i++)
            {
                answerTexts[i].GetComponent<LevelOneTargerScript>().targetText.text = "";
                answerTexts[i].GetComponent<LevelOneTargerScript>().isCorrectAnswer = false;
                startLevel.SetActive(true);
            }
            return;
        }
        var (equation, correctAnswer, answers) = MathGenerator.GenerateEquation(
            MathGenerator.Difficulty.Normal,
            numOfChoices: 3
        );
        if (equationText != null)
        {
            equationText.text = $"{equation}";
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
        //Debug.Log($"Equation: {equation} = {correctAnswer}  |  Answers: {string.Join(", ", answers)}");

    }
}
