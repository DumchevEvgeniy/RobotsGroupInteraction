using System;
using System.Collections.Generic;

public class GameElements<TPlacementSearcher> where TPlacementSearcher : BasePlacementSearcher, new() {
    public DynamicGameObject Element { get; private set; }
    private Int32 elementsCount;

    public GameElements(DynamicGameObject element, Int32 elementsCount) {
        Element = element;
        this.elementsCount = elementsCount;
    }

    public IEnumerable<CellOnField> GetPlacements(Field field) => new TPlacementSearcher().GetPlacements(field, elementsCount);
}