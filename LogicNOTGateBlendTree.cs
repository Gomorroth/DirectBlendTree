using UnityEngine;
using UnityEditor.Animations;
using UnityEditor;

namespace gomoru.su
{
    internal sealed class LogicNOTGateBlendTree : DirectBlendTreeItemBase
    {
        public IDirectBlendTreeItem Item { get; set; }
        public string ParameterName { get; set; }

        protected override void Apply(BlendTree destination, Object assetContainer)
        {
            var blendTree = new BlendTree();
            blendTree.blendParameter = ParameterName;
            AssetDatabase.AddObjectToAsset(blendTree, assetContainer);

            var directBlendTree = new BlendTree();
            directBlendTree.blendParameter = "1";
            AssetDatabase.AddObjectToAsset(directBlendTree, assetContainer);
            blendTree.blendType = BlendTreeType.Direct;
            SetNormalizedBlendValues(blendTree, false);
            blendTree.AddChild(null, 0);
            blendTree.AddChild(directBlendTree, 1);

            Item.Apply(directBlendTree, assetContainer);
        }
    }
}
