using UnityEngine;

public class CharacterAutoMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    void Update()
    {
        // Avance vers l'avant (Z+)
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
