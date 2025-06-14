using UnityEngine;

namespace AAG
{
    [DisallowMultipleComponent]
    public class ChildActivityNotifier : MonoBehaviour
    {
        private void OnEnable()
        {
            NotifyParent();
        }

        private void OnDisable()
        {
            NotifyParent();
        }

        private void NotifyParent()
        {
            if (transform.parent == null) return;

            var group = transform.parent.GetComponent<AutoArrangeGroup>();
            if (group != null && group.autoUpdate)
            {
                group.RebuildLayout();
            }
        }
    }
}
