using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Joueur : MonoBehaviour
{
    public GameObject bouton;
    public GameObject Tele;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("jumpscare_01"))
        {
            Tele.Play("tele_jumpscare");
        }
    }
}
