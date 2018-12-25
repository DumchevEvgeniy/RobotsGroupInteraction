﻿using System;
using UnityEngine;

public class Level : MonoBehaviour {
    public Int32 length = 21;
    public Int32 width = 13;
    public Int32 sandCubesCount = 54;
    public Int32 easyEnemiesCount = 6;
    public Int32 hardEnemyCount = 1;
    public Int32 bonusBombsCount = 0;
    public Int32 bonusFlamesCount = 0;
    public Int32 bonusSpeedCount = 0;
    public Int32 bonusWallpassCount = 0;
    public Int32 bonusDetonatorCount = 0;
    private SmartMap gameMap;

    private void Start() {
        gameMap = new SmartMap(length, width, new MapFloor(), new ConcreteCube());
        gameMap.AddElements<RandomPlacementWithPlayerDistance>(new BreakCube(), sandCubesCount);
        gameMap.AddElements<RandomPlacementWithPlayerDistance>(GameFactory.CreateEasyEnemy(), easyEnemiesCount);
        gameMap.AddElements<RandomPlacementWithPlayerDistance>(GameFactory.CreateHardEnemy(gameMap), hardEnemyCount);
        gameMap.CreateAll();
    }

    public SmartMap Map {
        get { return gameMap; }
    }
}