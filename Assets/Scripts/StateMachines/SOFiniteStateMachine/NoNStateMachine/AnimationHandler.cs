using UnityEngine;
using UnityEngine.AI;

namespace TDSGamer.SOFiniteStateMachine
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class AnimationHandler : MonoBehaviour
    {
        private Animator anim;
        private NavMeshAgent agent;

        private void Start()
        {
            anim = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = agent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("velocity", speed);
        }
    }
}