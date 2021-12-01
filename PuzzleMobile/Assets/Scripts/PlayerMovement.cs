using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpHeight = 5f;
    public Rigidbody rb;
    public bool playerIsOnFloor = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.Translate(horizontal, 0, 0);
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        if(Input.GetButtonDown("Jump") && playerIsOnFloor)
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            playerIsOnFloor = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            playerIsOnFloor = true;
        }
    }
}
