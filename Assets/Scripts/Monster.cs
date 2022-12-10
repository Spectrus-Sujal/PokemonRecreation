using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    [SerializeField] int maxHelath;
    [SerializeField] int speed;
    [SerializeField] private int defense;
    [SerializeField] private int attack;

    [SerializeField] int currentHelath;

    private Move[] moves;
}
