using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

namespace gomoru.su
{
    internal sealed class LogicORGateBlendTree : DirectBlendTreeItemBase
    {
        public Motion ON { get; set; }
        public Motion OFF { get; set; }

        public string[] Parameters { get; set; }

        public LogicORGateBlendTree(Object assetContainer) : base(assetContainer)
        {
        }


        protected override void Apply(BlendTree destination)
        {
            var blendTree = new BlendTree();
            blendTree.AddChild(OFF);
            blendTree.AddChild(ON);
            blendTree.blendParameter = Parameters[Parameters.Length - 1];
            AssetDatabase.AddObjectToAsset(blendTree, AssetContainer);

            for (int i = Parameters.Length - 2; i >= 0; i--)
            {
                var tree = new BlendTree();
                AssetDatabase.AddObjectToAsset(tree, AssetContainer);
                tree.AddChild(blendTree, 0);
                tree.AddChild(ON, 1);
                tree.blendParameter = Parameters[i];

                blendTree = tree;
            }

            blendTree.name = Name;
            destination.AddChild(blendTree);
        }
    }
}
