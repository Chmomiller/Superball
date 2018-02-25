using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    int max = 10;
    int min = -10;
    int speed = 5;
    public GameObject Ball;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*speed, max - min) + min, transform.position.z);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject bullet = Instantiate(Ball, new Vector3(transform.position.x-5, transform.position.y,transform.position.z), Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        }

    }
}
