using NuclearDecline.Runtime.Saves;
using UnityEngine;

namespace NuclearDecline.Runtime.Mock
{
    public sealed class MockSaveService : ISaveService
    {
        public bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public int GetInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public float GetFloat(string key, float defaultValue = 0f)
        {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }

        public void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }

        public string GetString(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }

        public void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }

        public bool GetBool(string key, bool defaultValue = false)
        {
            int fallback = defaultValue ? 1 : 0;
            return PlayerPrefs.GetInt(key, fallback) != 0;
        }

        public void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        public void Save()
        {
            PlayerPrefs.Save();
            Debug.Log("[NuclearDecline] Mock save flushed.");
        }

        public void DeleteKey(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }
    }
}
