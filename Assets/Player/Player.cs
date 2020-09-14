using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IManager
{

    //#region SINGLETON PATTERN
    //public static Player _instance;
    //public static Player Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            _instance = FindObjectOfType<Player>();

    //            if (_instance == null)
    //            {
    //                GameObject container = new GameObject("Player");
    //                _instance = container.AddComponent<Player>();
    //            }
    //        }

    //        return _instance;
    //    }
    //}
    //#endregion

    public Text kiwiHUDcounter;
    [SerializeField] private int m_kiwis = 0;
    [SerializeField] private bool m_hasKiwiThrow = false;
    [SerializeField] private int deaths = 0;

    public Player(int kiwis, bool hasKiwiThrow, int deaths)
    {
        m_kiwis = kiwis;
        m_hasKiwiThrow = hasKiwiThrow;
        this.deaths = deaths;
    }

    public bool HasKiwiThrow { get => m_hasKiwiThrow; set => m_hasKiwiThrow = value; }
    public int Deaths { get => deaths; set => deaths = value; }
    public int Kiwis { get => m_kiwis; set => m_kiwis = value; }

    public void HandlePlayerInput(Player player, string message)
    {
        if (message == "Fire1")
        {
            if (HasKiwiThrow)
            {
                //TODO kiwi on inventory --
                // launch new kiwi flying
                Debug.Log("LOL");

            }
        }

    }

    void Start()
    {
        kiwiHUDcounter.text = Kiwis.ToString();
        Level.subsribe(this);
    }

    void Awake()
    {
        //load from dataset
        GameData data = SaveSystem.LoadGameState();
        Kiwis = data?.kiwis ?? 0;
        Deaths = data?.deaths ?? 0;
    }

    public void AddKiwis(int i)
    {
        Kiwis += i;
        kiwiHUDcounter.text = Kiwis.ToString();
    }

    public int GetKiwis()
    {
        return Kiwis;
    }

}
