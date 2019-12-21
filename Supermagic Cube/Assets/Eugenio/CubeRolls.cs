using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRolls : MonoBehaviour
{
    private Vector3 offset;
    public int step = 9;
    public float speed = 0.01f;

    public GameObject player;
    public GameObject centro, sopra, sotto, sinistra, destra;

    bool input = true;

    private void Update()
    {
        if(input == true)
        {
            //if (Input.GetKey(KeyCode.W))
            //{
            //    StartCoroutine("moveUp");
            //    input = false;
            //}

            //if (Input.GetKey(KeyCode.S))
            //{
            //    StartCoroutine("moveDown");
            //    input = false;
            //}

            if (Input.GetKey(KeyCode.A))
            {
                StartCoroutine("moveLeft");
                input = false;
            }

            if (Input.GetKey(KeyCode.D))
            {
                StartCoroutine("moveRight");
                input = false;
            }
        }

    }

    //IEnumerator moveUp()
    //{
    //    for(int i = 0; i < (90 / step); i++)
    //    {
    //        player.transform.RotateAround(sopra.transform.position, Vector3.right, step);
    //        yield return new WaitForSeconds(speed);
    //    }
    //    centro.transform.position = player.transform.position;
    //    input = true;
    //}
    //IEnumerator moveDown()
    //{
    //    for (int i = 0; i < (90 / step); i++)
    //    {
    //        player.transform.RotateAround(sotto.transform.position, Vector3.left, step);
    //        yield return new WaitForSeconds(speed);
    //    }
    //    centro.transform.position = player.transform.position;
    //    input = true;
    //}
    IEnumerator moveLeft()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(sinistra.transform.position, Vector3.forward, step);
            yield return new WaitForSeconds(speed);
        }
        centro.transform.position = player.transform.position;
        input = true;
    }
    IEnumerator moveRight()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(destra.transform.position, Vector3.back, step);
            yield return new WaitForSeconds(speed);
        }
        centro.transform.position = player.transform.position;
        input = true;
    }
}
