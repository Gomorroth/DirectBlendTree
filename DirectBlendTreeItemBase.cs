using UnityEditor.Animations;
using Object = UnityEngine.Object;

namespace gomoru.su
{
    internal abstract class DirectBlendTreeItemBase : IDirectBlendTreeItem
    {
        public string Name { get; set; }
        protected Object AssetContainer { get; }

        protected DirectBlendTreeItemBase(Object assetContainer)
        {
            AssetContainer = assetContainer;
        }

        void IDirectBlendTreeItem.Apply(BlendTree destination)
        {
            Apply(destination);
        }

        protected abstract void Apply(BlendTree destination);
    }
}
