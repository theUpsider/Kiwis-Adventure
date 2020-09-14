using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int kiwis;
    public int deaths;

    public GameData(Player player)
    {
        kiwis = player.Kiwis;
        deaths = player.Deaths;
    }
}
