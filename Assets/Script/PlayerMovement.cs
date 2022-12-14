using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")]
    public float RLSpeed;
    public float ForwardSpeed;
  


    public Rigidbody Player;

    [Header("Panels")]

    public GameObject CountDownPanel;
    public GameObject RetryPanel;
    public GameObject ENDPanel;
    public GameObject NextPanel;
    public ParticleSystem Smoke;

    [Header("Text")]
    public Text countdown;
    public Text score;
    public Text Nresult;
    public Text Rresult;
    public AudioSource sound;

    bool once = true;
    bool gameover = false;
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


        if(Player.transform.position.y <-34 && !gameover)
        {
            gameover = true;
            ActiveRetryPanel();

        }
        if(!gameover)  score.text = (Player.transform.position.x + 457.2).ToString("0");
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "BOX")
        {
            ActiveRetryPanel();
            gameover = true;
        }
        else if(collision.collider.tag =="END")
        {
            if(!gameover)
            {
                Smoke.Stop();
                ForwardSpeed = 0;
                RLSpeed = 0;
                ENDPanel.SetActive(true);
            }
          
        }
        else if(collision.collider.tag == "Next")
        {
            StartCoroutine(nextleve());
        }

    }

    void ActiveRetryPanel()
    {
        if(once)
        {
            Smoke.Stop();
            ForwardSpeed = 0;
            RLSpeed = 0;
            RetryPanel.SetActive(true);
            Rresult.text = score.text;
        }
      once = false;
    }
    IEnumerator nextleve()
    {
        Smoke.Stop();
        ForwardSpeed = 0;
        RLSpeed = 0;
        NextPanel.SetActive(true);
        Nresult.text = score.text;
        yield return new WaitForSeconds(2);
        NextPanel.SetActive(false);
        CountDownPanel.SetActive(true);
        for(int i=5;i>=0;i--)
        {
            countdown.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
 
}
