using UnityEngine.Timeline;
using UnityEngine;
using UnityEngine.Playables;

[TrackColor(0.855f, 0.8623f, 0.87f)]
[TrackClipType(typeof(EyeRotationPlayableAsset))]
[TrackBindingType(typeof(EyeController))]
public class EyeRotationTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<EyeRotationMixerBehaviour>.Create(graph, inputCount);
    }
}