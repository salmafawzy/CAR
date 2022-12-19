using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RetryEXIT : MonoBehaviour
{
    public GameObject countDownt;
    public GameObject winningPanel;
    public GameObject RetryPanel;

    public Text numbers;
    // retry method for retry button
    public void Retry()
    {
        winningPanel.SetActive(false);
        RetryPanel.SetActive(false);
        countDownt.SetActive(true);
        StartCoroutine(CountDown());
    }
    // this function is used to make delay
    IEnumerator CountDown()
    {
        for (int i = 5; i >= 0; i--)
        {
            numbers.text = i.ToString();
            yield return new WaitForSeconds(1f); // make delay for one second
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //to load the same scene again
    }
    public void EXIT()   
    {
        Application.Quit(); // to exit application
    }
}
 