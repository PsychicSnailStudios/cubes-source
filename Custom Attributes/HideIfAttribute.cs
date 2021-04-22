using UnityEngine;
using System;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class HideIfAttribute : PropertyAttribute
{
    #region Fields

    public string source;
    public string condition;
    public bool boolCondition = true;

    public HideType hideType = HideType.Bool;

    public bool hideInInspector = false;

    #endregion

    #region Constructors

    public HideIfAttribute(string sourceField, bool boolCondition = true, bool hideInInspector = true)
    {
        source = sourceField;
        this.boolCondition = boolCondition;

        this.hideInInspector = hideInInspector;

        hideType = HideType.Bool;
    }

    public HideIfAttribute(string sourceField, string conditionField, bool useEnum = true, bool hideInInspector = true)
    {
        source = sourceField;
        condition = conditionField;

        this.hideInInspector = hideInInspector;

        if (useEnum)
        {
            hideType = HideType.Enum;
        }
        else
        {
            hideType = HideType.Compare;
        }
    }

    #endregion
}

public enum HideType
{
    Bool,
    Compare,
    Enum
}
