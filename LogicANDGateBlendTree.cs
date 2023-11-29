using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

namespace gomoru.su
{
    internal sealed class LogicANDGateBlendTree : DirectBlendTreeItemBase
    {
        public Motion ON { get; set; }
        public Motion OFF { get; set; }

        public string[] Parameters { get; set; }

        protected override void Apply(BlendTree destination, Object assetContainer)
        {
            BlendTree root = new BlendTree();
            var blendTree = root;
            for(int i = 0; i < Parameters.Length; i++)
            {
                AssetDatabase.AddObjectToAsset(blendTree, assetContainer);
                blendTree.name = Parameters[i];
                blendTree.blendParameter = Parameters[i];
                blendTree.AddChild(OFF);
                if (i != Parameters.Length - 1)
                {
                    var blendTree2 = new BlendTree();
                    blendTree.AddChild(blendTree2);
                    blendTree = blendTree2;
                }
                else
                {
                    blendTree.AddChild(ON);
                }
            }
            
            destination.AddChild(root);
        }
    }
}
