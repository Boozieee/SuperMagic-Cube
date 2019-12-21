using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool isGrounded;
    public float speed;
    private Rigidbody rb;
    private Vector3 angleSpeed;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        angleSpeed = new Vector3(0, 0, 200);
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed;
        rb.AddForce(move, transform.position.y, transform.position.z);

        //if (isGrounded == true)
        //{
        //    // STAVA QUA
        //}else
        //{
        //    float rotation = Input.GetAxis("Horizontal");
        //    Quaternion deltaRot = Quaternion.Euler(angleSpeed * Time.deltaTime * rotation);
        //    rb.MoveRotation(rb.rotation * deltaRot);
        //    rb.AddForce(rotation * -1500, transform.position.y, transform.position.z);
        //}
    }

    //private void OnCollisionEnter(Collision target)
    //{
    //    if (target.gameObject.tag == "Floor")
    //    {
    //        isGrounded = true;
    //    }
    //}

    //private void OnCollisionExit(Collision target)
    //{
    //    isGrounded = false;
    //}
}
