using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves that Pokemon can use in combat
/// </summary>
public class Move
{
    // The effects that moves can have
    public enum attackType
    {
        Regular, Buff, Debuff, Heal, Run
    }

    // Variables
    public string moveName;
    public int damage;
    public AttributeDatabase.Attribute damageType;
    public attackType effect;

    // Default Constructor
    public Move()
    {
        this.moveName = "-";
        this.damage = 0;
        this.damageType = AttributeDatabase.Attribute.Normal;
        this.effect = attackType.Regular;
    }

    // Constructor

    public Move(string moveName, int damage, AttributeDatabase.Attribute damageType, attackType effect)
    {
        this.moveName = moveName;
        this.damage = damage;
        this.damageType = damageType;
        this.effect = effect;
    }
}
