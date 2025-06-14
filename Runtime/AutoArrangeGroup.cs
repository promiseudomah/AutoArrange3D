using UnityEngine;
using System.Collections.Generic;

namespace AAG
{
    [ExecuteAlways]
    public class AutoArrangeGroup : MonoBehaviour
    {
        public enum LayoutAxis { X, Y, Z }

        public enum ChildAlignment
        {
            Start,
            Center,
            End
        }

        public LayoutAxis layoutAxis = LayoutAxis.X;
        public ChildAlignment alignment = ChildAlignment.Start;

        public float spacing = 1f;
        public Vector3 padding = Vector3.zero;
        public bool autoUpdate = true;

        private void OnValidate()
        {
            if (autoUpdate)
                RebuildLayout();
        }

    #if UNITY_EDITOR
        private void OnTransformChildrenChanged()
        {
            if (!Application.isPlaying && autoUpdate)
                RebuildLayout();
        }
    #endif

        [ContextMenu("Rebuild Layout")]
        public void RebuildLayout()
        {    
            // Filter active children only
            var activeChildren = new List<Transform>();
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                    activeChildren.Add(child);
            }
            
            int childCount = activeChildren.Count;
            if (childCount == 0) return;

            Vector3 axis = layoutAxis switch
            {
                LayoutAxis.X => Vector3.right,
                LayoutAxis.Y => Vector3.up,
                LayoutAxis.Z => Vector3.forward,
                _ => Vector3.right
            };

            float totalLength = spacing * (childCount - 1);
            Vector3 startOffset = layoutAxis switch
            {
                LayoutAxis.X => new Vector3(GetStartOffset(totalLength), padding.y, padding.z),
                LayoutAxis.Y => new Vector3(padding.x, GetStartOffset(totalLength), padding.z),
                LayoutAxis.Z => new Vector3(padding.x, padding.y, GetStartOffset(totalLength)),
                _ => padding
            };

            for (int i = 0; i < childCount; i++)
            {
                activeChildren[i].localPosition = startOffset + axis * spacing * i;
            }
        }

        private float GetStartOffset(float totalLength)
        {
            return alignment switch
            {
                ChildAlignment.Center => -totalLength / 2f,
                ChildAlignment.End => -totalLength,
                _ => 0f // Start
            };
        }
    }
}
