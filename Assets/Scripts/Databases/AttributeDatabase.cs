using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeDatabase : MonoBehaviour
{
    
    public enum Attribute
    {
        Fire, Water, Grass, Normal, Fight, Ghost
    }

    public List<Attributes> AttributeList = new List<Attributes>()
    {
        new Attributes(Attribute.Fire, Attribute.Water, Attribute.Grass),
        new Attributes(Attribute.Water, Attribute.Grass, Attribute.Fire),
        new Attributes(Attribute.Grass, Attribute.Fire, Attribute.Water),
        new Attributes(Attribute.Normal, Attribute.Fight, Attribute.Ghost),
        new Attributes(Attribute.Fight, Attribute.Normal, Attribute.Ghost),
        new Attributes(Attribute.Ghost, Attribute.Fire, Attribute.Fight)
    };

    
    public bool isWeakTo(Attribute type, Attribute checker)
    {
        return AttributeList[(int)type].isWeakAgainst(checker);
    }

    public bool isGoodAgainst(Attribute type, Attribute checker)
    {
        return AttributeList[(int)type].isGoodAgainst(checker);
    }
}
