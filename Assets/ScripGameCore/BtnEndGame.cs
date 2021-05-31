using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnEndGame : MonoBehaviour
{
    public void _OnClick()
    {
           var b = DataManager.dataManager;     
           if(GameContro.gameContro.numberOfState < b.listLevel.Count)
            {
                GameContro.gameContro.numberOfState += 1;
          
            for (int i = 0; i < b.listLevel.Count; i++)
            {
                if (GameContro.gameContro.numberOfState == i)
                {
                    GameContro.gameContro.level = b.listLevel[i];
                    GameContro.gameContro._LoadLevel();
           
                    this.FireEvent(GameEvent.InGame);
                    break;
                }
            }
            GameContro.gameContro.textLevel.text = "" + GameContro.gameContro.level;
          }
           else
            {
                this.FireEvent(GameEvent.GameMode);
              
            }
        
        
    }
}
