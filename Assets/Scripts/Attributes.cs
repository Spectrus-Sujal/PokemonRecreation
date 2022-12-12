using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes
{
    private AttributeDatabase.Attribute attribute;
    private AttributeDatabase.Attribute weakTo;
    private AttributeDatabase.Attribute goodAgainst;

    public Attributes(AttributeDatabase.Attribute attribute, AttributeDatabase.Attribute weakTo, AttributeDatabase.Attribute goodAgainst)
    {
        this.attribute = attribute;
        this.weakTo = weakTo;
        this.goodAgainst = goodAgainst;
    }

    public bool isWeakAgainst(AttributeDatabase.Attribute check)
    {
        return check == weakTo;
    }

    public bool isGoodAgainst(AttributeDatabase.Attribute check)
    {
        return check == goodAgainst;
    }

}
