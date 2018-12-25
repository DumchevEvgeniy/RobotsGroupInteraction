﻿using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class DynamicGameObject {
    private List<Type> typesForAddedScripts = new List<Type>();

    protected abstract String GetPrefabName();

    public GameObject ToGameObject() => Resources.Load<GameObject>(GetPrefabName());

    public void AddScriptType(Type scriptType) => typesForAddedScripts.Add(scriptType);

    public GameObject Create() {
        var gameObject = CreateGameObject();
        foreach(var script in typesForAddedScripts)
            gameObject.AddComponent(script);
        return gameObject;
    }

    protected virtual GameObject CreateGameObject() => UnityEngine.Object.Instantiate(ToGameObject());

    public Boolean IsDerived(System.Object obj) {
        if(obj == null)
            return false;
        return IsDerived(obj.GetType());
    }
    public Boolean IsDerived(Type objType) {
        if(objType == null)
            return false;
        var type = GetType();
        while(type != null) {
            if(objType == type)
                return true;
            type = type.BaseType;
        }
        return false;
    }

    public override Boolean Equals(System.Object obj) {
        if(obj == null)
            return false;
        return GetType() == obj.GetType();
    }
    public override Int32 GetHashCode() {
        return base.GetHashCode();
    }
}