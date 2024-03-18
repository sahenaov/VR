using UnityEngine;
using System.Collections;

public class ControlMaterialEmisivo : MonoBehaviour
{
    public Renderer miRenderer; // Asigna el objeto Renderer desde el Inspector en Unity
    public float tiempoEncendido = 0.5f; // Tiempo que el material emisivo está encendido
    public float tiempoApagado = 0.5f; // Tiempo que el material emisivo está apagado

    void Start()
    {
        // Inicia la rutina para cambiar el estado del material emisivo
        StartCoroutine(CambiarEstadoMaterialEmisivo());
    }

    IEnumerator CambiarEstadoMaterialEmisivo()
    {
        while (true)
        {
            // Cambia el estado del material emisivo (encendido)
            if (miRenderer != null)
            {
                Material material = miRenderer.material;
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", Color.white);
                miRenderer.material = material;
            }

            // Espera el tiempo asignado para estar encendido
            yield return new WaitForSeconds(tiempoEncendido);

            // Cambia el estado del material emisivo (apagado)
            if (miRenderer != null)
            {
                Material material = miRenderer.material;
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", Color.black);
                miRenderer.material = material;
            }

            // Espera el tiempo asignado para estar apagado
            yield return new WaitForSeconds(tiempoApagado);
        }
    }
}
