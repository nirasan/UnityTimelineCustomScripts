using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[CreateAssetMenu(fileName = "EyeRotationPlayableAsset", menuName = "Timeline/EyeRotationPlayableAsset")]
public class EyeRotationPlayableAsset : PlayableAsset, ITimelineClipAsset
{
    public Vector3 startRotation;
    public Vector3 endRotation;

    public ClipCaps clipCaps => ClipCaps.Blending;
    
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<EyeRotationBehaviour>.Create(graph);
        var eyeRotationBehaviour = playable.GetBehaviour();
        
        eyeRotationBehaviour.startRotation = CalcRotation(startRotation);
        eyeRotationBehaviour.endRotation = CalcRotation(endRotation);
        return playable;
    }
    
    private Quaternion CalcRotation(Vector3 v)  
    {
        Quaternion rotationX = Quaternion.Euler(v.x, 0f, 0f);
        Quaternion rotationY = Quaternion.Euler(0f, v.y, 0f);
        Quaternion rotationZ = Quaternion.Euler(0f, 0f, v.z);
        return rotationX * rotationY * rotationZ;
    }
}