using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static string size;
    public static string biome;
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    
    public static void SaveThings(string s, string b){
        size = s;
        biome = b;
    }

    
}
