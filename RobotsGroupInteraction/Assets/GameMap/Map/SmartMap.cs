using System;

public class SmartMap : GameMap {
    public SmartMap(Int32 length, Int32 width, DynamicGameObject floorCubeTemplate, DynamicGameObject concreteCubeTemplate) 
        : base(length, width, floorCubeTemplate, concreteCubeTemplate) {
    }

    public void AddElements<TPlacementSearcher>(GameElements<TPlacementSearcher> collection) 
        where TPlacementSearcher : BasePlacementSearcher, new() {
        foreach(var cell in collection.GetPlacements(Field))
            Field.GetCell(cell.IndexRow, cell.IndexColumn).AddGameObject(collection.Element);
    }
    public void AddElements<T>(DynamicGameObject element, Int32 elementsCount) where T : BasePlacementSearcher, new() {
        AddElements(new GameElements<T>(element, elementsCount));
    }
}
