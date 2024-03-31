using UnityEngine;
using UnityEngine.Playables;

public class EyeRotationBehaviour : PlayableBehaviour
{
    public Quaternion startRotation;
    public Quaternion endRotation;
    public Quaternion currentRotation;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {

        double duration = playable.GetDuration();
        double time = playable.GetTime();
        float progress = (float)(time / duration);

        currentRotation = Quaternion.Lerp(startRotation, endRotation, progress);

    }
}