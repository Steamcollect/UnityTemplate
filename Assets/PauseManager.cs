using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public Animator settingsAnimator;
    bool isSettingsOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PauseButton();
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseButton()
    {
        isSettingsOpen = !isSettingsOpen;
        settingsAnimator.SetBool("IsOpen", isSettingsOpen);
    }
}