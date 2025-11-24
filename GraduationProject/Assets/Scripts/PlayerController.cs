using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{ 
    public float moveSpeed = 5f; // Tank�n ileri/geri hareket h�z�
    public float rotationSpeed = 50f; // Tank�n d�n�� h�z�

    private Rigidbody tankRigidbody;
    public TMP_Text timeText;
    public float time = 60f;
    public TMP_Text scoreText, lastText;
    public int score = 0;
    public GameObject lastPanel;
    private void Awake()
    {
        // Tank�n RigidBody bile�enini al�yoruz
        tankRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        scoreText.text = "Score: " + score;
        // Hareket ve d�n�� fonksiyonlar�n� �a��r�yoruz
        if (time > 1)
        {
            lastPanel.SetActive(false);
            time -= Time.deltaTime;
            int timeInteger = Mathf.FloorToInt(time);
            timeText.text = "Time: " + timeInteger.ToString();
            Move();
            Rotate();
        }
        else
        {
            lastText.text = "Your Score: " + score;
            lastPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void Move()
    {
        // �leri/geri hareket i�in input de�erini al�yoruz
        float moveInput = Input.GetAxis("Vertical");
        // Hareket y�n�n� belirliyoruz
        Vector3 moveDirection = transform.forward * moveInput;
        // Hareket y�n�n� RigidBody �zerinden uyguluyoruz
        tankRigidbody.linearVelocity = moveDirection * moveSpeed;
    }
    private void Rotate()
    {
        // Tank�n d�n��� i�in input de�erini al�yoruz
        float rotateInput = Input.GetAxis("Horizontal");
        // D�n�� y�n�n� belirliyoruz
        float rotationAmount = rotateInput * rotationSpeed * Time.fixedDeltaTime;
        // Yeni rotasyonu hesapl�yoruz
        Quaternion rotation = Quaternion.Euler(0f, rotationAmount, 0f);
        // Tank� d�nd�r�yoruz
        tankRigidbody.MoveRotation(tankRigidbody.rotation * rotation);
    }
}


