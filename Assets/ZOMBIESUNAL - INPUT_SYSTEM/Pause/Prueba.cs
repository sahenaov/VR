using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Prueba : MonoBehaviour
{
    public Transform head;
    public float distance = 2;

    [SerializeField] private GameObject panelPause;
    private Pause myInput;

    // Start is called before the first frame update
    void Start()
    {
        myInput = new Pause();
        myInput.appearPause.pausePanel.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(myInput.appearPause.pausePanel.WasPressedThisFrame())
        {
            panelPause.SetActive(true);
            panelPause.transform.position = head.position + new Vector3(head.forward.x, 0,head.forward.z).normalized * distance;
            Time.timeScale = 0;
        }

        panelPause.transform.LookAt(new Vector3(head.position.x, panelPause.transform.position.y, head.position.z));
        panelPause.transform.forward *= -1;

    }

    

}
 