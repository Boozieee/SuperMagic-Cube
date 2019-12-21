using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Player;
    private float playerPos;

    public float speed;
    public Vector3 offset;

    private int count = 0;

    void FixedUpdate()
    {
        Vector3 offsetPos = Player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, offsetPos, speed);

        transform.position = smoothPos;

        transform.LookAt(Player);
    }
    #region Utilities
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Numlock)) // Cheat On
        {
            switch (count)
            {
                case 0:
                    Player.position = new Vector3(72, 47, 7.3f);
                    count++;
                    break;
                case 1:
                    Player.position = new Vector3(-33, 105, 7.3f);
                    count++;
                    break;
                case 2:
                    Player.position = new Vector3(120, 250, 7.3f);
                    count++;
                    break;
                case 3:
                    Player.position = new Vector3(-73, 187, 7.3f);
                    count++;
                    break;
            }
            if (count > 3)
            {
                count = 0;
            }
        }
    }
    #endregion
}
