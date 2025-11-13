using UnityEngine;
namespace Lane
{
    public class DirectionLane : MonoBehaviour
    {
        [Tooltip("Направление движения для этой полосы")]
        [SerializeField]private LaneDirection direction;
        public enum LaneDirection
        {
            Forward,
            Backward,
            Right,
            Left
        }
        private Vector3 GetDirectionVector(LaneDirection dir)
        {
            switch (dir)
            {
                case LaneDirection.Forward: return Vector3.forward;
                case LaneDirection.Backward: return Vector3.back;
                case LaneDirection.Left: return Vector3.left;
                case LaneDirection.Right: return Vector3.right;
                default: return Vector3.forward;
            }
        }
        public Vector3 DirectionVector
        {
            get
            {
                return GetDirectionVector(direction);
            }
        }
        public Vector3 GetWorldDirection()
        {
            return transform.TransformDirection(DirectionVector);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            Vector3 worldDirection = GetWorldDirection();
            Vector3 end = transform.position + worldDirection * 2f;

            DrawArrow(end, worldDirection, 1.5f);
        }

        private void DrawArrow(Vector3 position, Vector3 direction, float size)
        {
            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 30, 0) * Vector3.back;
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, -30, 0) * Vector3.back;

            Gizmos.DrawRay(position, right * size);
            Gizmos.DrawRay(position, left * size);
        }
    }
}
