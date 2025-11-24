using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public GameObject effect;            // Genel mermi efekti
    public GameObject explosionEffect;   // Enemy'ye çarpýnca özel patlama efekti

    PlayerController control;

    void Start()
    {
        control = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Her çarpýþmada normal efekt oynat
        Instantiate(effect, transform.position, transform.rotation);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Düþmana özel patlama efekti
            Instantiate(explosionEffect, transform.position, transform.rotation);

            // Skoru arttýr
            control.score++;

            // Düþmaný yok et
            Destroy(collision.gameObject);
        }

        // Mermiyi her durumda yok et
        Destroy(gameObject);
    }
}
