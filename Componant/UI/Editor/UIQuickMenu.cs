using UnityEditor;
using UnityEngine;

/// <summary>
/// Holds the methods that add custom ui components to the unity GameObject window
/// </summary>
public static class UIQuickMenu
{
    #region Objects

    [MenuItem("GameObject/UI/Modular UI/Button")]
    public static void AddModularButton()
    {
        GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("Modular UI/Button"));
        if (Selection.activeGameObject != null)
        {
            go.transform.SetParent(Selection.activeGameObject.transform, false);
        }
        go.name = "Button";
    }

    #endregion
}
