using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCondition : MonoBehaviour
{
    public GameObject[] checkPoints;
    public GameObject TriggerWin;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = checkPoints[0].transform.position;
            transform.rotation = new Quaternion(0, 0, 180, 0);
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "DeadFloor")
        {
            if (transform.position.x < checkPoints[1].transform.position.x && transform.position.x > checkPoints[2].transform.position.x)
            {
                transform.position = new Vector3(checkPoints[1].transform.position.x, checkPoints[1].transform.position.y, 0);
                transform.rotation = new Quaternion(0, 0, 180, 0);
            }
            else if (transform.position.x < checkPoints[2].transform.position.x && transform.position.x > checkPoints[3].transform.position.x)
            {
                transform.position = checkPoints[2].transform.position;
                transform.rotation = new Quaternion(0, 0, 180, 0);
            }
        }

        if (target.gameObject.tag == "WinFloor")
        {
            TriggerWin.GetComponent<SplashWin>().Win();
        }
    }
}
