using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.GraphicsBuffer;

public class LevelOneTargerScript : MonoBehaviour
{
    public TextMeshPro targetText;
    public bool isCorrectAnswer = false;
    public LevelOneLogicScript levelOneLogicScript;
    [SerializeField]private GameObject vfx;
    private ParticleSystem vfxParticleSystem;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (vfx != null)
        {
            vfxParticleSystem = vfx.GetComponent<ParticleSystem>();
            vfx.SetActive(false);  // Ensure VFX is initially inactive
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Axe")
        {
            if (!isCorrectAnswer && levelOneLogicScript.IsGameStarted())
            {
                levelOneLogicScript.counter = levelOneLogicScript.rounds;
                levelOneLogicScript.CreateAxe();
            }
            audioSource.Play();
            vfx.SetActive(true);
            vfxParticleSystem.Play();
            Destroy(collision.gameObject);
            levelOneLogicScript.SetEquation();
        }
    }
}
