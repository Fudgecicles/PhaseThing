using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(AgentIdAttribute))]
public class AgentIdAttributeEditor : PropertyDrawer{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        UnityEditor.AI.NavMeshComponentsGUIUtility.AgentTypePopup(position, property.name, property);

    }

}
