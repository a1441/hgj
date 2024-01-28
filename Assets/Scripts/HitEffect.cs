using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public ParticleSystem electro;
    public ParticleSystem explode;
    public ParticleSystem green;
    public ParticleSystem holy;
    public ParticleSystem love;
    public ParticleSystem snow;
    public ParticleSystem star;
    public ParticleSystem stone;

    // Make the PlayRandomParticleEffect method public
    public void PlayRandomParticleEffect()
    {
        // Create an array of ParticleSystem objects from your public variables
        ParticleSystem[] particleEffects = new ParticleSystem[]
        {
            electro, explode, green, holy, love, snow, star, stone
        };

        // Check if there are any particle effects in the array
        if (particleEffects.Length > 0)
        {
            // Choose a random index within the range of the array
            int randomIndex = Random.Range(0, particleEffects.Length);

            // Get the selected particle effect from the array
            ParticleSystem selectedEffect = particleEffects[randomIndex];

            // Check if the selected effect is not null
            if (selectedEffect != null)
            {
                // Play the selected particle effect
                selectedEffect.Play();
            }
        }
    }
}
