using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    private Playercontroller playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<Playercontroller>();


    }

    // Update is called once per frame
    void Update()
    {
    


        Destroy(gameObject, 3);

    }
}
