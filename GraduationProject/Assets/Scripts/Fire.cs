using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletObject;
    public Transform bulletPoint;
    float bulletSpeed = 25f;
    public AudioClip bulletSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale == 1)
        {
            audioSource.PlayOneShot(bulletSound);
            FireUp();
        }
    }
    public void FireUp()
    {
        GameObject bullet = Instantiate(bulletObject, bulletPoint.position, bulletPoint.rotation) as GameObject;
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.linearVelocity = bulletPoint.forward * bulletSpeed;
        Destroy(bullet.gameObject,6f);
    }      
}
