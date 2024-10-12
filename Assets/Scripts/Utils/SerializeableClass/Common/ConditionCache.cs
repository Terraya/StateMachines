using System.Collections.Generic;

public class ConditionCache
{
    private readonly static Dictionary<Actions, BaseMonoAction> _actionCache = new Dictionary<Actions, BaseMonoAction>()
    {
        {Actions.HelloAction, new HelloMonoAction()},
        {Actions.CustomAction, new CustomMonoAction()}
    };

    public static BaseMonoAction FindByAction(Actions action)
        => _actionCache[action];
}