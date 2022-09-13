using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravityDirection : MonoBehaviour
{
    //Player
    private PlayerController playerMovementScript;
    private GameObject player;

    //UI
    public GameObject GUI;

    public bool isPaused = false;
    private Quaternion UP;
    private Quaternion DOWN;
    private Quaternion LEFT;
    private Quaternion RIGHT;
    private Quaternion FRONT;
    private Quaternion BACK;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GUI.SetActive(false);
        playerMovementScript = player.GetComponent<PlayerController>();
        UP.x = 180;

        LEFT.x = 90;
        LEFT.z = 270;
        RIGHT.x = 90;
        RIGHT.z = 90;

        FRONT.x = 270;
        BACK.x = 90;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MovementEnable();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MovementEnable();
    }

    private void MovementEnable()
    {
        if(isPaused==true)
            playerMovementScript.enabled = false;
        if(isPaused==false)
            playerMovementScript.enabled = true;
    }

    private Quaternion GetCamRotation(Quaternion N)
    {
        N.y = player.transform.rotation.y;
        return N;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ChangeGravity"))
        {
            if (isPaused)
            {
                ResumeGame();
                GUI.SetActive(false);

            }
            else
            {
                PauseGame();
                GUI.SetActive(true);
            }
        }
    }

    public void RotateUP()
    {
        GetCamRotation(UP);
        player.transform.rotation = UP;
        ResumeGame();
        GUI.SetActive(false);
    }
    public void RotateDOWN()
    {
        GetCamRotation(DOWN);
        player.transform.rotation = DOWN;
        ResumeGame();
        GUI.SetActive(false);
    }
    public void RotateLEFT()
    {
        GetCamRotation(LEFT);
        player.transform.rotation = LEFT;
        ResumeGame();
        GUI.SetActive(false);
    }
    public void RotateRIGHT()
    {
        GetCamRotation(RIGHT);
        player.transform.rotation = RIGHT;
        ResumeGame();
        GUI.SetActive(false);
    }
    public void RotateFRONT()
    {
        GetCamRotation(FRONT);
        player.transform.rotation = FRONT;
        ResumeGame();
        GUI.SetActive(false);
    }
    public void RotateBACK()
    {
        GetCamRotation(BACK);
        player.transform.rotation = BACK;
        ResumeGame();
        GUI.SetActive(false);
    }
}
