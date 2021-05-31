using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnStateODP : MonoBehaviour
{
    public int numberOfState;
   public void _OnClick()
    {
        var b = DataManager.dataManager;
         for( int i = 0; i < b.listLevel.Count; i ++)
        {
            if (numberOfState == i )
            {
                GameContro.gameContro.level = b.listLevel[i];
                GameContro.gameContro._LoadLevel();
                GameContro.gameContro.numberOfState = this.numberOfState;
                GameContro.gameContro.textLevel.text = "Level " + numberOfState;
            }
        }
    }
}
