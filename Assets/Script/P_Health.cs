using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_Health : MonoBehaviour
{
    float health = 10f;
    public AudioSource bandage;
    public AudioSource grunt;
    public AudioSource bagGrab;

    public void TakeDamage(float amount)
    {
        health -= amount;
        grunt.Play();
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void Medkit(int amount)
    {
        bandage.Play();
        health += amount;
    }
    public void Pickup()
    {
        bagGrab.Play();
    }
    public void bandag()
    {
        bandage.Play();
    }
}
