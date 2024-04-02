using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FacialController : MonoBehaviour
{
    public Transform leftEye;
    public Transform rightEye;

    public SkinnedMeshRenderer skinnedMeshRenderer;

    private void SetEyes()
    {
        if (leftEye == null)
        {
            var go = FindGameObjectInChildren(transform, "J_Adj_L_FaceEye");
            if (go != null)
            {
                leftEye = go.transform;
            }
        }
        if (rightEye == null)
        {
            var go = FindGameObjectInChildren(transform, "J_Adj_R_FaceEye");
            if (go != null)
            {
                rightEye = go.transform;
            }
        }
    }
    
    private void SetSkinnedMeshRenderer()
    {
        if (skinnedMeshRenderer == null)
        {
            var go = FindGameObjectInChildren(transform, "Face");
            if (go != null)
            {
                skinnedMeshRenderer = go.GetComponent<SkinnedMeshRenderer>();
            }
        }
    }

    // X軸とY軸の回転量を設定するメソッド
    public void SetEyeRotationWithSlerp(Quaternion rotation, float weight)
    {
        SetEyes();

        var r = Quaternion.Slerp(leftEye.localRotation, rotation, weight);
        
        // 左目と右目の回転を設定
        if (leftEye != null)
        {
            leftEye.localRotation = r;
        }
        if (rightEye != null)
        {
            rightEye.localRotation = r;
        }
    }

    // BlendShape の値を設定するメソッド
    public void SetBlendShapeValue(int index, float value)
    {
        SetSkinnedMeshRenderer();
        
        skinnedMeshRenderer.SetBlendShapeWeight(index, value);
    }

    // 再帰的にGameObjectを検索するヘルパーメソッド
    private GameObject FindGameObjectInChildren(Transform parent, string name)
    {
        Debug.Log($"start. target:{name}, curr:{parent.name}");
        
        if (parent.name == name)
        {
            Debug.Log("FOUND!");
            return parent.gameObject;
        }

        foreach (Transform child in parent)
        {
            var found = FindGameObjectInChildren(child, name);
            if (found != null) return found;
        }

        return null;
    }
}
