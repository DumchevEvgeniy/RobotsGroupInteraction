using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class Field : IEnumerable<CellOnField> {
    private readonly CellOnField[,] field;
    public Int32 Length { get; private set; }
    public Int32 Width { get; private set; }

    public Field(Int32 length, Int32 width) {
        Length = length;
        Width = width;
        field = new CellOnField[width, length];
        InitializeCells();
    }

    private void InitializeCells() {
        for(Int32 indexRow = 0; indexRow < Width; indexRow++)
            for(Int32 indexColumn = 0; indexColumn < Length; indexColumn++)
                field[indexRow, indexColumn] = new CellOnField(indexRow, indexColumn, this);
    }

    public Field AddElement(Int32 indexRow, Int32 indexColumn, DynamicGameObject element) {
        GetCell(indexRow, indexColumn).AddGameObject(element);
        return this;
    }
    public Field AddElement(Cell cell, DynamicGameObject element) => AddElement(cell.IndexRow, cell.IndexColumn, element);

    public void RemoveElement(Int32 indexRow, Int32 indexColumn, Type type) {
        if(!OnField(indexRow, indexColumn))
            return;
        GetCell(indexRow, indexColumn).RemoveGameElement(type);
    }

    public IEnumerable<DynamicGameObject> GetDynamicGameObjects(Int32 indexRow, Int32 indexColumn) =>
        GetCell(indexRow, indexColumn).DynamicGameObjects;
    public CellOnField GetCell(Int32 indexRow, Int32 indexColumn) => field[indexRow, indexColumn];

    public IEnumerable<CellOnField> FindAll(GameObject element) => FindAll(d => d.ToGameObject().Equals(element));
    public IEnumerable<CellOnField> FindAll(DynamicGameObject element) => FindAll(d => d.Equals(element));
    public IEnumerable<CellOnField> FindAll(Type elementType) => FindAll(d => d.IsDerived(elementType));
    private IEnumerable<CellOnField> FindAll(Predicate<DynamicGameObject> predicate) =>
        this.Where(cell => cell.DynamicGameObjects.Exists(dgo => predicate(dgo)));

    public IEnumerable<CellOnField> GetEmptyCells() => this.Where(cell => cell.IsEmpty());
    public Boolean OnField(Int32 indexRow, Int32 indexColumn) =>
        indexRow >= 0 && indexRow < Width && indexColumn >= 0 && indexColumn < Length;

    public IEnumerator<CellOnField> GetEnumerator() {
        for(Int32 indexRow = 0; indexRow < Width; indexRow++)
            for(Int32 indexColumn = 0; indexColumn < Length; indexColumn++)
                yield return GetCell(indexRow, indexColumn);
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
