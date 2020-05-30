using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private enum selected { Resume, MainMenu, Quit };
    public GameObject ResumeImage;
    public GameObject MainMenuImage;
    public GameObject QuitImage;

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    private selected Selected = 0;

    void Start()
    {
        UpdateButton();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Selected = 0; //reset the arrow
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (GameIsPaused)
            {
                Next();
                UpdateButton();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (GameIsPaused)
            {
                Prev();
                UpdateButton();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (Selected)
            {
                case selected.MainMenu:
                    MainMenu();
                    break;
                case selected.Resume:
                    Resume();
                    break;
                case selected.Quit:
                    Quit();
                    break;
            }
        }

    }

    private void UpdateButton()
    {
        switch (Selected)
        {
            case selected.MainMenu:
                MainMenuImage.SetActive(true);
                ResumeImage.SetActive(false);
                QuitImage.SetActive(false);
                break;
            case selected.Resume:
                MainMenuImage.SetActive(false);
                ResumeImage.SetActive(true);
                QuitImage.SetActive(false);
                break;
            case selected.Quit:
                MainMenuImage.SetActive(false);
                ResumeImage.SetActive(false);
                QuitImage.SetActive(true);
                break;
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);

    }
    public void Quit()
    {
        Application.Quit();
    }

    private void Next()
    {
        if (Selected == selected.Quit)
            return;
        else
            Selected++;
    }

    private void Prev()
    {
        if (Selected == selected.Resume)
            return;
        else
            Selected--;
    }
}
