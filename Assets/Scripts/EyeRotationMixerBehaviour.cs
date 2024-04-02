using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class EyeRotationMixerBehaviour : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        FacialController facialController = playerData as FacialController;
        if (!facialController)
        {
            Debug.LogError("[EyeRotationMixerBehaviour.ProcessFrame] FacialController not found");
        }

        int inputCount = playable.GetInputCount();

        Quaternion blendedRotation = Quaternion.identity;
        float totalWeight = 0f;

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<EyeRotationBehaviour> inputPlayable = (ScriptPlayable<EyeRotationBehaviour>)playable.GetInput(i);
            EyeRotationBehaviour input = inputPlayable.GetBehaviour();

            // ここで公開フィールドから回転を取得
            Quaternion inputRotation = input.currentRotation;
            blendedRotation = Quaternion.Slerp(blendedRotation, inputRotation, inputWeight);
            totalWeight += inputWeight;
        }

        if (totalWeight > 0f)
        {
            facialController.SetEyeRotationWithSlerp(blendedRotation, totalWeight);
        }
    }
}
