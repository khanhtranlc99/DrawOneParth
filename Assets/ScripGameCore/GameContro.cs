using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContro : GameUIMannager
{
    public static GameContro gameContro;
    public List<Dost> listDost;
    public SpriteRenderer item;
    public SpriteRenderer pathOfItem;
    public int number;
    public Level level;
    public Sprite spriteDot;
    public int numberOfState;
    public Text textLevel;
    private void Awake()
    {
        gameContro = this;
    }
    public void OnEnable()
    {
        this.RegisterListener(GameEvent.StartGame, _HandleStartGame);
        this.RegisterListener(GameEvent.LoadGame, _HandleLoadGame);
        this.RegisterListener(GameEvent.InGame, _HandleInGame);
        this.RegisterListener(GameEvent.Pause, _HandlePause);
        this.RegisterListener(GameEvent.EndGame, _HandleEndGame);
        this.RegisterListener(GameEvent.Shop, _HandleShop);
        this.RegisterListener(GameEvent.GameMode, _HandleGameMode);
    }
    // Start is called before the first frame update
    void Start()
    {
        //LoadLevel();
        this.FireEvent(GameEvent.StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void _CheckListDots()
    {
        for ( int i = 0; i < listDost.Count;i ++)
        {
            number += listDost[i].wasTouch;
            if (number == listDost.Count)
            {
                pathOfItem.sprite = level.pathThubnail;
                this.FireEvent(GameEvent.EndGame);
                _HandelHideDots();

            }
            else
            {
                listDost[i].wasTouch = 0;
                listDost[i].spriteRenderer.color = Color.white;
              
            }
        }
        number = 0;
    }
    public void _LoadLevel()
    {
        item.sprite = level.thubnail;
        pathOfItem.sprite = /*level.pathThubnail*/ null; //null  
        item.transform.position = new Vector2(level.postThubnail.x, level.postThubnail.y);
        pathOfItem.transform.position = new Vector2(level.postPathThubnail.x, level.postPathThubnail.y);     
        for ( int i = 0;  i < level.arrayVector2.Length; i ++)
        {
            var a = Instantiate(level.dost, level.arrayVector2[i], Quaternion.identity);
            listDost.Add(a);
        }
    }
    public void _HandelBtnTutorial()
    {

        for (int i = 0; i < listDost.Count; i++)
        {
            listDost[i].spriteRenderer.sprite = spriteDot;
          
        }
    }
    public void _HandelHideDots()
    {
        //var a = GameObject.FindGameObjectsWithTag("Dot");
        //for ( int i = 0; i < a.Length; i ++)
        //{
        //    Destroy(a[i]);
        //}
        for (int i = 0; i < listDost.Count; i++)
        {
            Destroy(listDost[i].gameObject);
        }
        listDost.Clear();
    }


    // Update is called once per frame

    public override void _HandleStartGame(object param)
    {
        base._HandleStartGame(param);

    }
    public override void _HandleLoadGame(object param)
    {
        base._HandleLoadGame(param);

    }
    public override void _HandleInGame(object param)
    {
        base._HandleInGame(param);

    }
    public override void _HandlePause(object param)
    {
        base._HandlePause(param);
    }
    public override void _HandleEndGame(object param)
    {
        base._HandleEndGame(param);
    }
    public override void _HandleGameMode(object param)
    {
        base._HandleGameMode(param);

    }
    public override void _HandleShop(object param)
    {
        base._HandleShop(param);

    }
}
