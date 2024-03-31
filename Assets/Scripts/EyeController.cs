using UnityEngine;

public class EyeController : MonoBehaviour
{
    public Transform leftEye;
    public Transform rightEye;

    // X軸とY軸の回転量を設定するメソッド
    public void SetEyeRotation(Quaternion rotation)
    {
        // 左目と右目の回転を設定
        if (leftEye != null)
        {
            leftEye.localRotation = rotation;
        }
        if (rightEye != null)
        {
            rightEye.localRotation = rotation;
        }
    }
}