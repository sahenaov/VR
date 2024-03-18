using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena4 : MonoBehaviour
{

    private string GraveScene;
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisionó es el jugador (puedes usar una etiqueta para identificar al jugador si es necesario)
        if (other.CompareTag("Player"))
        {
            // Obtener la cámara principal
            Camera camara = Camera.main;

            // Guardar la posición y rotación de la cámara actual en PlayerPrefs
            PlayerPrefs.SetFloat("CamaraPosX", camara.transform.position.x);
            PlayerPrefs.SetFloat("CamaraPosY", camara.transform.position.y);
            PlayerPrefs.SetFloat("CamaraPosZ", camara.transform.position.z);
            PlayerPrefs.SetFloat("CamaraRotX", camara.transform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat("CamaraRotY", camara.transform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat("CamaraRotZ", camara.transform.rotation.eulerAngles.z);

            // Cargar la siguiente escena
            SceneManager.LoadScene(GraveScene);
        }
    }
}
