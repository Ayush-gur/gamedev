using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveandLoad : MonoBehaviour
{
    int SavedKillCounter = KillCounter.KillValue;
    public GameObject Player;
    private void Awake()
    {
        SaveObject saveObject = new SaveObject
        {
            SavedKillCounter = KillCounter.KillValue,
            playerPosition = Player.transform.position 
        };
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log(json);

        SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
        Debug.Log(loadedSaveObject.SavedKillCounter);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Load();
        }
    }
    private void Save()
    {
      
        SaveObject saveObject = new SaveObject
        {
            playerPosition = Player.transform.position,
            SavedKillCounter = KillCounter.KillValue,
        };
        string json = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.dataPath + "/save.txt", json);

        Debug.Log("Saved");
    }
    private void Load()
    {
        if(File.Exists(Application.dataPath + "/save.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
            Debug.Log("Loaded" + saveString);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            Player.transform.position = saveObject.playerPosition;
            KillCounter.KillValue = saveObject.SavedKillCounter;
        }
    }
    private class SaveObject
    {
        public int SavedKillCounter;
        public Vector3 playerPosition;

    }
}
