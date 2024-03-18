using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CambioDeEscenaMultiple : MonoBehaviour
{
    // Lista de nombres de las escenas a cargar
    public List<string> nombresDeEscenas = new List<string> { "CementeryScene", "MetroScene", "GraveScene", "MedievalScene", "TokioScene" };

    // Método que se llama cuando el jugador colisiona con este objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisionó es el jugador (puedes usar una etiqueta para identificar al jugador si es necesario)
        if (other.CompareTag("Player"))
        {
            // Iterar sobre la lista de nombres de escenas y cargar cada una
            foreach (string nombreDeLaSiguienteEscena in nombresDeEscenas)
            {
                // Verificar si la escena ya ha sido visitada antes de cargarla
                if (!EscenaVisitada(nombreDeLaSiguienteEscena))
                {
                    SceneManager.LoadScene(nombreDeLaSiguienteEscena);
                    // Marcar la escena como visitada
                    MarcarEscenaComoVisitada(nombreDeLaSiguienteEscena);
                }
            }
        }
    }

    // Método para verificar si una escena ha sido visitada anteriormente
    private bool EscenaVisitada(string nombreDeLaEscena)
    {
        // Verificar si la escena está marcada como visitada en PlayerPrefs
        return PlayerPrefs.GetInt(nombreDeLaEscena, 0) == 1;
    }

    // Método para marcar una escena como visitada
    private void MarcarEscenaComoVisitada(string nombreDeLaEscena)
    {
        // Marcar la escena como visitada en PlayerPrefs
        PlayerPrefs.SetInt(nombreDeLaEscena, 1);
        PlayerPrefs.Save(); // Guardar los cambios en PlayerPrefs
    }
}