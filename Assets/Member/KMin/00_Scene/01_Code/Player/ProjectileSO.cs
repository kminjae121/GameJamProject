using UnityEngine;

namespace Code.Entities
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class ProjectileSO : ScriptableObject
    {
        public float attackDamage;
        public float speed;
    }
}