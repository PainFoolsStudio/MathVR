using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class LevelOneTargerScript : MonoBehaviour
{
    public TextMeshPro targetText;
    public bool isCorrectAnswer = false;
    public LevelOneLogicScript levelOneLogicScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Axe")
        {
            if (!isCorrectAnswer)
            {
                levelOneLogicScript.counter = levelOneLogicScript.rounds;
            }
            Destroy(collision.gameObject);
            levelOneLogicScript.SetEquation();
        }
    }
}
