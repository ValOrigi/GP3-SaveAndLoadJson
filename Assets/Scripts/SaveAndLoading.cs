using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEditor.Progress;

public class SaveAndLoading : MonoBehaviour
{
    private int numOfEnemies;
    public GameObject player;
    public List<GameObject> allEenemies;
    [HideInInspector] public List<string> enemyNames = new List<string>();
    public List<Vector3> initialSpawn = new List<Vector3>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            SaveData saveData = new SaveData()
            {
                position = player.transform.position,
                enemy = enemyNames,
                enemyPos = initialSpawn,
                enemyNum = enemyNames.Count,
            };

            string savedData = JsonUtility.ToJson(saveData);
            File.WriteAllText(Application.persistentDataPath + "Savefile.txt", savedData);

            Debug.Log(savedData);
            Debug.Log(Application.persistentDataPath + "Savefile.txt");
        }

        if (Input.GetKeyDown(KeyCode.P)) 
        {
            if (File.Exists(Application.persistentDataPath + "Savefile.txt")) 
            {
                string ReadData = File.ReadAllText(Application.persistentDataPath + "Savefile.txt");

                SaveData saveData = JsonUtility.FromJson<SaveData>(ReadData);

                player.transform.position = saveData.position;

                numOfEnemies = saveData.enemyNum;
                
                List<string> enemyNames = saveData.enemy;

                //load position
                for (int i = 0; i < 10; i++)
                {
                    GameObject.Find(""+i).transform.position = saveData.enemyPos[i];
                }

                //deload all inactive
                for (int i = 0; i < numOfEnemies; i++) 
                {
                    foreach (GameObject item in allEenemies)
                    {
                        if (item.name == enemyNames[i]) 
                        {
                            item.SetActive(false);
                            break;
                        }
                    }
                }
            }
        }
    }

    public class SaveData
    {
        public Vector3 position;
        public int enemyNum;
        public List<string> enemy;
        public List<Vector3> enemyPos;
    }
}
