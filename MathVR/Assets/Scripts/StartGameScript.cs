using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("XROrigin"))
        {
            Debug.Log("XR Origin entered StartLevel trigger!");
            Transform parent = transform.parent;
            if (parent != null)
            {
                LevelOneLogicScript levelOneLogicScript = parent.GetComponent<LevelOneLogicScript>();
                if (levelOneLogicScript != null)
                {
                    levelOneLogicScript.StartGame();
                    gameObject.SetActive(false);
                }
                else
                {
                    print("Parent start game script not found");
                }
            }
        }
    }
}

