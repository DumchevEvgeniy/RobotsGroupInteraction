﻿using System;

public class BaseMap {
    public Int32 Length { get; private set; }
    public Int32 Width { get; private set; }
    public Field Field { get; private set; }
    public Field Foundation { get; private set; }

    public BaseMap(Int32 length, Int32 width) {
        MapSize.AdjustmentSize(ref length, ref width);
        Length = length;
        Width = width;
        Field = new Field(Length, Width);
        Foundation = new Field(Length, Width);
    }
}
