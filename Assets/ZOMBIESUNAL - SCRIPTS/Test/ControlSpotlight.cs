using UnityEngine;
using System.Collections;

public class ControlSpotlight : MonoBehaviour
{
    public Light miSpotlight; // Cambiado de "Light" a "Spotlight"
    public float tiempoEncendido = 0.5f; // Tiempo que la luz está encendida
    public float tiempoApagado = 0.5f; // Tiempo que la luz está apagada

    void Start()
    {
        // Inicia la rutina para cambiar el estado de la luz
        StartCoroutine(CambiarEstadoSpotlight());
    }

    IEnumerator CambiarEstadoSpotlight()
    {
        while (true)
        {
            // Enciende la luz
            miSpotlight.enabled = true;

            // Espera el tiempo asignado para estar encendido
            yield return new WaitForSeconds(tiempoEncendido);

            // Apaga la luz
            miSpotlight.enabled = false;

            // Espera el tiempo asignado para estar apagado
            yield return new WaitForSeconds(tiempoApagado);
        }
    }
}
