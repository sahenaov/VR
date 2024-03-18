using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScopeInteractions : MonoBehaviour
{
    [Header("Scope")]
    [SerializeField] private GameObject scope;
    [Range(1, 2)]
    [SerializeField] private float scaleFactor = 2f;

    [Header("Head Tag")]
    [SerializeField] private string headTag;

    [Header("Events")] 
    [SerializeField] private UnityEvent scopeEventEnter, scopeEventExit;

    [HideInInspector] public bool isLooking;
    private bool firstTime;

    private void OnEnable()
    {
        firstTime = false;
    }

    private void OnDisable()
    {
        scopeEventExit.Invoke();
        scope.transform.localScale = new Vector3(1,1,1);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Enter Scope Event //IMPORTANTE: ORGANIZAR SI MANO DOMINANTE ES IZQUIERDA O DERECHA
        if(!other.CompareTag(headTag) || isLooking == false) {return;}

        ScopeInit(true);   

        if (!firstTime){firstTime = true;}
    }

    private void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag(headTag) || isLooking == false || firstTime) {return;}
        {
            firstTime = true;
            ScopeInit(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Exit Scope Event
        if(!other.CompareTag(headTag) || isLooking == false) {return;}
        ScopeInit(false);
    }

    private void ScopeInit(bool init)
    {
        if(init)
        {
            //Call scope integrations
            scopeEventEnter.Invoke();
            scope.transform.localScale = scope.transform.localScale * scaleFactor;
        }

        else
        {
            //Call scope exit integrations
            scopeEventExit.Invoke();
            scope.transform.localScale = new Vector3(1,1,1);
        }
    }
}
