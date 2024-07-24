using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Vidas : MonoBehaviour
{
    public int maxLives = 3; // Número máximo de vidas
    public List<Image> lifeImages; // Lista de imágenes que representan las vidas
    public GameObject gameOverPanel; // Referencia al panel de Game Over
    public GameObject shieldObject; // Referencia al objeto de escudo

    private int currentLives;

    void Start()
    {
        currentLives = maxLives;
        UpdateLivesUI();
        gameOverPanel.SetActive(false); // Asegúrate de que el panel de Game Over esté desactivado al inicio
        shieldObject.SetActive(false); // Asegúrate de que el escudo esté desactivado al inicio
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (shieldObject.activeSelf)
            {
                // Si el escudo está activo, desactívalo sin perder una vida
                shieldObject.SetActive(false);
            }
            else
            {
                LoseLife();
            }
        }
        if(collision.gameObject.CompareTag("Escudo"))
        {  
                // Activa escudo
                shieldObject.SetActive(true);
                shieldObject.transform.position = transform.position;
        }
    }

    void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            UpdateLivesUI();

            if (currentLives <= 0)
            {
                GameOver();
            }
        }
    }

    void UpdateLivesUI()
    {
        for (int i = 0; i < lifeImages.Count; i++)
        {
            lifeImages[i].enabled = i < currentLives;
        }
    }

    void GameOver()
    {
        // Activa el panel de Game Over
        gameOverPanel.SetActive(true);
        // Otras acciones, como detener el juego, pueden agregarse aquí
        Time.timeScale = 0f; // Detiene el juego
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Restablece el tiempo de juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1f; // restablece el tiempo de juego
        SceneManager.LoadScene("MenuPrincipal"); // Asegúrate de tener una escena llamada "MainMenu"
    }

    public void ActivateShield()
    {
        // Método para activar el escudo desde otros scripts o eventos
        shieldObject.SetActive(true);
    }
}
