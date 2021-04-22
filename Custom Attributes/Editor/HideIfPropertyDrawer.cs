using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(HideIfAttribute))]
public class HideIfPropertyDrawer : PropertyDrawer
{
    #region Overrides

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        HideIfAttribute hideIf = (HideIfAttribute)attribute;
        bool enabled = GetAttributeResult(hideIf, property);

        bool wasEnabled = GUI.enabled;
        GUI.enabled = enabled;
        if (!hideIf.hideInInspector || enabled)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }

        GUI.enabled = wasEnabled;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        HideIfAttribute hideIf = (HideIfAttribute)attribute;
        bool enabled = GetAttributeResult(hideIf, property);

        if (!hideIf.hideInInspector || enabled)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }
        else
        {
            return -EditorGUIUtility.standardVerticalSpacing;
        }
    }

    #endregion

    #region Methods

    private bool GetAttributeResult(HideIfAttribute hideIf, SerializedProperty property)
    {
        bool show = true;
        string propertyPath = property.propertyPath.Replace(property.name, hideIf.source);

        SerializedProperty sourceProperty = property.serializedObject.FindProperty(propertyPath);

		if (hideIf.hideType == HideType.Bool)
		{
            if (sourceProperty != null)
            {
                show = sourceProperty.boolValue;
            }
        }
        else if (hideIf.hideType == HideType.Compare)
		{
            string conditionPath = property.propertyPath.Replace(property.name, hideIf.condition);

            SerializedProperty conditionProperty = property.serializedObject.FindProperty(conditionPath);

            show = sourceProperty.Equals(conditionProperty);
		}
		else
		{
            string temp = sourceProperty.ToString();
            show = temp == hideIf.condition;
        }

        return show;
    }

    #endregion
}
