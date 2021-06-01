using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorScripAble : EditorWindow
{
    private Level level;
    private Sprite thubnail;
    private Sprite pathThubnail;
    private Vector2 postThubnail;
    private Vector2 postPathThubnail;
    private Vector2[] postDostsVector2 ;
    private int numbers;
    private float oneStar;
    private float twoStar;
    private float threeStar;
   
    [MenuItem("LevelEditor/EditLevel")]
    private static void ShowWindow()
    {
        var window = GetWindow<EditorScripAble>();
        window.titleContent = new GUIContent("EditLevel");
        window.Show();
    }
    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        level = (Level)EditorGUILayout.ObjectField("Level: ", level, typeof(Level), false);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        thubnail = (Sprite)UnityEditor.EditorGUILayout.ObjectField("Thubnail : ", thubnail, typeof(Sprite),true);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        pathThubnail = (Sprite)UnityEditor.EditorGUILayout.ObjectField("PathThubnail : ", pathThubnail, typeof(Sprite), true);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        postThubnail = UnityEditor.EditorGUILayout.Vector2Field("PostThubnail : ", postThubnail);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        postPathThubnail = UnityEditor.EditorGUILayout.Vector2Field("PostPathThubnail : ", postPathThubnail);
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal();
         numbers = UnityEditor.EditorGUILayout.IntField("Numbers : ", numbers);
     
        GUILayout.EndHorizontal();


      
        if ( numbers > 0)
        {
            postDostsVector2 = new Vector2[numbers];
            GUILayout.BeginVertical();

            for (int i = 0; i < postDostsVector2.Length; i++)
            {
                postDostsVector2[i] = UnityEditor.EditorGUILayout.Vector2Field("postDostsVector2 : ", postDostsVector2[i]);

            }

            GUILayout.EndVertical();

        }

        GUILayout.BeginHorizontal();
        oneStar = UnityEditor.EditorGUILayout.FloatField("OneStar : ", oneStar);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        twoStar = UnityEditor.EditorGUILayout.FloatField("TwoStar : ", twoStar);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        threeStar = UnityEditor.EditorGUILayout.FloatField("ThreeStar : ", threeStar);
        GUILayout.EndHorizontal();


        if (GUILayout.Button("Save"))
        {
         

            if( level != null)
            {
                level.thubnail = this.thubnail;
                level.pathThubnail = this.pathThubnail;
                level.postThubnail = this.postPathThubnail;
                level.postPathThubnail = this.postPathThubnail;
                level.postDostsVector2 = new Vector2[numbers];
                for( int i = 0; i< this.postDostsVector2.Length; i++)
                {
                    level.postDostsVector2[i] = this.postDostsVector2[i];
                }
                level.oneStar = this.oneStar;
                level.twoStar = this.twoStar;
                level.threeStar = this.threeStar;
                Debug.Log("Save");
            }    
            else
            {
                Debug.Log("Pls Chose Level");
            }              

        }
        if (GUILayout.Button("Reset"))
        {
            this.level = null;
            this.thubnail = null; ;
            this.pathThubnail = null; ;
            this.postThubnail = new Vector2(0, 0);
            this.postPathThubnail = new Vector2(0, 0);
            this.numbers = 0;
            this.postDostsVector2 = null;        
            this.oneStar = 0;
            this.twoStar = 0;
            this.threeStar = 0;
            Debug.Log("Reset");


        }

    }
}
