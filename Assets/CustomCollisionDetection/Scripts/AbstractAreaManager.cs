using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using navid021.CustomCollisionDetection.CustomAreaBound;

namespace navid021.CustomCollisionDetection
{
    public abstract class AbstractAreaManager : MonoBehaviour
    {
        [Header("Custom Bound Setting")]
        [SerializeField]
        protected Transform target = null;
        [SerializeField]
        private bool autoSetTargetPlayer = true;
        [SerializeField]
        protected bool useAutoCallBack = true;
        [SerializeField]
        private object defaultCallbackType = null;
        [SerializeField]
        protected Color color = Color.red;
        [SerializeField]
        private Vector3 boundScale = Vector3.one;
        [SerializeField]
        private Vector3 center = Vector3.zero;

        internal Vector3 pos {
            get {
                return transform.position + center;
            }
        }

        internal Vector3 size {
            get {
                return boundScale;
            }
        }

        internal Vector3 TargetPosition {
            get {
                if (target) {

                    return target.transform.position;
                }
                return Vector3.zero;
            }
        }

        internal Vector3 TargetSizeDelta {
            get {
                if (target) {
                    Collider col = target.GetComponent<Collider>();
                    Renderer rend = target.GetComponent<Renderer>();

                    if (col || rend) {
                        Vector3 extend = !col ? rend.bounds.extents : col.bounds.extents;
                        return extend;
                    }
                }
                return Vector3.one;
            }
        }

        internal Transform Target {
            get {
                return target;
            }
        }
        
        protected AreaBound bound;
        public event Action<object> eventAction;

        public void FindTargetPlayer()
        {
            var findTarget = GameObject.FindGameObjectWithTag("Player").transform;
            if (findTarget) {
                SetTarget(findTarget);
            } else {
                Debug.LogWarning("Target positions not find! Collision Detection not worked! Please setup target.");
                return;
            }
        }

        public virtual void SetTarget(Transform newTransform)
        {
            target = newTransform;
        }

        protected virtual void Start()
        {
            bound = new AreaBound(pos, boundScale);

            if (autoSetTargetPlayer && target == null) {
                FindTargetPlayer();
            }
        }

        private void Update()
        {
            if ((target == null || !target.gameObject.activeSelf)) {
                Debug.LogWarning("Target positions not find! Collision Detection not worked! Please setup target.");
                return;
            }

            if (bound.OverLaps(TargetPosition, TargetSizeDelta)) {
                OnOverlap(eventAction);

                if(useAutoCallBack) {
                    Action<object> action = eventAction;
                    if(action != null) {
                        action(defaultCallbackType);
                    }
                }
            }
        }

        protected abstract void OnOverlap(Action<object> action);

        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = color;
            Gizmos.DrawWireCube(pos, size);
        }
    }
}