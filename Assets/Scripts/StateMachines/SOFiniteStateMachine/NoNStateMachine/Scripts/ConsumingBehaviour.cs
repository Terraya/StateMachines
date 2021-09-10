using System.Collections;
using UnityEngine;

namespace TDSGamer.SOFiniteStateMachine
{
    [RequireComponent(typeof(EntityMover))]
    [RequireComponent(typeof(EntityStats))]
    public class ConsumingBehaviour : MonoBehaviour
    {
        [SerializeField] private FoodStand[] foodStands;

        private int nextFoodStandWaypoint;
        private int boxes = 10;

        private EntityMover entityMover;
        private EntityStats entityStats;

        private void Start()
        {
            entityMover = GetComponent<EntityMover>();
            entityStats = GetComponent<EntityStats>();

            StartCoroutine(ChargeBoxes());
        }

        public bool EnoughBoxes()
        {
            bool isEnough = boxes > 8;
            return isEnough;
        }

        public void ConsumeBehaviour()
        {
            entityMover.MoveToDestination(foodStands[nextFoodStandWaypoint].MoveToPosition, () =>
            {
                entityStats.Health += foodStands[nextFoodStandWaypoint].HealthRecover;
                nextFoodStandWaypoint = (nextFoodStandWaypoint + 1) % foodStands.Length;
            });
        }

        public void RefillBoxesBehaviour()
        {
            entityMover.MoveToDestination(foodStands[0].MoveToPosition, () =>
            {
                boxes += 2;
            });
        }

        private IEnumerator ChargeBoxes()
        {
            while (true)
            {
                yield return new WaitForSeconds(5f);
                boxes -= 1;
            }
        }
    }
}