using Lean.Transition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectAnimationController : MonoBehaviour
{
    public LeanPlayer SpawnTransitions { get { if (spawntransitions == null) spawntransitions = new LeanPlayer(); return spawntransitions; } }
    [SerializeField][UnityEngine.Serialization.FormerlySerializedAs("Transitions")] private LeanPlayer spawntransitions;

    public LeanPlayer ExitTransitions { get { if (exittransitions == null) exittransitions = new LeanPlayer(); return exittransitions; } }
    [SerializeField][UnityEngine.Serialization.FormerlySerializedAs("Transitions")] private LeanPlayer exittransitions;

    [Header ("Events")]
    public UnityEvent onEnable;
    public UnityEvent onDisable;

    private void OnEnable()
    {
        BeginSpawnTransitions();
        if(onEnable != null) onEnable.Invoke();
    }

    private void OnDisable()
    {
        BeginExitTransitions();
        if (onDisable != null) onDisable.Invoke();
    }


    [ContextMenu("Begin Spawn Transitions")]
    public void BeginSpawnTransitions()
    {
        if (SpawnTransitions != null)
        {
            SpawnTransitions.Begin();
        }
    }

    [ContextMenu("Begin Spawn Transitions")]
    public void BeginExitTransitions()
    {
        if (ExitTransitions != null)
        {
            ExitTransitions.Begin();
        }
    }
}
