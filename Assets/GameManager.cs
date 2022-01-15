using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject GamerOverScreen;
    public GameObject PauseScreen;
    public GameObject SuccessScreen;
    public bool pause;
    private bool _buttonReset = true;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && _buttonReset)
        {
            pause = !pause;
            if (pause)
            {
                Time.timeScale = 0.0001f;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
           
            _buttonReset = false;
            PauseScreen.SetActive(!PauseScreen.active);

        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _buttonReset = true;
        }
    }

    public void Success() {

        Time.timeScale = 0.0001f;
        Cursor.lockState = CursorLockMode.None;
        SuccessScreen.SetActive(true);
    }
    public void GameOver() 
    {

        Time.timeScale = 0.0001f;
        Cursor.lockState = CursorLockMode.None;
        GamerOverScreen.SetActive(true);




}

}
