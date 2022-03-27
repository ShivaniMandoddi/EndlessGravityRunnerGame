using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    public float playerJumpForce;
    Rigidbody rb;
    public int score;
    public int speedChange;
    public int speedmultiplier;
    public Button quit;
    public Button restart;
    public GameObject resetPage;
    public Text scoreText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        quit.onClick.AddListener(Quit);
        restart.onClick.AddListener(Restart);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        //Endless Player movement
        rb.constraints = RigidbodyConstraints.None;
        rb.freezeRotation=true;
        rb.velocity = new Vector3(playerSpeed, rb.velocity.y, rb.velocity.z);
        if(Input.GetKeyDown(KeyCode.Space))          // Switching from one platform to another platform 
        {
            Physics.gravity *= -1;
        }
        score = Mathf.FloorToInt(transform.position.x);
        scoreText.text = "Score: " + score;
        if(score==speedChange)
        {
            speedChange = speedChange * 2;
            playerSpeed = playerSpeed + 1;
        }
        if(Input.GetKey(KeyCode.A))    // Floating a player in middle of the platforms 
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ObstacleCollider>())         // When player collide with obstacle
        {
            gameObject.SetActive(false);
            resetPage.SetActive(true);
        }
    }
}
