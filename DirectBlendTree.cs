using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using Object = UnityEngine.Object;

namespace gomoru.su
{
    internal sealed partial class DirectBlendTree : IDirectBlendTreeItem
    {
        private List<IDirectBlendTreeItem> _items;
        public Object AssetContainer { get; }

        public string Name { get; set; }

        public string ParameterName { get; }

        public AnimatorControllerParameter DirectBlendParameter { get; }

        public DirectBlendTree(Object assetContainer, string parameterName = "1")
        {
            _items = new List<IDirectBlendTreeItem>();
            AssetContainer = assetContainer;
            ParameterName = parameterName;
        }

        public void Add(IDirectBlendTreeItem item) => _items.Add(item);

        public BlendTree ToBlendTree()
        {
            var blendTree = new BlendTree();
            blendTree.name = Name;
            AssetDatabase.AddObjectToAsset(blendTree, AssetContainer);
            blendTree.blendType = BlendTreeType.Direct;
            SetNormalizedBlendValues(blendTree, false);
            foreach (var item in _items)
            {
                item.Apply(blendTree);
            }

            var children = blendTree.children;
            for(int i = 0; i < children.Length; i++)
            {
                children[i].directBlendParameter = ParameterName;
            }
            blendTree.children = children;

            return blendTree;
        }

        public AnimatorControllerLayer ToAnimatorControllerLayer()
        {
            var layer = new AnimatorControllerLayer();
            layer.name = Name;
            var stateMachine = layer.stateMachine = new AnimatorStateMachine();
            AssetDatabase.AddObjectToAsset(stateMachine, AssetContainer);

            var state = stateMachine.AddState(Name ?? "Direct Blend Tree");
            state.motion = ToBlendTree();

            return layer;
        }

        void IDirectBlendTreeItem.Apply(BlendTree destination)
        {
            var blendTree = ToBlendTree();
            destination.AddChild(blendTree);
        }

        private static void SetNormalizedBlendValues(BlendTree blendTree, bool value)
        {
            using (var so = new SerializedObject(blendTree))
            {
                so.FindProperty("m_NormalizedBlendValues").boolValue = value;
                so.ApplyModifiedPropertiesWithoutUndo();
            }
        }
    }
}
