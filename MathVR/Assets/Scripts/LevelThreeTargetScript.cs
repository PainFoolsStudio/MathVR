using TMPro;
using UnityEngine;

public class LevelThreeTargetScript : MonoBehaviour
{
    public TextMeshPro targetText;
    public bool isCorrectAnswer = false;
    public LevelThreeLogicScript levelThreeLogicScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BoxingGlove")
        {
            gameObject.SetActive(false);
            levelThreeLogicScript.CheckAnswers();
        }
    }
}
