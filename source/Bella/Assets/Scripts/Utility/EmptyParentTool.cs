using UnityEngine;
using System.Collections;
using UnityEditor;

public class EmptyParentTool 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Adds a blank game object as a parent to our selection.
    /// Also resets our selection's position to zero.
    /// </summary>
    [MenuItem("GameObject/Create Empty Parent", false, 0)]
    static void CreateEmptyParent()
    {
        if(Selection.activeGameObject == null)
        {
            return;
        }
        Undo.IncrementCurrentGroup();
        int group = Undo.GetCurrentGroup();
        Undo.SetCurrentGroupName("Create Empty Parent");

        GameObject goNew = new GameObject(Selection.activeGameObject.name);

        Undo.RegisterCreatedObjectUndo(goNew, "Create " + goNew.name);
        goNew.transform.parent = Selection.activeGameObject.transform.parent;
        goNew.transform.position = Selection.activeGameObject.transform.position;

        // Match the hierarchy spot in the list
        goNew.transform.SetSiblingIndex(Selection.activeGameObject.transform.GetSiblingIndex());
        
        Undo.SetTransformParent(Selection.activeGameObject.transform, goNew.transform, "Parent obj");
        
        Selection.activeGameObject.transform.localPosition = Vector3.zero;
        
        Selection.activeGameObject = goNew;
        
        Undo.CollapseUndoOperations(group);
    }
}
