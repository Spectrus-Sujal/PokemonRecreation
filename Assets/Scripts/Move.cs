using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public enum Attribute
    {
        Fire, Water, Grass, Normal, Fight
    }

    public enum attackType
    {
        Regular, Buff, Debuff
    }

    public string moveName;
    public int damage;
    public Attribute damageType;
    public int uses;
    public attackType effect;

    public Move()
    {
        this.moveName = "-";
        this.damage = 0;
        this.damageType = Attribute.Normal;
        this.uses = 0;
        this.effect = attackType.Regular;
    }

    public Move(string moveName, int damage, Attribute damageType, int uses, attackType effect)
    {
        this.moveName = moveName;
        this.damage = damage;
        this.damageType = damageType;
        this.uses = uses;
        this.effect = effect;
    }
}
