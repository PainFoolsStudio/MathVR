using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class TargerScript : MonoBehaviour
{
    public TextMeshPro targetText;
    public bool isCorrectAnswer = false;
    public UseMathScript useMathScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Axe")
        {
            if (!isCorrectAnswer)
            {
                useMathScript.counter = useMathScript.rounds;
            }
            Destroy(collision.gameObject);
            useMathScript.SetEquation();
        }
    }
}
