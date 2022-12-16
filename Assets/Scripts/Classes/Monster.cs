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
    private int maxHealth;
    private int speed;
    private int defense;
    private int attack;

    private int currentHealth;

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
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        this.speed = speed;
        this.defense = defense;
        this.attack = attack;

        this.moves = new Move[4];
        this.moves[0] = one;
        this.moves[1] = two;
        this.moves[2] = three;
        this.moves[3] = four;
    }

    public Monster(Monster mon)
    {
        this.monsterName = mon.monsterName;
        this.type = mon.type;
        this.maxHealth = mon.maxHealth;
        currentHealth = mon.maxHealth;
        this.speed = mon.speed;
        this.defense = mon.defense;
        this.attack = mon.attack;

        this.moves = new Move[4];
        this.moves[0] = mon.moves[0];
        this.moves[1] = mon.moves[1];
        this.moves[2] = mon.moves[2];
        this.moves[3] = mon.moves[3];
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

        currentHealth -= attack + damage - defense;

        Debug.Log(monsterName + " Current Health: " + currentHealth);

        return currentHealth <= 0;
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
        return ((double)currentHealth / maxHealth) * 100;
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
