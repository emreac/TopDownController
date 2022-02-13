using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharWalk : MonoBehaviour
{

    public DynamicJoystick moveJoystick;
    public bool joystickActive = false;
    public GameObject player;
    public Animator babyAnimator;
    Vector3 lastPos;
    public float speed = 5.0F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position != lastPos)
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

    }
    void UpdateMoveJoystick()
    {

        CharacterController controller = GetComponent<CharacterController>();
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;
        Vector3 direction = new Vector3(hoz, 0, ver).normalized;
        controller.SimpleMove(direction * speed);


    }

}
