using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    float speed = 6.0f;

    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        if (transform.position.x > 10) move = new Vector3(-1, Input.GetAxis("Vertical"), 0);
        if (transform.position.x < -10) move = new Vector3(1, Input.GetAxis("Vertical"), 0);
        if (transform.position.y > 10) move = new Vector3(Input.GetAxis("Horizontal"), -1, 0);
        if (transform.position.y < -10) move = new Vector3(Input.GetAxis("Horizontal"),1 , 0);


        transform.position += move * speed * Time.deltaTime;
    }
}