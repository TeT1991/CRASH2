using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{

    public void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void Win()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        LavaFloor.instance.LBKillScore += 1;
        NewResultLeaderboard.instance.UpdateLeader();
    }


    public void PlusGoldX2()
    {
        Wood.instance.WoodCount += 350;
    }

    public void fixtime()
    {
        Time.timeScale = 1.0f;
    }

    public void LoadCutFirst()
    {
        Application.LoadLevel("CutFirst");
    }

    public void LoadCutEnd()
    {
        Application.LoadLevel("CutEnd");
    }


    public void fixtimeoff()
    {
        Time.timeScale = 0.0f;
    }

    public void Soundoff()
    {
        AudioListener.pause = true;
        AudioListener.volume = 0f;
    }

    public void SoundoOn()
    {
        AudioListener.pause = false;
        AudioListener.volume = 1f;
    }

    public void LoadLevel()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel("GamePlay");
    }

    public void LeaderRefresh()
    {
        NewResultLeaderboard.instance.UpdateLeader();
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UNLockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void LoadLoader()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel("END");
    }

    public void LevelRestart()
    {
        PlayerPrefs.SetInt("Level", 0);
        Time.timeScale = 1.0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel("Menu");
    }

}
