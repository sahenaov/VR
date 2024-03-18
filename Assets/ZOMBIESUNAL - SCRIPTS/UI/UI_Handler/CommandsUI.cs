using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CommandsUI : MonoBehaviour
{
    [SerializeField] private GameObject[] begining;
    [SerializeField] private GameObject[] menuArray;
    [SerializeField] private GameObject[] stageArray;
    [SerializeField] private GameObject[] selections;
    
    [SerializeField] private GameObject titulo;
    [SerializeField] private GameObject DamaLogo;
    [SerializeField] private GameObject credits;

    void Start()
    {
        Play();
    }

    public void Play()
    {
        begining[1].SetActive(false);
        begining[2].SetActive(true);
        DamaLogo.SetActive(true);
        Invoke("Loading",4f);
    }

    private void Loading()
    {
        for (int i = 0; i < begining.Length; i++)
        {
            begining[i].SetActive(false);
        }
        for (int i = 0; i < menuArray.Length; i++)
        {
            menuArray[i].SetActive(true);
        }
        DamaLogo.SetActive(false);
        titulo.SetActive(false);
    }

    public void ExitButton()
    {
        titulo.SetActive(true);
        for (int i = 0; i < begining.Length; i++)
        {
            begining[i].SetActive(true);
        }
        begining[2].SetActive(false);
        for (int i = 0; i < menuArray.Length; i++)
        {
            menuArray[i].SetActive(false);
        }
    }

    public void NewGame()
    {
        for (int i = 0; i < stageArray.Length; i++)
        {
            stageArray[i].SetActive(true);
        }
        for (int i = 0; i < menuArray.Length; i++)
        {
            menuArray[i].SetActive(false);
        }
    }

    public void Palogrande()
    {
        selections[0].SetActive(true);
        selections[1].SetActive(false);
        selections[2].SetActive(false);
    }

    public void Nubia()
    {
        selections[2].SetActive(true);
        selections[0].SetActive(false);
        selections[1].SetActive(false);
    }

    public void Cable()
    {
        selections[1].SetActive(true);
        selections[2].SetActive(false);
        selections[0].SetActive(false);
    }

    public void Credits()
    {
        for (int i = 0; i < menuArray.Length; i++)
        {
            menuArray[i].SetActive(false);
        }
        credits.SetActive(true);
    }

     public void CreditsOff()
    {
        for (int i = 0; i < menuArray.Length; i++)
        {
            menuArray[i].SetActive(true);
        }
        credits.SetActive(false);
    }

    public void BackButton()
    {
        for (int i = 0; i < stageArray.Length; i++)
        {
            stageArray[i].SetActive(false);
        }
        for (int i = 0; i < menuArray.Length; i++)
        {
            menuArray[i].SetActive(true);
        }
        for (int i = 0; i < selections.Length; i++)
        {
            selections[i].SetActive(false);
        }
    }
}
