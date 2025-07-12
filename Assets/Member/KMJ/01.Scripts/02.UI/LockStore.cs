using Member.KMJ._01.Scripts;
using UnityEngine;

public class LockStore : MonoBehaviour
{
    [SerializeField] private CardSystem cardSystem;


    public void SetLockObject()
    {
            cardSystem.LockObject(this.gameObject.transform.parent.gameObject);
    }
}
