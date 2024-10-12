using UnityEngine;

public class ConditionMonoHandler : MonoBehaviour
{
    public Actions CurrentAction;

    [SerializeReference] 
    public BaseMonoAction a = new CustomMonoAction();

    private void Start()
    {
        a.Action();
    }
}