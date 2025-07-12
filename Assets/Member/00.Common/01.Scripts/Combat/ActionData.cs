using UnityEngine;

public class ActionData : MonoBehaviour, IEntityComponent
{
    public Vector2 HitPoint { get; set; }
    public Vector2 HitNormal { get; set; }

    public Vector2 HitDir { get; set; }

    private Entity _entity;
    public void Initialize(Entity entity)
    {
        _entity = entity;
    }
}
