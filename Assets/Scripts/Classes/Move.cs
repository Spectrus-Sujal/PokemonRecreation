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
        Regular, Buff, Debuff, Heal, Run
    }

    public string moveName;
    public int damage;
    public AttributeDatabase.Attribute damageType;
    public attackType effect;

    public Move()
    {
        this.moveName = "-";
        this.damage = 0;
        this.damageType = AttributeDatabase.Attribute.Normal;
        this.effect = attackType.Regular;
    }

    public Move(string moveName, int damage, AttributeDatabase.Attribute damageType, attackType effect)
    {
        this.moveName = moveName;
        this.damage = damage;
        this.damageType = damageType;
        this.effect = effect;
    }
}
