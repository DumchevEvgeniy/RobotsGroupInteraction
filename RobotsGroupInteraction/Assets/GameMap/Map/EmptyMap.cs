using System;
using UnityEngine;

public class EmptyMap : BaseMap {
    private GameObject gameMap;

    public EmptyMap(Int32 length, Int32 width, DynamicGameObject floorCubeTemplate) 
        : base(length, width) {
        InitializeMap(floorCubeTemplate);
    }

    private void InitializeMap(DynamicGameObject floorCubeTemplate) {
        for(Int32 offsetByX = 0; offsetByX < Width; offsetByX++)
            for(Int32 offsetByZ = 0; offsetByZ < Length; offsetByZ++) {
                gameMap = floorCubeTemplate.Create();
                gameMap.transform.position = new Vector3(offsetByX, 0, offsetByZ);
                gameMap.transform.rotation = new Quaternion();
                //gameMap.transform.localScale = new Vector3(Width, gameMap.transform.localScale.y, Length);
            }
    }

    public void CreateAll() {
        foreach(var cell in Field) {
            foreach(var dynamicGameObject in cell.DynamicGameObjects) {
                var element = dynamicGameObject.Create();
                element.transform.position = new Vector3(cell.IndexRow, element.transform.position.y, cell.IndexColumn);
            }
        }
    }
}
