using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using VRM;

public class TransformMixerBehaviour : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        var transform = playerData as Transform;
        if (!transform)
        {
            Debug.LogError("[TransformMixerBehaviour.ProcessFrame] Transform not found");
        }

        Vector3 blendedPosition = Vector3.zero;
        Quaternion blendedRotation = Quaternion.identity;
        float totalWeight = 0f;
        
        int inputCount = playable.GetInputCount();
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<TransformBehaviour> inputPlayable = (ScriptPlayable<TransformBehaviour>)playable.GetInput(i);
            TransformBehaviour input = inputPlayable.GetBehaviour();
            
            blendedPosition += input.currentPosition * inputWeight;
            if (inputWeight > 0f)
            {
                blendedRotation = Quaternion.Lerp(blendedRotation, input.currentRotation, inputWeight / (totalWeight + inputWeight));
            }
            totalWeight += inputWeight;
        }

        if (totalWeight > 0f)
        {
            transform.position = blendedPosition;
            transform.rotation = blendedRotation;
        }
    }
}
