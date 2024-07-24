using UnityEngine;

public class DestroyShield : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Destruir el objeto si colisiona con el "piso"
        if (collision.gameObject.CompareTag("Enemy"))
        {
             gameObject.SetActive(false);
        }
    }
}
