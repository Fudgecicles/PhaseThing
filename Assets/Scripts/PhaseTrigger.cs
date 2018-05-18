using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseTrigger : MonoBehaviour {

    [AgentId]
    [SerializeField]
    private int _navAgent;
    [Layer]
    [SerializeField]
    private int _enterLayer;

    private void OnTriggerEnter(Collider other)
    {
        var shift = other.GetComponent<AffectedByPhaseShift>();
        if (shift)
        {
            shift.SetNewState(_navAgent, _enterLayer);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var shift = other.GetComponent<AffectedByPhaseShift>();
        if (shift)
        {
            shift.PopState();
        }
    }
}
