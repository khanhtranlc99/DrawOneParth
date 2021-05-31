using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveMap
{
    public int coin;
    public int diamon;
    public bool[] mapLock;
    public SaveMap(DataManager dataManager)
    {
        coin = dataManager.coinGame;
        diamon = dataManager.diamonGame;
        mapLock = new bool[dataManager.listLevel.Count];
        for ( int i = 0; i < dataManager.listLevel.Count; i++)
        {
            mapLock[i] = dataManager.listLevel[i].wasPlay;
        }
     
    }
}
