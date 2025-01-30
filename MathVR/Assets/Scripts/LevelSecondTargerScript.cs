using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class LevelSecondTargerScript : MonoBehaviour
{
    public TextMeshPro targetText;
    public bool isCorrectAnswer = false;
    public LevelSecondLogicScript levelSecondLogicScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            if (!isCorrectAnswer)
            {
                levelSecondLogicScript.counter = levelSecondLogicScript.rounds;
            }
            Destroy(gameObject);
        }
    }
}
