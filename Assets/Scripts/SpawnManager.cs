using System.Collections;
using UnityEngine;

public class MeteorShower : MonoBehaviour
{
    public GameObject[] meteorPrefabs; // Arreglo de prefabs de meteoritos
    public float spawnInterval = 1f;   // Intervalo de tiempo entre cada meteorito
    public float spawnAreaWidth = 50f; // Ancho del área de aparición en X
    public float spawnAreaHeight = 50f; // Altura del área de aparición en Y
    public float meteorSpeed = 10f;    // Velocidad de caída de los meteoritos

    void Start()
    {
        // Inicia la lluvia de meteoritos
        StartCoroutine(SpawnMeteorShower());
    }

    IEnumerator SpawnMeteorShower()
    {
        while (true)
        {
            // Llama a la función para crear un meteorito
            SpawnMeteor();
            // Espera el intervalo especificado antes de crear el siguiente meteorito
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnMeteor()
    {
        // Elige un prefab de meteorito aleatoriamente
        GameObject meteor = meteorPrefabs[Random.Range(0, meteorPrefabs.Length)];
        // Elige una posición aleatoria en el área de aparición
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f),
            spawnAreaHeight,
            Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f)
        );

        // Instancia el meteorito
        GameObject meteorInstance = Instantiate(meteor, spawnPosition, Quaternion.identity);
        // Aplica una fuerza hacia abajo para simular la caída
        Rigidbody rb = meteorInstance.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = new Vector3(0, -meteorSpeed, 0);
        }
    }
}
