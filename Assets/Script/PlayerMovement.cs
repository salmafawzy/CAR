using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float RLSpeed;
    public float ForwardSpeed;
    public Rigidbody Player;
    public GameObject RetryPanel;
    public GameObject ENDPanel;
    public ParticleSystem Smoke;
    
    // Update is called once per frame
    void Update()
    { 
        // ForWard
        Player.AddForce(ForwardSpeed*Time.deltaTime ,0,0, ForceMode.VelocityChange);

        // Left
        if(Input.GetKey(KeyCode.A))
        {
            Player.AddForce(0,0,RLSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }

        //Right
        if (Input.GetKey(KeyCode.D))
        {
            Player.AddForce(0, 0, -RLSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "BOX")
        {
            GetComponent<BoxCollider>().enabled = false;
            Smoke.Stop();
            ForwardSpeed = 0;
            RLSpeed = 0;
            RetryPanel.SetActive(true);
        }
        else if(collision.collider.tag =="END")
        {
            Smoke.Stop();
            ForwardSpeed = 0;
            RLSpeed = 0;
            ENDPanel.SetActive(true);
        }

    }
}
