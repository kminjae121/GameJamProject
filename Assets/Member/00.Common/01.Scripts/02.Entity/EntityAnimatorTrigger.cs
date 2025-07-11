using System;
using UnityEngine;

public class EntityAnimatorTrigger : MonoBehaviour, IEntityComponent
{
    private Entity _entity;

    public void Initialize(Entity entity)
    {
        _entity = entity;
    }
}
