using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to create attributes which are the basis
/// for what type the Pokemon is and what it is
/// weak and strong against
/// </summary>
public class Attributes
{
    // Variables
    private AttributeDatabase.Attribute attribute;
    private AttributeDatabase.Attribute weakTo;
    private AttributeDatabase.Attribute goodAgainst;

    // Constructor
    public Attributes(AttributeDatabase.Attribute attribute, AttributeDatabase.Attribute weakTo, AttributeDatabase.Attribute goodAgainst)
    {
        this.attribute = attribute;
        this.weakTo = weakTo;
        this.goodAgainst = goodAgainst;
    }

    // Check relation between two attributes
    public bool isWeakAgainst(AttributeDatabase.Attribute check)
    {
        return check == weakTo;
    }

    public bool isGoodAgainst(AttributeDatabase.Attribute check)
    {
        return check == goodAgainst;
    }

}
