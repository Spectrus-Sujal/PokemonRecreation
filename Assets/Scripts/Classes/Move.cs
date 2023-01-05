using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves that Pokemons can use in combat
/// </summary>
public class Move
{
    // The effects that moves can have
    public enum statAffected
    {
        Health, Speed, Attack, Defense
    }

    // Variables
    public string moveName;
    public int damage;
    public AttributeDatabase.Attribute damageType;
    public statAffected stat;

    // Default Constructor
    public Move()
    {
        this.moveName = "-";
        this.damage = 0;
        this.damageType = AttributeDatabase.Attribute.Normal;
        this.stat = statAffected.Health;
    }

    // Constructor

    public Move(string moveName, int damage, AttributeDatabase.Attribute damageType, statAffected stat)
    {
        this.moveName = moveName;
        this.damage = damage;
        this.damageType = damageType;
        this.stat = stat;
    }
}
