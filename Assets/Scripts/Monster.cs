using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The basis for all monsters, containing 
/// all components a monster needs
/// </summary>
public class Monster
{
    // Stats
    public string monsterName;
    public Move.Attribute type;
    public int maxHelath;
    public int speed;
    public int defense;
    public int attack;

    public bool isTurn = false;

    private int currentHelath;

    public Move[] moves;

    /// <summary>
    ///  A monster
    /// </summary>
    /// <param name="monsterName"> Name</param>
    /// <param name="type"> Monster Type</param>
    /// <param name="maxHealth"> Max Health</param>
    /// <param name="speed"> Speed</param>
    /// <param name="defense"> Defense</param>
    /// <param name="attack"> Attack</param>
    /// <param name="one"> Move 1</param>
    /// <param name="two"> Move 2</param>
    /// <param name="three"> Move 3</param>
    /// <param name="four"> MOve 4</param>
    public Monster(string monsterName, Move.Attribute type, int maxHealth, int speed, int defense, int attack, Move one, Move two, Move three, Move four)
    {
        this.monsterName = monsterName;
        this.type = type;
        this.maxHelath = maxHealth;
        currentHelath = maxHealth;
        this.speed = speed;
        this.defense = defense;
        this.attack = attack;

        this.moves = new Move[4];
        this.moves[0] = one;
        this.moves[1] = two;
        this.moves[2] = three;
        this.moves[3] = four;
    }

    public bool takeDamage(Move move)
    {
        Debug.Log("Before damage: " + currentHelath);

        Debug.Log("Damage: " + move.damage);

        bool damageTaken = false;

        if (move.damageType == type)
        {
            currentHelath -= move.damage;
            damageTaken = true;
        }

        if (!damageTaken && type - 1 < 0)
        {
            if (move.damageType == type + 2)
            {
                currentHelath -= move.damage + move.damage / 2;
                damageTaken = true;
            }
        }
        else if(!damageTaken && move.damageType == type - 1)
        {
            currentHelath -= move.damage + move.damage / 2;
            damageTaken = true;
        }

        Debug.Log("Damage Type: " + move.damageType);
        Debug.Log("Monster Type: " + type);

        if (!damageTaken)
        {
            currentHelath -= move.damage;
        }

        Debug.Log("After damage: " + currentHelath);

        return currentHelath <= 0;

    }
}
