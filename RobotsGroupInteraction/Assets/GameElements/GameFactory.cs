using UnityEngine;

public static class GameFactory {
    public static Enemy CreateEasyEnemy() {
        //var prefabName = "Enemy";
        var prefabName = "EnemyAgent";
        var enemy = new Enemy(prefabName, 100) {
            MovementSpeed = 1f,
            RotationSpeed = 50,
            Wallpass = false
        };
        enemy.AddScriptType(typeof(EnemyWithSmoothMovement));
        return enemy;
    }

    public static Enemy CreateHardEnemy(SmartMap map) {
        var prefabName = "HardEnemyAgent";
        //var prefabName = "HardEnemy";
        var enemy = new SmartEnemy(prefabName, 100, map) {
            MovementSpeed = 1.5f,
            RotationSpeed = 60,
            Wallpass = false
        };
        enemy.AddScriptType(typeof(EnemyWithSmartMovement));
        return enemy;
    }
}
