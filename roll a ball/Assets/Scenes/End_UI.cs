﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_UI : MonoBehaviour
{
    public void PlayGame()
    {
        // 激活该功能后，切换场景到指定场景
        SceneManager.LoadScene("Scenes/main scen");
    }

    public void QuitGame()
    {
        // 激活该功能后，退出游戏
        Application.Quit();
    }
}
