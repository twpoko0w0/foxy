using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOut : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime;
    public GameObject TimeOutText;

    //Game object ที่จะทำให้หายไปช่วงที่เวลาหมด

    public GameObject menuButton;
    public GameObject playButton;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        TimeOutText.gameObject.SetActive(false);
        currentTime = startingTime;

        //button 
        menuButton.SetActive(false);
        playButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {

            currentTime = 0;

            //ขึ้น button
            menuButton.SetActive(true);
            playButton.SetActive(true);

            //ขึ้น text Win
            TimeOutText.gameObject.SetActive(true);
            Time.timeScale = 0;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //Destroy(PlayTimeOut);
            //Destroy(Enemy);
            //gameObject.SetActive(false);

            //PlayTimeOut.SetActive(false);
        }
    }
}
