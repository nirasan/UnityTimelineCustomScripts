using DefaultNamespace;
using UnityEngine;
using UnityEngine.Playables;
using VRM;

public class BlendShapeBehaviour : PlayableBehaviour
{
    public int blendShapeIndex;
    public float startValue;
    public float endValue;
    public float currentValue;
    public ChangeType changeType;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        double duration = playable.GetDuration();
        double time = playable.GetTime();
        float progress = (float)(time / duration);

        // 変化の計算
        currentValue = CalculateValue(progress);
    }

    float CalculateValue(float progress)
    {
        switch (changeType)
        {
            case ChangeType.Linear:
                return Mathf.Lerp(startValue, endValue, progress);
            case ChangeType.EaseIn:
                return Mathf.Lerp(startValue, endValue, progress * progress);
            case ChangeType.EaseOut:
                return Mathf.Lerp(startValue, endValue, Mathf.Sin(progress * Mathf.PI * 0.5f));
            case ChangeType.PingPong:
                return Mathf.Lerp(startValue, endValue, Mathf.PingPong(progress * 2, 1));
            default:
                return startValue;
        }
    }
}