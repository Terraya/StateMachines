using TDSGamer.FiniteStateMachine;
using UnityEngine;

[RequireComponent(typeof(FiniteStateMachine))]
public class EntityController : MonoBehaviour, IAction
{
    private FiniteStateMachine _stateMachine;

    private void Start() => _stateMachine = GetComponent<FiniteStateMachine>();
    
    public void Idle() => _stateMachine.StartAction(this);

    public bool CanCancel() => true;

    public void Cancel() => print("Cancel Idle");
}