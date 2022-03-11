using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Playercontroller playerControllerScript;

    public int vidasCanvas;

    public Image[] hearts;
    public Sprite fHeart;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<Playercontroller>();



    }

    // Update is called once per frame
    void Update()
    {
        vidasCanvas = playerControllerScript.lives;
        

         for (int i = 0; i < hearts.Length; i++)
        {
            if (i < vidasCanvas)
            {
                hearts[i].enabled = true; 
            }
            else
            {
                hearts[i].enabled = false;
            }




        }


    }
}
