using UnityEngine;

public class CutBarrelScript : MonoBehaviour
{
    public ParticleSystem explosion;
    public ParticleSystem smoke;

    private void Start()
    {
        Destroy(gameObject, 10f); 
    }
}
