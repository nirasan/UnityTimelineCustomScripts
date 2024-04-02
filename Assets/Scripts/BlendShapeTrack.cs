using UnityEngine.Timeline;
using UnityEngine;
using UnityEngine.Playables;
using VRM;

[TrackColor(0.855f, 0.8623f, 0.87f)]
[TrackClipType(typeof(BlendShapePlayableAsset))]
[TrackBindingType(typeof(FacialController))]
public class BlendShapeTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<BlendShapeMixerBehaviour>.Create(graph, inputCount);
    }
}