using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public bool gameOver = false;
    private bool isOnTheGround = true;
    public int lives = 3;


    private Vector3 initialPos = new Vector3(0, 3, 0);
    private float limY = 0.002f;
    public float horizontalMove;
    public float verticalMove;


    public Vector3 offset;
    public GameObject bullet;
    private bool canShoot;


    private Rigidbody playerRigidbody;

    private float jumpForce = 5;
    private float playerSpeed = 10;


    private Animator playerAnimator;

    public AudioClip shotClip;
    public AudioSource playerAudioSource;
    public AudioClip jumpClip;
    public AudioClip waterClip;
    public AudioClip explosionClip;
    

    public GameObject camara;
    public AudioSource camaraSound;
    public AudioClip camaraClip;


    public List<GameObject> beetles;
    public List<GameObject> bullets;

    private bool isBeingReset = false; 

    void Start()
    {
        transform.position = initialPos;

        playerAudioSource = GetComponent<AudioSource>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        canShoot = true;

        camara.GetComponent<AudioSource>();
        camara.GetComponent<AudioClip>();

       

        camaraSound.loop = camaraClip;

        Instantiate(beetles[PlayerPrefs.GetInt("SelectedCharacter")], this.transform);
        bullet = bullets[PlayerPrefs.GetInt("SelectedCharacter")];
    }

    
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

      

        if (lives <= 0)
        {
            gameOver = true;

            Destroy(gameObject);

            camaraSound.Stop();
        }




        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)  //con esta condición hacemos que si se cumplen las 3 reglas (que se presiona el boton de espacio y que la variable isOnTheGround es true y que gameOver sea false) el objeto saltar en y, y que sea una fuerza tipo impulso, y que la variable isOnTheGround pase a ser false.
        {

            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnTheGround = false;

             playerAnimator.SetTrigger("Alas_trig");

              playerAudioSource.PlayOneShot(jumpClip, 1);


        }





        if (transform.position.y <= limY)

        {
            transform.position = initialPos;
            lives = lives - 1;
            playerAudioSource.PlayOneShot(waterClip, 2);

            ExplotarCosas();



        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            offset = Vector3.forward;
            Shoot();
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            offset = Vector3.back;
            Shoot();
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            offset = Vector3.right;

            Shoot();
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            offset = Vector3.left;

            Shoot();
        }

     

    }

    private void FixedUpdate()
    {
       transform.Translate(new Vector3 (horizontalMove, 0, verticalMove) * playerSpeed * Time.deltaTime, Space.World);
    }
    
    private void OnCollisionEnter(Collision otherCollider)
    {
       
        if (!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("Ground")) // con este comando hacemos que cuando el player colisione con un objeto con la etiqueta ground, vuelva a tener la opción de saltar otra vez
            {
                isOnTheGround = true; //La variable isOnTheGround vuelve a estar en true para poder saltar otra vez.

            }

            if (otherCollider.gameObject.CompareTag("Bad") || otherCollider.gameObject.CompareTag("Bad2") || otherCollider.gameObject.CompareTag("Bad3"))
            {
                if (!isBeingReset)
                {
                    isBeingReset = true;
                    transform.position = initialPos;

                    Destroy(otherCollider.gameObject);

                    lives = lives - 1;

                    playerAudioSource.PlayOneShot(explosionClip, 1);
                    ExplotarCosas();
                    StartCoroutine(ResetLive());
                }

            }

        }
    }

    IEnumerator ResetLive()
    {
        yield return new WaitForSeconds(1);
        isBeingReset = false;
    }

    private void Shoot()
    {
        if (canShoot)
        {
            Instantiate(bullet, this.transform.position+offset*2+Vector3.down*0.5f, transform.rotation);

            playerAnimator.SetTrigger("Disparo_trig");

            canShoot = false;

            Invoke("ColdownShoot", 0.2f);

            playerAudioSource.PlayOneShot(shotClip, 1);

        }


    }

    void ColdownShoot()
    {
        canShoot = true;
    }


    public void ExplotarCosas ()

    {

        List<GameObject> enemiesLeft = new List<GameObject>();
        enemiesLeft.AddRange(GameObject.FindGameObjectsWithTag("Bad"));
        enemiesLeft.AddRange(GameObject.FindGameObjectsWithTag("Bad2"));
        enemiesLeft.AddRange(GameObject.FindGameObjectsWithTag("Bad3"));


        foreach (var e in enemiesLeft)
        {
            Destroy(e);
        }

       
    }

}
