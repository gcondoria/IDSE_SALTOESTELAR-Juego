using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Desactivar el AudioSource al inicio
        if (audioSource)
        {
            audioSource.enabled = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Destruir el objeto si colisiona con el "piso" o con el "jugador"
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                // Activar el AudioSource y reproducir el sonido
                if (audioSource)
                {
                    audioSource.enabled = true;
                    audioSource.Play();
                }
            }
            Destroy(gameObject);
        }
    }
}
