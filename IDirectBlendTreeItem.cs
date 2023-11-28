using UnityEditor.Animations;

namespace gomoru.su
{
    internal interface IDirectBlendTreeItem
    {
        void Apply(BlendTree destination);
    }
}
