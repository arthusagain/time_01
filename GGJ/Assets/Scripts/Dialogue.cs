﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string npc;
    [TextArea(3,10)]
    public string[] sentences;

}
