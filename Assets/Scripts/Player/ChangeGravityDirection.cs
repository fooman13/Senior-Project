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
    private Quaternion CurrentRotation;
    Vector3 UP;
    Vector3 DOWN;
    Vector3 LEFT;
    Vector3 RIGHT;
    Vector3 FRONT;
    Vector3 BACK;

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

    private Vector3 GetCamRotation(Vector3 rotate)
    {
        rotate.y = player.transform.localRotation.y;
        return rotate;
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
        player.transform.Rotate(UP);
        ResumeGame();
        GUI.SetActive(false);
    }
    public void RotateDOWN()
    {
        GetCamRotation(DOWN);
        player.transform.Rotate(DOWN);
        ResumeGame();
        GUI.SetActive(false);
    }
    public void RotateLEFT()
    {
        GetCamRotation(LEFT);
        player.transform.Rotate(LEFT);
        ResumeGame();
        GUI.SetActive(false);
    }
    public void RotateRIGHT()
    {
        GetCamRotation(RIGHT);
        player.transform.Rotate(RIGHT);
        ResumeGame();
        GUI.SetActive(false);
    }
    public void RotateFRONT()
    {
        GetCamRotation(FRONT);
        player.transform.Rotate(FRONT);
        ResumeGame();
        GUI.SetActive(false);
    }
    public void RotateBACK()
    {
        GetCamRotation(BACK);
        player.transform.Rotate(BACK);
        ResumeGame();
        GUI.SetActive(false);
    }
}
