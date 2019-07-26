using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isEndGame;
    bool isStartFirstTime = true;
    int gamePoint = 0;
    public Text txtPoint;
    public GameObject pnlEndGame;
    public Text txtEndPoint;
    public Button btnRestart;

    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    // Use this for initialization
    void Start () {
        Time.timeScale = 0;
        isEndGame = false;
        isStartFirstTime = true;
        pnlEndGame.SetActive(false);
    }
	
    // Update is called once per frame
    // mặc định lúc đầu là false thì click chuột sẽ thực hiện lệnh else tiếp tục hình.
    // Sau khi chết thì sẽ thành true lúc này click chuột sẽ reset.
    void Update () {
        if (isEndGame)
        {
            if (Input.GetMouseButtonDown(0) && isStartFirstTime)
            {
                StartGame();
            }
        }       
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
            }
        } 
    }
    public void RestartButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;
    }

    public void RestartButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }

    public void RestartButtonIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }

    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

    void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        StartGame();
    }

    // Time.timeScale là dừng hình
    // isEndGame= true . Vào đầu màn hình sẽ là dừng hình và false
    // Để khi click chuột thì sẽ thực hiện lệnh else =1 tiếp tục load
    // SetActive(true) đánh dấu hoạt động đối tượng panel.
    public void EndGame()
    {
        isEndGame = true;
        isStartFirstTime = false; ;
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
        txtEndPoint.text = "Your point\n" + gamePoint.ToString();
    }
    
}
