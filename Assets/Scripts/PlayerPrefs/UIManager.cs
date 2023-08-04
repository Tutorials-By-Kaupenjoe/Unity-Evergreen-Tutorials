using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;

    [SerializeField] private TMP_InputField inputHP;
    [SerializeField] private TMP_InputField inputMP;
    [SerializeField] private TMP_InputField inputXP;

    [SerializeField] private TMP_Dropdown cardDropdown;

    [SerializeField] private TMP_Text HPText;
    [SerializeField] private TMP_Text MPText;
    [SerializeField] private TMP_Text XPText;

    private PlayerData playerData;
    private SavePlayerPrefs savePlayerPrefs;
    private CardPopulation cardPopulation;

    // private JSONLoader JSONLoader;

    private SpriteRenderer playerCardSpriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        playerData = PlayerData.Instance;
        PlayerData.OnDataChange += UpdateUI;
        savePlayerPrefs = GameObject.FindObjectOfType<SavePlayerPrefs>();

        cardPopulation = GameObject.FindObjectOfType<CardPopulation>();

        playerCardSpriteRenderer = GameObject.Find("PlayerCard").GetComponent<SpriteRenderer>();

        PopulateCardDropdown();
        OnLoad();

        saveButton.onClick.AddListener(() => { savePlayerPrefs.SaveData(); OnLoad(); });
        loadButton.onClick.AddListener(() => { savePlayerPrefs.LoadData(); OnLoad(); });

        OnDataChanges();
    }

    private void OnDataChanges()
    {
        cardDropdown.onValueChanged.AddListener((index) => Save(int.Parse(inputHP.text), int.Parse(inputMP.text),
            int.Parse(inputXP.text), index));

        inputHP.onEndEdit.AddListener((hpTextChange) => Save(int.Parse(hpTextChange), int.Parse(inputMP.text),
            int.Parse(inputXP.text), cardDropdown.value));

        inputMP.onEndEdit.AddListener((mpTextChange) => Save(int.Parse(inputHP.text), int.Parse(mpTextChange),
            int.Parse(inputXP.text), cardDropdown.value));

        inputXP.onEndEdit.AddListener((xpTextChange) => Save(int.Parse(inputHP.text), int.Parse(inputMP.text), 
            int.Parse(xpTextChange), cardDropdown.value));
    }

    private void Save(int hp, int mp, int xp, int index)
    {
        playerData.SetPlayerData(hp, mp, xp, index);
    }

    private void PopulateCardDropdown()
    {
        List<TMP_Dropdown.OptionData> data = new List<TMP_Dropdown.OptionData>();

        foreach(Sprite sprite in cardPopulation.allCardSprites)
        {
            data.Add(new TMP_Dropdown.OptionData(sprite.name, sprite));
        }

        cardDropdown.AddOptions(data);
    }

    private void OnLoad()
    {
        inputHP.text = playerData.HP.ToString();
        inputMP.text = playerData.MP.ToString();
        inputXP.text = playerData.XP.ToString();
        cardDropdown.value = playerData.CardIndex;
    }

    private void UpdateUI(int hp, int mp, int xp, int index)
    {
        playerCardSpriteRenderer.sprite = cardPopulation.allCardSprites[index];

        HPText.text = hp.ToString();
        MPText.text = mp.ToString();
        XPText.text = xp.ToString();
    }
}
