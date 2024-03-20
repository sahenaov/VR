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
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
    }
}
