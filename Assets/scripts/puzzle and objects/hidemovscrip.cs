using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidemovscrip : MonoBehaviour
{
    Vector2 turn;
    public float sensitivity;
    private int[,] directions = new int[4, 2] { {135,235},{225, 325},{ 315, 415},{405, 505} };
    public int direction;
    // Start is called before the first frame update
    void Start()
    {
     
        turn.x = 180;
        turn.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x = Mathf.Clamp(turn.x, directions[direction,0], directions[direction,1]);
        turn.y = Mathf.Clamp(turn.y, -45, 45);

        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.rotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
