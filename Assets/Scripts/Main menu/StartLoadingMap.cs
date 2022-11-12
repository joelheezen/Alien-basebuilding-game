using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class StartLoadingMap : MonoBehaviour
{
    private string size;
    private string biome;
    private Button btn;
    public TMP_Dropdown Dropdown;
    public TMP_InputField Xinput;
    public TMP_InputField Yinput;
    public GameObject emptyObject;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Clicked);
    }

    void Clicked()
    {
        float mapX = float.Parse(Xinput.text);
        float mapY = float.Parse(Yinput.text);
        size = mapX.ToString() + "x" + mapY.ToString();
        switch (Dropdown.value){
            case 0: biome = "frozen_tundra";
            break;
            case 1: biome = "temperate";
            break;
        }

        GameData.SaveThings(size, biome);

        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
    }

}
