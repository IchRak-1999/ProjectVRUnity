using UnityEngine;

public class VortexTriggerBoat : MonoBehaviour
{
    public ParticleSystem vortexEffect;

    void Update()
    {
        // Si la touche B est pressée
        if (Input.GetKeyDown(KeyCode.B))
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
