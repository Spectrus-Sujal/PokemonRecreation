using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public string monsterName;
    public int maxHelath;
    public int speed;
    public int defense;
    public int attack;

    private int currentHelath;

    public Move[] moves;

    public Monster(string monsterName, int maxHealth, int speed, int defense, int attack)
    {
        this.monsterName = monsterName;
        this.maxHelath = maxHealth;
        this.speed = speed;
        this.defense = defense;
        this.attack = attack;
    }

    /// <summary>
    ///  A monster
    /// </summary>
    /// <param name="monsterName"> Name</param>
    /// <param name="maxHealth"> Max Health</param>
    /// <param name="speed"> Speed</param>
    /// <param name="defense"> Defense</param>
    /// <param name="attack"> Attack</param>
    /// <param name="one"> Move 1</param>
    /// <param name="two"> Move 2</param>
    /// <param name="three"> Move 3</param>
    /// <param name="four"> MOve 4</param>
    public Monster(string monsterName, int maxHealth, int speed, int defense, int attack, Move one, Move two, Move three, Move four)
    {
        this.monsterName = monsterName;
        this.maxHelath = maxHealth;
        this.speed = speed;
        this.defense = defense;
        this.attack = attack;

        this.moves = new Move[4];
        this.moves[0] = one;
        this.moves[1] = two;
        this.moves[2] = three;
        this.moves[3] = four;
    }
}
