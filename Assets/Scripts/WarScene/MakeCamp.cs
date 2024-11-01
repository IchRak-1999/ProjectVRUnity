using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCamp : MonoBehaviour
{
    public GameObject[] tents;       // Array of tent prefabs
    public GameObject[] buildings;   // Array of building prefabs 

    [Header("Camp Configuration")]
    public int campWidth = 50;            // Width of the camp area in grid units
    public int campHeight = 50;           // Height of the camp area in grid units
    public float spacing = 10f;           // Spacing between each object in grid units
    public float spawnProbability = 0.6f; // Probability of object spawn at each position
    public float positionVariation = 2f;  // Max variation in position for random placement
    public float rotationVariation = 15f; // Max rotation variation for random orientation

    void Start()
    {
        GenerateCamp();
    }

    void GenerateCamp()
    {
        // Ajustement de départ pour garder le camp dans les limites du terrain
        float startX = (100 - (campWidth * spacing)) / 2f + positionVariation;
        float startZ = (100 - (campHeight * spacing)) / 2f + positionVariation;

        for (int x = 0; x < campWidth; x++)
        {
            for (int z = 0; z < campHeight; z++)
            {
                if (Random.value > spawnProbability) continue; // Skip this position based on probability

                // Position calculée dans la zone centrale du terrain
                Vector3 position = new Vector3(
                    startX + x * spacing + Random.Range(-positionVariation, positionVariation),
                    100, // Position élevée pour que le raycast trouve la hauteur du terrain
                    startZ + z * spacing + Random.Range(-positionVariation, positionVariation)
                );

                // Utilisation d'un raycast pour placer les objets sur le terrain
                if (Physics.Raycast(position, Vector3.down, out RaycastHit hitInfo))
                {
                    position.y = hitInfo.point.y; // Ajuste la hauteur à celle du terrain

                    // Rotation aléatoire autour de l'axe Y
                    Quaternion randomRotation = Quaternion.Euler(0, Random.Range(-rotationVariation, rotationVariation), 0);

                    // Choix aléatoire entre les tentes et les bâtiments
                    if (Random.value < 0.75f && tents.Length > 0) // 75% de chance d'instancier une tente
                    {
                        int tentIndex = Random.Range(0, tents.Length);
                        Instantiate(tents[tentIndex], position, randomRotation);
                    }
                    else if (buildings.Length > 0) // 25% de chance d'instancier un bâtiment
                    {
                        int buildingIndex = Random.Range(0, buildings.Length);
                        Instantiate(buildings[buildingIndex], position, randomRotation);
                    }
                }
            }
        }
    }
}
