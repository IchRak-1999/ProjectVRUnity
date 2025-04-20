using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    void Start()
    {
        // Limiter le FPS (par exemple, 60 FPS)
        Application.targetFrameRate = 60;
    }
}
