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
    public void Retry()
    {
        winningPanel.SetActive(false);
        RetryPanel.SetActive(false);
        countDownt.SetActive(true);
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown()
    {
        for (int i = 5; i >= 0; i--)
        {
            numbers.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void EXIT()   
    {
        Application.Quit();
    }
}
 