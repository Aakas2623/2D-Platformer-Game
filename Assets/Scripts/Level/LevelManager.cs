using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    //public string[] Levels;
    public List<Levels> level;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (level[0].status == LevelStatus.Locked)
        {
            level[0].status = LevelStatus.Unlocked;
        }
        //for (int i = 0; i < 5; i++)
        //{
        //    Debug.Log(GetLevelStatus(Levels[i]));
        //}
        //if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        //{
        //    SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        //}
        //for (int i = 0; i < 5; i++)
        //{
        //    Debug.Log(GetLevelStatus(Levels[i]));
        //}
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        //int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
        //int nextSceneIndex = currentSceneIndex + 1;
        //if (nextSceneIndex < Levels.Length)
        //{
        //    SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        //}


        
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting Level: " + level + " Status: " + levelStatus);
    }

    [Serializable]
    public class Levels
    {
        public string name;
        public LevelStatus status;
    }

}
