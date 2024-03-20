using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CambioDeEscenaMultiple : MonoBehaviour
{
    private int actualIndex;
    // Método que se llama cuando el jugador colisiona con este objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisionó es el jugador (puedes usar una etiqueta para identificar al jugador si es necesario)
        if (other.CompareTag("Player"))
        {
            actualIndex = SceneManager.GetActiveScene().buildIndex;
            if (SceneManager.GetSceneByBuildIndex(actualIndex++) != null)
            {
                SceneManager.LoadScene(actualIndex++);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}