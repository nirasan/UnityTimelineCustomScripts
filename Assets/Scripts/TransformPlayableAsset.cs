using DefaultNamespace;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using VRM;

[CreateAssetMenu(fileName = "TransformPlayableAsset", menuName = "Timeline/TransformPlayableAsset")]
public class TransformPlayableAsset : PlayableAsset, ITimelineClipAsset
{
    public Vector3 startPosition;
    public Quaternion startRotation;
    public Vector3 endPosition;
    public Quaternion endRotation;
    public double finalStateLeadTime;
    public ChangeType changeType = ChangeType.Linear;
    
    public ClipCaps clipCaps => ClipCaps.Blending;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TransformBehaviour>.Create(graph);
        var behaviour = playable.GetBehaviour();

        // パラメータをBehaviourに渡す
        behaviour.startPosition = startPosition;
        behaviour.startRotation = startRotation;
        behaviour.endPosition = endPosition;
        behaviour.endRotation = endRotation;
        behaviour.finalStateLeadTime = finalStateLeadTime;
        behaviour.changeType = changeType;

        return playable;
    }
}