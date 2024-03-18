using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject begining;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private GameObject selectionPalogrande;
    [SerializeField] private int startSceIndex;
    [SerializeField] private int palograndeSceIndex;


    

    // Start is called before the first frame update

    // Update is called once per frame

    public void SceneBeginning()
    {
       StartCoroutine(LoadBeginning());
    }

    public void ScenePalogrande()
    {
        begining.SetActive(false);
        StartCoroutine(LoadPalogrande());
    }

    IEnumerator LoadBeginning()
    {
        yield return new WaitForSeconds(transitionTime);    
        SceneManager.LoadScene(startSceIndex);
    }

    IEnumerator LoadPalogrande()
    {
        yield return new WaitForSeconds(transitionTime);    
        SceneManager.LoadScene(palograndeSceIndex);
    }

    
    

}