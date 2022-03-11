using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAConfig : MonoBehaviour
{
    Transform tr_Player;
    public float f_RotSpeed = 10.0f, f_MoveSpeed = 2.0f;

    public ParticleSystem explosionParticles;
    private Playercontroller playerControllerScript;
    

    void Start()
    {

        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
        playerControllerScript = GameObject.Find("Player").GetComponent<Playercontroller>();
       

    }


    void Update()
    {
      
        if (transform.position.x != tr_Player.position.x || transform.position.z != tr_Player.position.z)
        {
            Vector3 newtarget = tr_Player.position;
            newtarget.y = transform.position.y;
            transform.LookAt(newtarget);

        }

        transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
    }

    private void OnDestroy()
    {

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
            explosionParticles.Play();

            
        }
    }


}
