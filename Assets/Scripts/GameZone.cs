using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameZone : MonoBehaviour
{
    private Tilemap baseMap;
    private TileHolder tileHolder;
    private GameData gameData;
    private string[] sizes;
    private float width;
    private float height;
    private void Awake()
    {
        baseMap = GetComponent<Tilemap>();
        tileHolder = GetComponent<TileHolder>();
        gameData = GetComponent<GameData>();
    }

    private void Start(){
        sizes = GameData.size.Split('x');
        var origin = baseMap.origin;
        var cellSize = baseMap.cellSize;
        baseMap.ClearAllTiles();
        var currentCellPosition = origin;
        width = float.Parse(sizes[0]);
        height = float.Parse(sizes[1]);
        for (float h = 0; h < height; h++){
            for (float w = 0; w < width; w++){
                baseMap.SetTile(currentCellPosition, tileHolder.getRandomTile(Mathf.PerlinNoise(h/(height/10),w/(width/10))));
                //Debug.Log(Mathf.PerlinNoise(h/height,w/width));
                currentCellPosition = new Vector3Int( (int) (cellSize.x + currentCellPosition.x), currentCellPosition.y, origin.z);
            }
            currentCellPosition = new Vector3Int(origin.x, (int) (cellSize.y + currentCellPosition.y), origin.z);
        }
    }

    // private void Start(){
    //     sizes = GameData.size.Split('x');
    //     var origin = baseMap.origin;
    //     var cellSize = baseMap.cellSize;
    //     baseMap.ClearAllTiles();
    //     var currentCellPosition = origin;
    //     width = int.Parse(sizes[0]);
    //     height = int.Parse(sizes[1]);
    //     for (var h = 0; h < height; h++){
    //         for(var w = 0; w < width; w++){
    //             baseMap.SetTile(currentCellPosition, tileHolder.getRandomTile());
    //             currentCellPosition = new Vector3Int( (int) (cellSize.x + currentCellPosition.x), currentCellPosition.y, origin.z);
    //         }
    //         currentCellPosition = new Vector3Int(origin.x, (int) (cellSize.y + currentCellPosition.y), origin.z);
    //     }
    //     baseMap.CompressBounds();
    //     NearestNeighbourCheck();
    //     Debug.Log("finished randomising tiles");
    // }

    // private void NearestNeighbourCheck(){
    //     List<TileBase> setTileList = new List<TileBase>();
    //     List<Vector3Int> cellList = new List<Vector3Int>();
    //     var origin = baseMap.origin;
    //     var currentCellPosition = origin;
    //     var cellSize = baseMap.cellSize;
    //     for (var h = 0; h < height; h++){
    //         for (var w = 0; w < width; w++){
    //             //check all cells for set tiles and puts them into an array to acces their positions in the next step
    //             var tileToCheck = baseMap.GetTile(currentCellPosition);
    //             if (tileToCheck != null){
    //                 setTileList.Add(tileToCheck);
    //                 cellList.Add(currentCellPosition);
    //             }
    //             currentCellPosition = new Vector3Int( (int) (cellSize.x + currentCellPosition.x), currentCellPosition.y, origin.z);
    //         }
    //         currentCellPosition = new Vector3Int(origin.x, (int) (cellSize.y + currentCellPosition.y), origin.z);
    //     }
    //     currentCellPosition = origin;
    //     for (var h = 0; h < height; h++){
    //         for (var w = 0; w < width; w++){
    //             //check all cells for nulltiles and places a copy of the closest tile in the cell
    //             var tileToCheck = baseMap.GetTile(currentCellPosition);
    //             var saveI = 0;
    //             int lowestDiff = int.MaxValue;
    //             if(tileToCheck == null){
    //                 for(var i = 0; i < cellList.Count; i++){
    //                     var diff = currentCellPosition - cellList[i];
    //                     var diffTotal = Mathf.Abs(diff.x) + Mathf.Abs(diff.y);
    //                     if (diffTotal < lowestDiff){
    //                         lowestDiff = diffTotal;
    //                         saveI = i;
    //                     }
    //                 }
    //                 var tileToGet = setTileList[saveI].name;
                    
    //                 baseMap.SetTile(currentCellPosition, tileHolder.GetTile(tileToGet));
    //             }
    //             currentCellPosition = new Vector3Int( (int) (cellSize.x + currentCellPosition.x), currentCellPosition.y, origin.z);
    //         }
    //         currentCellPosition = new Vector3Int(origin.x, (int) (cellSize.y + currentCellPosition.y), origin.z);
    //     }
    // }
}
