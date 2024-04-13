using DefaultNamespace;
using UnityEngine;
using UnityEngine.Playables;
using VRM;

public class TransformBehaviour : PlayableBehaviour
{
    public Vector3 startPosition;
    public Quaternion startRotation;
    public Vector3 endPosition;
    public Quaternion endRotation;
    public Vector3 currentPosition;
    public Quaternion currentRotation;
    public double finalStateLeadTime;
    public ChangeType changeType;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        double duration = playable.GetDuration() - finalStateLeadTime; // クリップの最後に最終状態に移行するための予備の時間を設ける
        double time = playable.GetTime();
        float normalizedTime = (float)(time / duration);

        if (normalizedTime > 1)
        {
            normalizedTime = 1f;
        }

        // 遷移タイプに応じた時間の調整
        float progress = AdjustTimeByTransitionType(normalizedTime, changeType);

        // Lerpを使って位置と回転を補間
        currentPosition = Vector3.Lerp(startPosition, endPosition, progress);
        currentRotation = Quaternion.Lerp(startRotation, endRotation, progress);
    }

    private float AdjustTimeByTransitionType(float normalizedTime, ChangeType type)
    {
        switch (type)
        {
            case ChangeType.EaseIn:
                return EaseIn(normalizedTime);
            case ChangeType.EaseOut:
                return EaseOut(normalizedTime);
            case ChangeType.PingPong:
                return Mathf.PingPong(normalizedTime * 2, 1);
            case ChangeType.Immediate:
                return 1.0f;
            case ChangeType.Linear:
            default:
                return normalizedTime;
        }
    }

    private float EaseIn(float t)
    {
        return t * t;
    }

    private float EaseOut(float t)
    {
        return -(t * (t - 2));
    }
}