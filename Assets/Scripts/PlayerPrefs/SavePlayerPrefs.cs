using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPrefs : MonoBehaviour
{
    private PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        playerData = PlayerData.Instance;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("HP", playerData.HP);
        PlayerPrefs.SetInt("MP", playerData.MP);
        PlayerPrefs.SetInt("XP", playerData.XP);
        PlayerPrefs.SetInt("sprite", playerData.CardIndex);
    }

    public void LoadData()
    {
        playerData.SetPlayerData(PlayerPrefs.GetInt("HP"), PlayerPrefs.GetInt("MP"), PlayerPrefs.GetInt("XP"),
            PlayerPrefs.GetInt("sprite"));
    }
}
