using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    /// <summary>
    /// Attributes for monsters and moves
    /// </summary>

    /// <summary>
    /// The influence of the attack
    /// </summary>
    public enum attackType
    {
        Regular, Buff, Debuff
    }

    public string moveName;
    public int damage;
    public AttributeDatabase.Attribute damageType;
    public int uses;
    public attackType effect;

    public Move()
    {
        this.moveName = "-";
        this.damage = 0;
        this.damageType = AttributeDatabase.Attribute.Normal;
        this.uses = 0;
        this.effect = attackType.Regular;
    }

    public Move(string moveName, int damage, AttributeDatabase.Attribute damageType, int uses, attackType effect)
    {
        this.moveName = moveName;
        this.damage = damage;
        this.damageType = damageType;
        this.uses = uses;
        this.effect = effect;
    }
}
