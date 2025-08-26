using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlaceDebugTool
{
    [MenuItem("Tools/Create Stencil Debug")]
    static void PlacePrefab()
    {
        // Path to the prefab relative to the Assets folder
        string prefabPath = "Packages/com.monadoart.vrcstencildebug/Runtime/Stencil Debug Tools.prefab";
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab == null)
        {
            EditorUtility.DisplayDialog("Prefab Not Found", $"Could not find prefab at {prefabPath}", "OK");
            return;
        }

        // Place the prefab in the scene
        GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        Undo.RegisterCreatedObjectUndo(instance, "Place Stencil Debug Tools Prefab");
        Selection.activeGameObject = instance;
        EditorSceneManager.MarkSceneDirty(instance.scene);
    }
}
