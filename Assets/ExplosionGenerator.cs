using UnityEngine;
using System.Collections;

public class RandomExplosionSpawner : MonoBehaviour
{
    public GameObject[] explosionPrefabs; // Tableau contenant les différents prefabs d'explosion
    public Terrain terrain; // Terrain où les explosions doivent apparaître
    public float heightOffset = 1f; // Décalage vertical pour éviter les collisions avec le terrain
    public float minDelay = 1f; // Délai minimum entre deux explosions
    public float maxDelay = 5f; // Délai maximum entre deux explosions

    void Start()
    {
        // Lancer la coroutine qui génère des explosions aléatoires
        StartCoroutine(GenerateExplosionsRandomly());
    }

    IEnumerator GenerateExplosionsRandomly()
    {
        while (true) // Boucle infinie pour des explosions continues
        {
            // Attendre un délai aléatoire avant la prochaine explosion
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // Générer une position aléatoire sur le terrain
            Vector3 explosionPosition = GetRandomPositionOnTerrain();

            // Choisir un prefab d'explosion au hasard
            GameObject selectedPrefab = explosionPrefabs[Random.Range(0, explosionPrefabs.Length)];

            // Instancier l'explosion
            GameObject explosion = Instantiate(selectedPrefab, explosionPosition, Quaternion.identity);

            // Détruire l'explosion après une durée
            Destroy(explosion, 5f); // Adaptez cette durée à la durée de vie des particules
        }
    }

    Vector3 GetRandomPositionOnTerrain()
    {
        // Récupérer les dimensions du terrain
        TerrainData terrainData = terrain.terrainData;
        Vector3 terrainPosition = terrain.transform.position;
        float terrainWidth = terrainData.size.x;
        float terrainLength = terrainData.size.z;

        // Générer des coordonnées x et z aléatoires
        float xCoord = Random.Range(0, terrainWidth);
        float zCoord = Random.Range(0, terrainLength);

        // Calculer la hauteur du terrain à ces coordonnées
        float normalizedX = xCoord / terrainWidth;
        float normalizedZ = zCoord / terrainLength;
        float yCoord = terrainData.GetHeight(
            Mathf.RoundToInt(normalizedX * terrainData.heightmapResolution),
            Mathf.RoundToInt(normalizedZ * terrainData.heightmapResolution)
        );

        // Retourner la position finale
        return new Vector3(
            terrainPosition.x + xCoord,
            terrainPosition.y + yCoord + heightOffset,
            terrainPosition.z + zCoord
        );
    }
}
