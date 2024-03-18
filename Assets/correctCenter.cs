using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correctCenter : MonoBehaviour
{
    void Start()
    {
        Invoke("Center", 3f);
    }

    private void Center()
    {
        CharacterController character = this.GetComponent<CharacterController>();
        character.center = Vector3.zero;
    }
}
