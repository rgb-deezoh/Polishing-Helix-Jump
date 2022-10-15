using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForece = 6.0f;

    private AudioManager audioManager;
    public GameObject player;

    Vector3 positionTwo;
    public ParticleSystem lossParticle;
    public ParticleSystem winParticle;

    private void Start()

    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        positionTwo = new Vector3(transform.position.x - 2.0f, transform.position.y, transform.position.z);
        audioManager.Play("bounce");
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForece, playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")
        {
            //hits the safe area
        }
        else if (materialName == "Unsafe (Instance)")
        {
            //hits the unsafe area
            GameManager.gameOver = true;
            audioManager.Play("loose");
            lossParticle.Play();

        }
        else if (materialName == "Last (Instance)" && !GameManager.levelCompleted)
        {
            //we completed the level
            GameManager.levelCompleted = true;
            audioManager.Play("win");
            winParticle.Play();
            Instantiate(player, positionTwo, player.transform.rotation);
        }

    }
}
