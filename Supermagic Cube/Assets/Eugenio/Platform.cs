using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float start, end, tempo, velocità;
    private float sec = 0.0f;

    [Tooltip("True: Up/Down - False: Left/Right")]
    public bool orientation; // 0 top-down // 1 left-right
    public bool canRotate = false;
    private Transform Target1, Target2;
    public GameObject refer;
    public float speedRot;

    private void Update()
    {
        if (orientation == true && canRotate == false)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(start, end, sec), 0);

            sec += velocità * Time.deltaTime;

            if (sec > tempo)
            {
                float temp = end;
                end = start;
                start = temp;
                sec = 0.0f;
            }
        }
        else if(orientation == false && canRotate == false)
        {
            transform.position = new Vector3(Mathf.Lerp(start, end, sec), transform.position.y, 0);

            sec += velocità * Time.deltaTime;

            if (sec > tempo)
            {
                float temp = end;
                end = start;
                start = temp;
                sec = 0.0f;
            }
        }
        else if(canRotate == true)
        {
            Target1 = refer.GetComponent<Transform>();
            Transform temp = Target1;
            refer.transform.Rotate(0, 0, speedRot);
            Target2 = refer.GetComponent<Transform>();

            transform.rotation = Quaternion.Lerp(temp.rotation, Target2.rotation, 0.01f);
        }
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Player")
        {
            target.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision target)
    {
        if (target.gameObject.tag == "Player")
        {
            target.transform.parent = null;
        }
    }
}
