using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Joueur : MonoBehaviour
{
    public GameObject bouton;
    public GameObject Tele;

    private Animator teleAnimator;

    void Start()
    {
        teleAnimator = Tele.GetComponent<Animator>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("jumpscare_01"))
        {
            teleAnimator.Play("animation_jumpscare_tv_01");
        }
    }
}