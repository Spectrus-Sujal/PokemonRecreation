using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

/// <summary>
/// The basis for all monsters, containing 
/// all components a monster needs
/// </summary>
public class Monster
{
    // Stats
    public string monsterName;
    private AttributeDatabase.Attribute type;
    private int maxHelath;
    private int speed;
    private int defense;
    private int attack;

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
    public Monster(string monsterName, AttributeDatabase.Attribute type, int maxHealth, int speed, int defense, int attack, Move one, Move two, Move three, Move four)
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

    public bool takeDamage(int attack, Move move, AttributeDatabase AB)
    {
        int damage = 0;
        if (isWeakTo(AB, move.damageType))
        {
            damage = move.damage + (move.damage / 2);
        }
        else if (isGoodAgainst(AB, move.damageType))
        {
            damage = move.damage / 2;
        }
        else
        {
            damage = move.damage;
        }

        currentHelath -= attack + damage - defense;

        Debug.Log(monsterName + " Current Health: " + currentHelath);

        return currentHelath <= 0;
    }

    public bool isWeakTo(AttributeDatabase attributes, AttributeDatabase.Attribute move)
    {
        return attributes.isWeakTo(type, move);
    }

    public bool isGoodAgainst(AttributeDatabase attributes, AttributeDatabase.Attribute move)
    {
        return attributes.isGoodAgainst(type, move);
    }

    public int getSpeed()
    {
        return speed;
    }

    public int getAttack()
    {
        return attack;
    }

    public double getHealthPercent()
    {
        return ((double)currentHelath / maxHelath) * 100;
    }

    public void debuff(Move move)
    {
        speed--;
        defense--;
        attack--;

        if (speed < 1) speed = 1;

        if (defense < 1) defense = 1;

        if (attack < 1) attack = 1;

    }

    public void buff(Move move)
    {
        speed++;
        defense++;
        attack++;
    }
}
