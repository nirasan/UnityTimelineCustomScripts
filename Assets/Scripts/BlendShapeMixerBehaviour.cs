using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using VRM;

public class BlendShapeMixerBehaviour : PlayableBehaviour
{
    private Dictionary<int, float> _blendShapeValues = new Dictionary<int, float>();

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        var facialController = playerData as FacialController;
        if (!facialController)
        {
            Debug.LogError("[BlendShapeMixerBehaviour.ProcessFrame] FacialController not found");
        }
        
        _blendShapeValues.Clear();

        int inputCount = playable.GetInputCount();
        
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<BlendShapeBehaviour> inputPlayable = (ScriptPlayable<BlendShapeBehaviour>)playable.GetInput(i);
            BlendShapeBehaviour input = inputPlayable.GetBehaviour();
            
            _blendShapeValues[input.blendShapeIndex] = input.currentValue;
        }

        if (_blendShapeValues.Count > 0)
        {
            foreach (var (key, value) in _blendShapeValues)
            {
                facialController.SetBlendShapeValue(key, value);
            }
        }
    }
}
