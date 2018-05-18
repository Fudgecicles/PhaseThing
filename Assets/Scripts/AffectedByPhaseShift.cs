using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AffectedByPhaseShift : MonoBehaviour {

	struct State 
    {
        public int AgentId;
        public int LayerId;

        public State(int agentId, int layerId)
        {
            AgentId = agentId;
            LayerId = layerId;
        }
    }

    private Stack<State> _stateStack = new Stack<State>();
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        SetNewState(_agent == null ? 0 : _agent.agentTypeID, gameObject.layer);
    }

    public void SetNewState(int agentId, int layerId)
    {
     
        gameObject.layer = layerId;
        _stateStack.Push(new State(agentId, layerId));
        if (_agent)
        {
            _agent.agentTypeID = agentId;
            _agent.SetDestination(MouseController.PrevDest);
        }
    }

    public void PopState()
    {
        _stateStack.Pop();
        var top = _stateStack.Peek();
        gameObject.layer = top.LayerId;
        if (_agent)
        {
            _agent.agentTypeID = top.AgentId;
        }
    }

    IEnumerator PushCoroutine()
    {
        yield return new WaitForSeconds(.1f);
        _agent.SetDestination(_agent.destination);
    }
}
