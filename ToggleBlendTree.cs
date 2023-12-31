﻿using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

namespace gomoru.su
{
    internal sealed class ToggleBlendTree : DirectBlendTreeItemBase
    {
        public string ParameterName { get; set; }

        public Motion ON { get; set; }
        public Motion OFF { get; set; }

        protected override void Apply(BlendTree destination, Object assetContainer)
        {
            var blendTree = new BlendTree();
            AssetDatabase.AddObjectToAsset(blendTree, assetContainer);
            blendTree.blendParameter = ParameterName;
            blendTree.name = Name;
            blendTree.AddChild(OFF, 0);
            blendTree.AddChild(ON, 1);

            destination.AddChild(blendTree);
        }
    }
}
