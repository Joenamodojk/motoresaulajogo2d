using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        Invoke(nameof(Recarregar), 1);
    }

    void Recarregar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
