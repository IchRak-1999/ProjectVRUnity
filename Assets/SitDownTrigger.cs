using UnityEngine;

public class SitDownTrigger : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        // Déclenche l'animation d'assise lorsque le script démarre
        if (animator != null)
        {
            animator.SetTrigger("Sit");
        }
    }
}
