using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public void PlayPlayerWinEffect()
    {
        particleSystem.Play();
    }
}
