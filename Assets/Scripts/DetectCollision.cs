using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    private GameManager gameManager;
    private Playercontroller playerControllerScript;

    // public ParticleSystem explosionParticles;

    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerControllerScript = GameObject.Find("Player").GetComponent<Playercontroller>();

    }

    private void OnTriggerEnter(Collider otherTrigger)
    {
       



        if (otherTrigger.gameObject.CompareTag("Bad") )
        {
            Destroy(gameObject);

            Destroy(otherTrigger.gameObject);

            playerControllerScript.playerAudioSource.PlayOneShot(playerControllerScript.explosionClip, 0.5f);

            gameManager.AddPoints(10);
        }

        if (otherTrigger.gameObject.CompareTag("Bad2"))
        {
            Destroy(gameObject);

            Destroy(otherTrigger.gameObject);

            playerControllerScript.playerAudioSource.PlayOneShot(playerControllerScript.explosionClip, 0.5f);

            gameManager.AddPoints(20);
        }

        if (otherTrigger.gameObject.CompareTag("Bad3"))
        {
            Destroy(gameObject);

            Destroy(otherTrigger.gameObject);

            playerControllerScript.playerAudioSource.PlayOneShot(playerControllerScript.explosionClip, 0.5f);

            gameManager.AddPoints(30);
        }






    }

}

