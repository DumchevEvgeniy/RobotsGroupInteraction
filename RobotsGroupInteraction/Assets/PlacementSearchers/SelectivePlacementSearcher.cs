using System;
using System.Collections.Generic;
using System.Linq;

public abstract class SelectivePlacementSearcher : BasePlacementSearcher {
    public override IEnumerable<CellOnField> GetPlacements(Field field, Int32 elementsCount) {
        var availableCells = GetAvailableCells(GetNeededCells(field), GetProhibitedForUsingCells(field));
        if(availableCells == null)
            return Enumerable.Empty<CellOnField>();
        return GetPlacements(availableCells, elementsCount) ?? Enumerable.Empty<CellOnField>();
    }

    protected abstract IEnumerable<CellOnField> GetPlacements(IEnumerable<CellOnField> possibleCells, Int32 elementsCount);
    protected abstract IEnumerable<CellOnField> GetNeededCells(Field field);
    protected virtual IEnumerable<CellOnField> GetProhibitedForUsingCells(Field field) => null;

    private IEnumerable<T> GetAvailableCells<T>(IEnumerable<T> neededCells, IEnumerable<T> prohibitedCells) 
        where T : Cell {
        if(prohibitedCells == null && neededCells == null)
            return null;
        if(prohibitedCells == null)
            return neededCells;
        return neededCells.Except(prohibitedCells);
    }
}