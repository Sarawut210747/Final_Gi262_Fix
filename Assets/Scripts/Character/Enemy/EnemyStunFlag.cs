using UnityEngine;
using System.Collections;

public class EnemyStunFlag : MonoBehaviour
{
    public bool isStunned = false;

    public void ApplyStun(float duration)
    {
        StartCoroutine(StunStatus(duration));
    }

    IEnumerator StunStatus(float d)
    {
        isStunned = true;
        yield return new WaitForSeconds(d);
        isStunned = false;
    }
}
