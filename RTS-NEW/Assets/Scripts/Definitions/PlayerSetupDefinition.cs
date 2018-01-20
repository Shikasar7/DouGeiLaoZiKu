﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSetupDefinition {

    public string Name;

    public Transform Location;

    public Color AccentColor;

    public List<GameObject> StartingUnits = new List<GameObject>();

    public bool IsAi;

    public float Credits;

}
