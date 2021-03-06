﻿using System;
using UnityEngine;

public class EnemyWithSmoothMovement : EnemyWithSmoothMovementBase {
    public Single rangeLook = 1f;
    protected static System.Random random = new System.Random();

    protected override Boolean CanMove() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(!Physics.Raycast(ray, out hit))
            return false;
        var hitObject = hit.transform.gameObject;
        if(hitObject.OneFrom(Enemy.tag, Robot.tag))
            return true;
        if(wallpass && hitObject.CompareTag(BreakCube.tag))
            return true;
        return hit.distance > rangeLook;
    }
    protected override Boolean NeededRotateAfterMoving(GameObject gameObject) {
        return OnUnevenPosition(gameObject);
    }
    protected override Single GetRotationAngle() {
        return random.Next(-1, 2) * 90;
    }
    
    private Boolean OnUnevenPosition(GameObject gameObject) {
        var position = gameObject.transform.position;
        return position.x.IsUneven() && position.z.IsUneven();
    }
}