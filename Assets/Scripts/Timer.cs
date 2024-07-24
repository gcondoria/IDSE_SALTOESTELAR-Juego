using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float countdownTime = 10.0f; // Tiempo en segundos para el contador
    public TextMeshProUGUI countdownText; // Referencia al componente de texto TextMeshPro

    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = Mathf.Ceil(currentTime).ToString(); // Actualiza el texto del contador solo con segundos

        if (currentTime <= 0)
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
         // Obtener el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Cargar la siguiente escena según los Build Settings
        if(currentSceneIndex == 5){
            SceneManager.LoadScene(0);
        }else{
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        
    }
}
