using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileHolder : MonoBehaviour
{
    public TextAsset BiomeFile;
    public TextAsset FloortileFile;
    private Tiles tilesInJson;
    private Biomes biomesInJson;
    private List<Til> tileList = new List<Til>();
    private string[] tilesetToUse;
    private Tile tileToReturn;
    private string biomeString = GameData.biome;
    private List<string> tileListFromBiome = new List<string>();
    private void Awake(){
        //loads from biomes.json and extracts the tileset to use in selected biome
        Biomes biomesInJson = JsonUtility.FromJson<Biomes>(BiomeFile.text);
        foreach(Biome bi in biomesInJson.biomes){
            if (bi.id == biomeString){
                tilesetToUse = bi.tileset;
            }
        }
        // loads tiles from floortiles.json and compares to selected biome tileset and puts that into a list of tiles to use when generating map
        Tiles tilesInJson = JsonUtility.FromJson<Tiles>(FloortileFile.text);
        foreach(Til tile in tilesInJson.tiles){
            for (var i = 0; i < tilesetToUse.Length; i++){
                if(tilesetToUse[i] == tile.id){
                    tileList.Add(tile);
                }
            }
       }
    }

    public Tile getRandomTile(float perlinPercentage){
        int totalWeight = 0;
        for (var i = 0; i < tileList.Count; i++){
            totalWeight += tileList[i].weight;
        }
        var top = 0;
        for (var i = 0; i < tileList.Count; i++){
            top += tileList[i].weight;
            if (perlinPercentage*totalWeight < top){
                tileToReturn = (Tile) Resources.Load(tileList[i].location, typeof(Tile));
                Debug.Log(perlinPercentage*totalWeight + " " + top);
                break;
            }
        }
        return tileToReturn;
    }

    // public Tile getRandomTile(){
    //     //generates a random tile to spawn on the map
    //     int totalPercentage = 0;

    //     var randomTile = "";

    //     for (var i = 0; i < tileList.Count; i++){
    //         totalPercentage += tileList[i].weight;
    //     }
    //     var randomNumber = Random.Range(0, totalPercentage);
    //     var top = 0;
    //     for (var i = 0; i < tileList.Count; i++){
    //         top += tileList[i].weight;
    //         if (randomNumber < top){
    //             randomTile = tileList[i].location;
    //             break;
    //         }
    //     }

    //     var chanceToSpawn = Random.Range(0,100);
    //     if (chanceToSpawn > 98){
    //         tileToReturn = (Tile) Resources.Load(randomTile, typeof(Tile));
    //     }
    //     else{
    //         tileToReturn = null;
    //     }
        
    //     return tileToReturn;
    // }

    public Tile GetTile(string id){
        //returns the tile asked for
        for(var i = 0; i < tileList.Count; i++){
            Tile sameTile = (Tile) Resources.Load(tileList[i].location, typeof(Tile));
            if (id == sameTile.name){
                tileToReturn = sameTile;
            }
        }
        return tileToReturn;
    }
}
