using UnityEngine;

public class VortexTrigger : MonoBehaviour
{
    public ParticleSystem vortexEffect;

    void Update()
    {
        // Si la touche G est pressée
        if (Input.GetKeyDown(KeyCode.G))
        {
            TriggerVortex();
        }
    }

    public void TriggerVortex()
    {
        if (vortexEffect != null)
        {
            vortexEffect.Play();
        }
    }
}
