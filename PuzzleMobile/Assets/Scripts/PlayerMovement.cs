using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpHeight = 5f;
    public Rigidbody rb;
    public bool playerIsOnFloor = true;

    private bool rotatingWorld = false;
    private GameObject worldCard;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        worldCard = GameObject.FindGameObjectWithTag("WorldCard");

    }

    // Update is called once per frame
    void Update()
    {
       
        Controls();

    }

    private void Controls()
    {
        if (!rotatingWorld)
        {
            //Movement
            float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            transform.Translate(horizontal, 0, 0);


            //Jump
            if (Input.GetButtonDown("Jump") && playerIsOnFloor)
            {
                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                playerIsOnFloor = false;
            }

            //Rotate World
            RotateWorld();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            playerIsOnFloor = true;
        }
    }

    private void RotateWorld()
    {
        if (Input.GetButtonDown("RotateWorld"))
        {
            rotatingWorld = true;
            worldCard.GetComponent<Animator>().SetTrigger("Rotate");
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void ResetComands()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rotatingWorld = false;
    }

}
