using DefaultNamespace;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using VRM;

[CreateAssetMenu(fileName = "BlendShapePlayableAsset", menuName = "Timeline/BlendShapePlayableAsset")]
public class BlendShapePlayableAsset : PlayableAsset, ITimelineClipAsset
{
    public BlendShapeName blendShapeName;
    public float startValue;
    public float endValue;
    public ChangeType changeType = ChangeType.Linear;
    
    public ClipCaps clipCaps => ClipCaps.Blending;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<BlendShapeBehaviour>.Create(graph);
        var behaviour = playable.GetBehaviour();

        // パラメータをBehaviourに渡す
        behaviour.blendShapeIndex = (int)blendShapeName;
        behaviour.startValue = startValue;
        behaviour.endValue = endValue;
        behaviour.changeType = changeType;

        return playable;
    }
}