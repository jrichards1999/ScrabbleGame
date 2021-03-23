using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTileButtonHandler : MonoBehaviour
{
    public GameObject[] MyPrefabs;

    public void Start() {
        MyPrefabs = Resources.LoadAll<GameObject>("Prefabs");
    }

    public void Update() {
        
    }

    public void ButtonClicked() {
        //GameObject newObject = Resources.Load("Assets/Prefabs/A") as GameObject;
        Vector2 position = new Vector2(0, 0);
        var MyPrefab = MyPrefabs[1];
        Instantiate(MyPrefab, position, Quaternion.identity);
    }
}
