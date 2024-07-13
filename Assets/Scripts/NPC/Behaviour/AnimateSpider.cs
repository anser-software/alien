using System.Collections;
using System.Collections.Generic;
using FIMSpace;
using UnityEngine;
using FIMSpace.Basics;
using FIMSpace.GroundFitter;
using UnityEngine.AI;

public class AnimateSpider : MonoBehaviour
{

    public Vector4 MovementRandomPointRange = new Vector4(25, -25, 25, -25);
    public float speed = 1f;

    [SerializeField] private float _animSpeed;
    [SerializeField] private float _updatePosInterval;
    
    private Transform bodyTransform;
    private float bodyRotateSpeed = 5f;

    private Animator animator;
    private FGroundFitter fitter;
    private float timer;
    private Vector3 targetDirection;
    private bool onDestination;

    private FAnimationClips clips;

    void Start()
    {
        fitter = GetComponent<FGroundFitter>();
        animator = GetComponentInChildren<Animator>();
        timer = _updatePosInterval;

        if (name.Contains("Fpider"))
            bodyTransform = transform.GetChild(0).Find("BSkeleton").GetChild(0).Find("Body_Shield");

        transform.rotation = Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f);
        fitter.UpAxisRotation = transform.rotation.eulerAngles.y;

        onDestination = true;

        //transform.localScale = Vector3.one * Random.Range(0.5f, 1f);

        clips = new FAnimationClips(animator);
        clips.AddClip("Idle");
        clips.AddClip("Move");

        animator.speed = _animSpeed;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f) ChooseNewDestination();
        
        if (onDestination)
        {
            bodyRotateSpeed = Mathf.Lerp(bodyRotateSpeed, 50f, Time.deltaTime * 2f);
        }
        else
        {
            if (fitter.LastRaycast.transform) transform.position = fitter.LastRaycast.point;

            transform.position += transform.forward * speed * Time.deltaTime;

            if (targetDirection.magnitude < 0.1f)
            {
                ReachDestination();
                return;
            }

            Quaternion targetRot = Quaternion.LookRotation(targetDirection);
            fitter.UpAxisRotation =
                Mathf.LerpAngle(fitter.UpAxisRotation, targetRot.eulerAngles.y, Time.deltaTime * 7f);

            bodyRotateSpeed = Mathf.Lerp(bodyRotateSpeed, -250f, Time.deltaTime * 3f);
        }

        if (bodyTransform) bodyTransform.Rotate(0f, 0f, Time.deltaTime * bodyRotateSpeed);
    }

    public void SetTargetDirection(Vector3 direction)
    {
        targetDirection = direction;
    }
    
    private void ChooseNewDestination()
    {
        timer = _updatePosInterval;

        //targetPoint = Player.Instance.transform.position;

        if(onDestination)
            animator.CrossFadeInFixedTime(clips["Move"], 0.25f);

        onDestination = false;
    }

    private void ReachDestination()
    {
        timer = _updatePosInterval;
        onDestination = true;
        animator.CrossFadeInFixedTime(clips["Idle"], 0.15f);
    }
    
}
