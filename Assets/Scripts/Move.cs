using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public enum Attribute
    {
        Fire, Water, Grass, Normal, Fight
    }

    public enum attackType
    {
        Regular, Buff, Debuff
    }

    public string name;
    public int damage;
    public Attribute damageType;
    public int uses;
    public attackType effect;

    public Move(string name, int damage, Attribute damageType, int uses, attackType effect)
    {
        this.name = name;
        this.damage = damage;
        this.damageType = damageType;
        this.uses = uses;
        this.effect = effect;
    }
}
