using UnityEngine;

public class AttachParticlesToPrefab : MonoBehaviour
{
    public GameObject particleEffect; // Reference to the particle effect prefab you want to attach
    private ParticleSystem attachedParticles;

    void Start()
    {
        // Assuming the particle effect is a child of the torso GameObject, find and attach the particle system
        attachedParticles = GetComponentInChildren<ParticleSystem>();

        if (attachedParticles != null && particleEffect != null)
        {
            // Instantiate and attach the particle effect to the torso GameObject
            GameObject instantiatedParticleEffect = Instantiate(particleEffect);
            instantiatedParticleEffect.transform.SetParent(attachedParticles.transform, false);
        }
    }
}
