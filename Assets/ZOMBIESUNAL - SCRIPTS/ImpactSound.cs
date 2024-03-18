using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public AudioClip Tierra, Pared, Zombie, Concreto;
    public AudioSource Audiosource;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Tierra":
                Debug.Log("Detecto tierra");
                gameObject.GetComponent<AudioSource>().clip = Tierra;
                Audiosource.PlayOneShot(Tierra);
                break;

            case "Pared":
                Debug.Log("Detecto Pared");
                gameObject.GetComponent<AudioSource>().clip = Pared;
                Audiosource.PlayOneShot(Pared);
                break;
            case "Zombie":
                Debug.Log("Detecto Zombie");
                gameObject.GetComponent<AudioSource>().clip = Zombie;
                Audiosource.PlayOneShot(Zombie);
                break;
            case "Concreto":
                Debug.Log("Detecto Concreto");
                gameObject.GetComponent<AudioSource>().clip = Concreto;
                Audiosource.PlayOneShot(Concreto);
                break;
        }
        //if (collision.gameObject.CompareTag("Pared")
        //{
        //    gameObject.GetComponent<AudioSource>().clip = SoundMaterial;
        //    Sound.Play();
        //}
    }
}
