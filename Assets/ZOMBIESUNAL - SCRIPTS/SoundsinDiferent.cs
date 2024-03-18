using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsinDiferent : MonoBehaviour
{
    public AudioClip StepsGround;
    public AudioClip StepsConcrete;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Concreto")
        {
            //Debug.Log("Cambio de suelo");
            Player.GetComponent<AudioSource>().clip = StepsConcrete;
        }
        else
        {
            Player.GetComponent<AudioSource>().clip = StepsGround;
        }

    }
}
