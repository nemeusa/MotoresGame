using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusLide : MonoBehaviour
{
    public int healthAmount = 25;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent)
        {

            if (other.transform.parent.TryGetComponent(out Player player))
            {
                player.Heal(healthAmount);

                Destroy(gameObject);
            }
        }
    }
}
