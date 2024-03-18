using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Commands_CampusUI : MonoBehaviour
{
    [SerializeField] private GameObject begining;
    [SerializeField] private GameObject[] campusMaps;
    
    public void PalograndeMap()
    {
        begining.SetActive(false);
        campusMaps[0].SetActive(true);
    }
    public void CableMap()
    {
        begining.SetActive(false);
        campusMaps[1].SetActive(true);
    }
    public void NubiaMap()
    {
        begining.SetActive(false);
        campusMaps[2].SetActive(true);
    }

    public void Back()
    {
        campusMaps[0].SetActive(false);
        campusMaps[1].SetActive(false);
        campusMaps[2].SetActive(false);
        begining.SetActive(true);
    }

    
}
