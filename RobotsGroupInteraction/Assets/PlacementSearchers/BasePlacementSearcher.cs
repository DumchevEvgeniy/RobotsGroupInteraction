using System;
using System.Collections.Generic;

public abstract class BasePlacementSearcher {
    public abstract IEnumerable<CellOnField> GetPlacements(Field field, Int32 elementsCount);
}