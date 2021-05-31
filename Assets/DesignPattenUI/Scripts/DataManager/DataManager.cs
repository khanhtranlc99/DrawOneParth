using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class DataManager : MonoBehaviour
{
    public static DataManager dataManager;
    public int coinGame;
    public int diamonGame;
    public List<Level> listLevel;
    string path;
    private void Awake()
    {
        dataManager = this; 
        path = Application.persistentDataPath + "dataMap";
        //File.Delete(path);
    }
    private void Start()
    {
        //_Load();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
          
        }
    }

     public void AddCoinOrDiamon( int coin , int diamon )
    {
        coinGame += coin;
        diamonGame += diamon;

        _Save();
    }    
    public void _Save()
    {

        SaveMap saveMap = new SaveMap(this);
        SaveSystem.SaveData<SaveMap>(saveMap, path);

    }
    public void _Load()
    {
        if (File.Exists(path))
        {
            SaveMap data = SaveSystem.LoadData<SaveMap>(path);
            coinGame = data.coin;
            diamonGame = data.coin;
          for ( int i = 0; i < data.mapLock.Length; i ++)
            {
                listLevel[i].wasPlay = data.mapLock[i];
            }
        }
     
    }
  
}
