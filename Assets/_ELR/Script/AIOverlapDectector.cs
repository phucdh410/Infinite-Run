using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AIOverlapDectector : MonoBehaviour
{
    [field: SerializeField]
    public bool PlayerDetected{ get; private set; }
    public Vector2 DirectionToTarget => _target.transform.position - _detectorOrigin.position;
    
    [Header("OverlapBox Parameter")]
    [SerializeField] private Transform _detectorOrigin;
    public Vector2 _detectorSize = Vector2.one;
    public Vector2 _detectorOffset = Vector2.zero;
    public float DetectionDelay = 0.3f;
    public LayerMask DetectorLayerMask;
    public int Speed;
    [Header("Gizmos Parameters")] 
    public Color IdleColor = Color.green;
    public Color DetectedColor = Color.red;
    public bool ShowGizmos = true;
    private float duration = 3f;
    
    [Header("Target")]
    private GameObject _target;

    public GameObject Target{
        get => _target;
        private set{
            _target = value;
            PlayerDetected = _target != null;
        }
    }

    private void Start(){
        StartCoroutine(DetectCoroutine());
    }

    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            _detectorOrigin.localScale.x *= (-1);
            duration = 3;
        }
    }

    private IEnumerator DetectCoroutine(){
        yield return new WaitForSeconds(DetectionDelay);
        DoDetect();
        StartCoroutine(DetectCoroutine());
    }

    private void DoDetect(){
        Collider2D collider2D = Physics2D.OverlapBox((Vector2) _detectorOrigin.position + _detectorOffset,
            _detectorSize, 0, DetectorLayerMask);
        Target = (collider2D != null) ? collider2D.gameObject : null;
    }

    private void OnDrawGizmos(){
        if (ShowGizmos && _detectorOrigin != null){
            Gizmos.color = IdleColor;
            if (PlayerDetected)
                Gizmos.color = DetectedColor;
            Gizmos.DrawCube((Vector2)_detectorOrigin.position + _detectorOffset, _detectorSize);
            
        }
    }

    private void FixedUpdate(){
        if (Target){
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
            transform.GetComponent<Animator>().Play("run");
            //Debug.Log(DirectionToTarget);
            //DirectionToTarget.normalized
        }
        else
        {
            transform.GetComponent<Animator>().Play("idle");
        }
    }
}
