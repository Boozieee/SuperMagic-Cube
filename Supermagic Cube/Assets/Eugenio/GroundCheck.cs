using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [HideInInspector]
    public bool isGrounded = true;

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Untagged")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision target)
    {
        if (target.gameObject.tag == "Untagged")
        {
            isGrounded = false;
        }
    }
}
