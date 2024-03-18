using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommandsPause : MonoBehaviour
{
    [SerializeField] private GameObject panelPausa;
    [SerializeField] private GameObject zombies;
    // Start is called before the first frame update

    SceneLoader sceneLoader;
    void Start()
    {
        //Hacer que se vea gris todo
        sceneLoader = GetComponent<SceneLoader>();
    }

    void Update()
    {
        //foreach(GameObject gameObject in zombies)
        //{
        //    gameObject.SetActive(false);
        //}

        zombies.SetActive(false);

        //Eje x y eje z comparar las distancias entre la posicion del
        //personaje y luego ver que este en una distancia  
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        sceneLoader.SceneBeginning();
    }

    public void BackToGame()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1;
        zombies.SetActive(true);
    }
}
