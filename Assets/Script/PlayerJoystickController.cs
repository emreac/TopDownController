using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickController : MonoBehaviour
{

    public CoinSystem coinSystem;

    public GameObject gameOverCanvas;
    public GameObject nextLevelCanvas;
    

    public GameObject confetti;
    Vector3 lastPos;
    public GameObject player;
   // public Animator babyAnimator;






    //public Rigidbody rb;

    public float speed = 5.0F;
    public DynamicJoystick moveJoystick;
  //  public DynamicJoystick lookJoystick;
    public bool joystickActive = false;
    public GameObject tutorCanvas;

    public AudioSource yaySound;

    private void Start()
    {
        joystickActive = false;
    }

    void Update()
    {
        

        Invoke("TutorCanvas", 8f);

        /*
        if(player.transform.position != lastPos)
        {
           

            joystickActive = true;
            babyAnimator.SetBool("Crawl", true);


      
        }
        else
        {
            joystickActive = false;
            babyAnimator.SetBool("Crawl", false);

     

        }
        lastPos = player.transform.position;
        */
        UpdateMoveJoystick();
        UpdateLookJoystick();


     

    }

    void UpdateMoveJoystick()
    {

        CharacterController controller = GetComponent<CharacterController>();
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;
        Vector3 direction = new Vector3(hoz, 0, ver).normalized;
        controller.SimpleMove(direction *speed);
        
 
    }

    void UpdateLookJoystick()
    {
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;
        Vector3 direction = new Vector3(hoz, 0, ver).normalized;
        Vector3 lookAtPosition = transform.position + direction;
        transform.LookAt(lookAtPosition);
    }
    private void FixedUpdate()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Items")
        {
          
        }

        if(other.tag == "FinalTrigger")
        {

            Invoke("LoadNextLevel", 1.5f);
            yaySound.Play();
            confetti.SetActive(true);
        }
        if (other.tag == "Mom")
        {
            gameOverCanvas.SetActive(true);
            Debug.Log("Game Over!");
        }
    }

    public void TutorCanvas()
    {
        tutorCanvas.SetActive(false);
    }

    void LoadNextLevel()
    {
        nextLevelCanvas.SetActive(true);
        coinSystem.ClaimCoins();
    }
  
}
