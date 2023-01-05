using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Script containing info about all Attributes
/// </summary>
public class AttributeDatabase : MonoBehaviour
{
    /* Instructions to Create new Attributes

     1. Write the Attribute name in the public enum Attribute
     2. Write New Attribute(Attribute.(Attribute name from The first step),
                            Attribute.(The attribute that this is weak to)
                            Attribute.(The attribute that this is good against))

    */

    // Name of all Attributes
    // Used to reference that move from AttributeList
    public enum Attribute
    {
        Fire, Water, Grass, Normal, Fight, Ghost, Dragon
    }

    // List used by scripts to assign and access attributes
    public static readonly List<Attributes> AttributeList = new List<Attributes>()
    {
        new Attributes(Attribute.Fire, Attribute.Water, Attribute.Grass),
        new Attributes(Attribute.Water, Attribute.Grass, Attribute.Fire),
        new Attributes(Attribute.Grass, Attribute.Fire, Attribute.Water),
        new Attributes(Attribute.Normal, Attribute.Fight, Attribute.Ghost),
        new Attributes(Attribute.Fight, Attribute.Normal, Attribute.Ghost),
        new Attributes(Attribute.Ghost, Attribute.Fire, Attribute.Fight),
        new Attributes(Attribute.Dragon, Attribute.Dragon, Attribute.Dragon),
    };

    // Return if attributes are weak to others
    public static bool isWeakTo(Attribute type, Attribute checker)
    {
        return AttributeList[(int)type].isWeakAgainst(checker);
    }

    // Return if attributes are good to others
    public static bool isGoodAgainst(Attribute type, Attribute checker)
    {
        return AttributeList[(int)type].isGoodAgainst(checker);
    }
}
