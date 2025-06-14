using UnityEngine;

namespace AAG
{
    [ExecuteAlways]
    public class AutoArrangeGroup : MonoBehaviour
    {
        public enum LayoutAxis { X, Y, Z }
        public LayoutAxis layoutAxis = LayoutAxis.X;

        public float spacing = 1f;
        public Vector3 padding = Vector3.zero;
        public bool autoUpdate = true;

        private void OnValidate()
        {
            if (autoUpdate)
                RebuildLayout();
        }

        [ContextMenu("Rebuild Layout")]
        public void RebuildLayout()
        {
            Vector3 offset = padding;

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.localPosition = offset;

                switch (layoutAxis)
                {
                    case LayoutAxis.X:
                        offset += new Vector3(spacing, 0f, 0f);
                        break;
                    case LayoutAxis.Y:
                        offset += new Vector3(0f, spacing, 0f);
                        break;
                    case LayoutAxis.Z:
                        offset += new Vector3(0f, 0f, spacing);
                        break;
                }
            }
        }
    }
}