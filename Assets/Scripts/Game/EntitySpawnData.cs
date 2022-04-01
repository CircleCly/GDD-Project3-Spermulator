using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EntitySpawnData
{
    public string entityName;
    public BoxCollider2D spawnArea;
    public GameObject entity;
    public int initialCount;
}
