using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Level", menuName = "Level", order = 1)]
public class Level : ScriptableObject
{
    public Sprite thubnail;
    public Sprite pathThubnail;
    public Vector2 postThubnail;
    public Vector2 postPathThubnail;
    public Dost dost;
    public Vector2[] arrayVector2;
    public bool  wasPlay;
   
}
public class DotsAndTranform
{
    public Dost dost;
    public Vector2 tranformDots;
}
