using UnityEngine;

public class SitOnSofa : MonoBehaviour
{
    public Transform sitPoint; // Le point d'assise (Empty GameObject)
    public Animator animator;  // L'Animator du personnage

    void Update()
    {
        // Pour tester : appuie sur la touche E pour s’asseoir
        if (Input.GetKeyDown(KeyCode.E))
        {
            Sit();
        }
    }

    void Sit()
    {
        transform.position = sitPoint.position;
        transform.rotation = sitPoint.rotation;

        if (animator != null)
        {
            animator.SetTrigger("Sit");
        }
    }
}
