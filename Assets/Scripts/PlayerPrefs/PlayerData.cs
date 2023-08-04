using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int HP;
    public int MP;
    public int XP;
    public int CardIndex;

    public delegate void OnPlayerDataChange(int hp, int mp, int xp, int cardIndex);
    public static event OnPlayerDataChange OnDataChange;

    private static PlayerData _instance = null;

    public static PlayerData Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new PlayerData(500, 1500, 2500, 0);
            }

            return _instance;
        }
    }

    private PlayerData(int hp, int mp, int xp, int cardIndex)
    {
        this.HP = hp;
        this.MP = mp;
        this.XP = xp;
        this.CardIndex = cardIndex;
    }

    public void SetPlayerData(int hp, int mp, int xp, int cardIndex)
    {
        this.HP = hp;
        this.MP = mp;
        this.XP = xp;
        this.CardIndex = cardIndex;

        OnDataChange?.Invoke(hp, mp, xp, cardIndex);
    }
}
