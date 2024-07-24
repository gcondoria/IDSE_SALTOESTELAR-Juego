using UnityEngine;

public class RaySpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // El objeto que se spameará
    public float spawnInterval = 1f; // Intervalo de tiempo entre cada spawn
    public float spawnDistance = 100f; // Distancia en el eje Z a la que el objeto se spameará
    public float yMin = -5f; // Mínima posición en el eje Y
    public float yMax = 5f; // Máxima posición en el eje Y
    public float speed = 2f; // Velocidad a la que el objeto se moverá

    private void Start()
    {
        // Empieza a spamear objetos en el intervalo especificado
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        // Calcula una posición aleatoria en el eje Y
        float randomY = Random.Range(yMin, yMax);

        // Calcula la posición inicial del objeto con la misma posición X que la cámara, una posición Y aleatoria, y Z a 100 unidades adelante
        Vector3 spawnPosition = new Vector3(Camera.main.transform.position.x, randomY, Camera.main.transform.position.z + spawnDistance);

        // Crea el objeto en la posición calculada
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Añade el componente MoverEnEjeZ al objeto spameado
        spawnedObject.AddComponent<MoverEnEjeZ>().speed = speed;
    }
}

public class MoverEnEjeZ : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        // Mueve el objeto en el eje Z hacia la cámara
        transform.position -= Vector3.forward * speed * Time.deltaTime;
        
        // Si el objeto se mueve más allá de la cámara, destrúyelo
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 1f) // Puedes ajustar esta distancia según tus necesidades
        {
            Destroy(gameObject);
        }
    }
}
