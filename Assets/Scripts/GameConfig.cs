using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameConfig
{
    public float sensitivityX = 2f;
    public float sensitivityY = 2f;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public float volume = 1.0f;
    // Добавьте другие настройки по необходимости
}

public static class ConfigManager
{
    private static string configPath = Application.persistentDataPath + "/config.json";
    private static GameConfig config;

    public static GameConfig Config
    {
        get
        {
            if (config == null)
            {
                LoadConfig();
            }
            return config;
        }
    }

    public static void LoadConfig()
    {
        if (System.IO.File.Exists(configPath))
        {
            string json = System.IO.File.ReadAllText(configPath);
            config = JsonUtility.FromJson<GameConfig>(json);
        }
        else
        {
            config = new GameConfig();
            SaveConfig(); // Сохраняем файл при первом запуске
        }
    }

    public static void SaveConfig()
    {
        string json = JsonUtility.ToJson(config, true);
        System.IO.File.WriteAllText(configPath, json);
    }
}
