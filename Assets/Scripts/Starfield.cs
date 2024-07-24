using System.Collections;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    public GameObject starPrefab;      // Prefab de la estrella
    public int numberOfStars = 100;    // Número de estrellas en el campo
    public float spawnRange = 50f;     // Rango de aparición en el área
    public float starSpeed = 20f;      // Velocidad de movimiento de las estrellas
    public Transform player;           // Referencia al jugador

    private GameObject[] stars;        // Arreglo para almacenar las estrellas

    void Start()
    {
        stars = new GameObject[numberOfStars];
        GenerateStars();
    }

    void Update()
    {
        MoveStars();
    }

    void GenerateStars()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                Random.Range(-spawnRange, spawnRange),
                Random.Range(-spawnRange, spawnRange)
            );

            stars[i] = Instantiate(starPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void MoveStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = (player.position - stars[i].transform.position).normalized;
            
            // Mueve la estrella hacia el jugador
            stars[i].transform.position += direction * starSpeed * Time.deltaTime;
            
            // Si la estrella está demasiado cerca del jugador, respawnéala en una nueva posición
            if (Vector3.Distance(stars[i].transform.position, player.position) < 10f)
            {
                stars[i].transform.position = player.position + direction * spawnRange;
            }
        }
    }
}
