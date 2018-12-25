using System.Collections.Generic;

public class RandomEmptyPlacementSearcher : RandomPlacementSearcher {
    protected override IEnumerable<CellOnField> GetNeededCells(Field field) => field.GetEmptyCells();
}