using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseController : MonoBehaviour {

    [Header("References")]
    [SerializeField]
    private Transform _phaseShiftSphere;
    [SerializeField]
    private NavMeshAgent _playerAgent;
    

    [Header("Values")]
    [SerializeField]
    private LayerMask _groundCastMask;
    [SerializeField]
    private LayerMask _clickCastMask;
    [SerializeField]
    private float _smoothDampTime;


    public static Vector3 PrevDest;


    private float _clickTime = -1;
    private float _sizeLerp = 0;
    private float _targetSize;
    private Vector3 _smoothDampVel;
    private Camera _cam;
    private Transform _draggingTransform;
    private Vector3 _dragTarget;

	// Use this for initialization
	void Start () {
        _cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButton(0) && _draggingTransform != null)
        {
            RaycastHit hit;
            if (GetMouseHit(out hit, _groundCastMask)) {
                _dragTarget = hit.point;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(GetMouseHit(out hit, _clickCastMask))
            {
                if(hit.collider.gameObject.tag == "Draggable")
                {
                    _draggingTransform = hit.transform;
                }
                else
                {
                    PrevDest = hit.point;
                    _playerAgent.SetDestination(PrevDest);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _draggingTransform = null;
        }
        if (_draggingTransform != null)
        {
            _draggingTransform.position = Vector3.SmoothDamp(_draggingTransform.position, _dragTarget, ref _smoothDampVel, _smoothDampTime, 100, Time.deltaTime);
        }
	}



    bool GetMouseHit(out RaycastHit hit, LayerMask mask)
    {
        bool result = Physics.Raycast(_cam.ScreenPointToRay((Vector3)Input.mousePosition), out hit, 100, mask, QueryTriggerInteraction.UseGlobal);
        return result;
    }
}
