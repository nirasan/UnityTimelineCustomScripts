using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.Editor
{
    [CustomEditor(typeof(TransformPlayableAsset))]
    public class TransformPlayableAssetEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI(); // 既存のフィールドを描画

            TransformPlayableAsset asset = target as TransformPlayableAsset;

            if (GUILayout.Button("Copy Scene View Camera Transform To StartTransform"))
            {
                SceneView sceneView = SceneView.lastActiveSceneView;
                if (sceneView != null && sceneView.camera != null)
                {
                    Undo.RecordObject(asset, "Copy Scene View Camera Transform");
                    asset.startPosition = sceneView.camera.transform.position;
                    asset.startRotation = sceneView.camera.transform.rotation;
                    EditorUtility.SetDirty(asset);
                }
                else
                {
                    Debug.LogWarning("No active Scene View or camera found!");
                }
            }
            
            if (GUILayout.Button("Copy Scene View Camera Transform To EndTransform"))
            {
                SceneView sceneView = SceneView.lastActiveSceneView;
                if (sceneView != null && sceneView.camera != null)
                {
                    Undo.RecordObject(asset, "Copy Scene View Camera Transform");
                    asset.endPosition = sceneView.camera.transform.position;
                    asset.endRotation = sceneView.camera.transform.rotation;
                    EditorUtility.SetDirty(asset);
                }
                else
                {
                    Debug.LogWarning("No active Scene View or camera found!");
                }
            }
        }
    }
}