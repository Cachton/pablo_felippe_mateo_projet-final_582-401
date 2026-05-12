using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Joueur : MonoBehaviour
{
    public GameObject bouton;
    public GameObject Tele;

    private Animator teleAnimator;

    private bool jumpscarePlayed = false;

    void Start()
    {
        teleAnimator = Tele.GetComponent<Animator>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("jumpscare_01") && !jumpscarePlayed)
        {
            jumpscarePlayed = true;

            // 🎬 Animation TV
            teleAnimator.Play("animation_jumpscare_tv_01");

            // 🔊 Son de la zone
            AudioSource audio = other.GetComponent<AudioSource>();
            if (audio != null)
            {
                audio.Play();
            }
            else
            {
                Debug.LogWarning("Aucun AudioSource sur la zone !");
            }
        }
    }
}