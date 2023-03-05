using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameManager _manager;
    [SerializeField] private AudioSource BallSound;
    private void OnTriggerEnter(Collider other)
    {
        BallSound.Play();
        if (other.CompareTag("Basket"))
        {
            _manager.Basket(transform.position);
        }
       else if (other.CompareTag("Ground"))
        {
            _manager.Lost();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        BallSound.Play();
    }
}
