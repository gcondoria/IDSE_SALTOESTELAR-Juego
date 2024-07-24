using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float rotationAngle = 30f;  // Ángulo de rotación en grados
    public float rotationSpeed = 5f;   // Velocidad de rotación
    public float moveSpeed = 10f;      // Velocidad de movimiento hacia adelante
    public float strafeSpeed = 5f;     // Velocidad de movimiento lateral

    private float targetRotation = 0f; // Rotación objetivo en el eje Z
    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // Detectar entrada del usuario para la rotación
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            targetRotation = rotationAngle;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            targetRotation = -rotationAngle;
        }
        else
        {
            targetRotation = 0f;
        }

        // Interpolar suavemente hacia la rotación objetivo
        Quaternion targetQuaternion = originalRotation * Quaternion.Euler(0f, targetRotation, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, Time.deltaTime * rotationSpeed);

        // Detectar entrada del usuario para el movimiento
        float moveDirection = Input.GetAxis("Vertical");  // W y S o flechas arriba y abajo
        float strafeDirection = Input.GetAxis("Horizontal");  // A y D o flechas izquierda y derecha

        // Mover la nave hacia adelante y lateralmente (sin considerar la rotación)
        Vector3 forwardMovement = transform.forward * moveDirection * moveSpeed * Time.deltaTime;
        Vector3 strafeMovement = Vector3.right * strafeDirection * strafeSpeed * Time.deltaTime;

        // Aplicar el movimiento
        transform.position += forwardMovement + strafeMovement;
    }
}
