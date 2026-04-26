using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetSystems;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header(" Elements ")]
    [SerializeField] private VoxelGenerator voxelGenerator;
    [SerializeField] private Texture2D[] levels;

    [Header(" Settings ")]
    private int level;


    [Header(" Events ")]
    public static Action OnNextLevelSet;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        LoadData();


        VoxelEffector.OnVoxelStructureCompleted += SetNextLevel;
        //UIManager.onNextLevelButtonPressed += SetNextLevel;
    }

    private void OnDestroy()
    {
        VoxelEffector.OnVoxelStructureCompleted -= SetNextLevel;
        //UIManager.onNextLevelButtonPressed -= SetNextLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateLevel()
    {
        int levelIndex = level % levels.Length;

        //levelsParent.Clear();

        voxelGenerator.Generate(levels[levelIndex]);
        //Instantiate(levels[levelIndex], levelsParent);
    }

    private void IncreaseLevelIndex()
    {
        level++;
        SaveData();
    }

    private void SetNextLevel(Transform none = null)
    {
        Debug.Log("Next Level !!");
        IncreaseLevelIndex();

        OnNextLevelSet?.Invoke();

        FindObjectOfType<GameManager>().FuelEmptyCallback();
    }


    private void LoadData()
    {
        level = PlayerPrefs.GetInt("LEVEL");
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("LEVEL", level);
    }

    private void NextLevel()
    {
        SetNextLevel();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
