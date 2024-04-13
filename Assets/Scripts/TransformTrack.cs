using UnityEngine.Timeline;
using UnityEngine;
using UnityEngine.Playables;
using VRM;

[TrackColor(0.855f, 0, 0.87f)]
[TrackClipType(typeof(TransformPlayableAsset))]
[TrackBindingType(typeof(Transform))]
public class TransformTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<TransformMixerBehaviour>.Create(graph, inputCount);
    }
}