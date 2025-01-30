using UnityEngine;

public class ThrowingObjectDestroyerScript : MonoBehaviour
{
    public LevelSecondLogicScript levelSecondLogicScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ThrowingObject")
        {
            if (other.GetComponent<LevelSecondTargerScript>().isCorrectAnswer)
            {
                levelSecondLogicScript.counter = 0;
            }
            levelSecondLogicScript.sendOn = true;
            Destroy(other.gameObject);
        }
    }
}
