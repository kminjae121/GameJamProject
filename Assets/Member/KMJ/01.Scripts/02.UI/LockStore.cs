using Member.KMJ._01.Scripts;
using UnityEngine;

public class LockStore : MonoBehaviour
{
    [SerializeField] private CardSystem cardSystem;


    public void SetLockObject()
    {
        cardSystem._lockObj = null;
        if (cardSystem.gameObject == gameObject)
            cardSystem._lockObj = null;
        else
            cardSystem.LockObject(this.gameObject);
    }
}
