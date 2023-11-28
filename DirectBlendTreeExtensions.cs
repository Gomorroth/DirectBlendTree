namespace gomoru.su
{
    internal static class DirectBlendTreeExtensions
    {
        private static T AddTo<T>(this T tree, DirectBlendTree blendTree) where T : IDirectBlendTreeItem
        {
            blendTree.Add(tree);
            return tree;
        }

        public static ToggleBlendTree AddToggle(this DirectBlendTree directBlendTree, string name = null) => new ToggleBlendTree(directBlendTree.AssetContainer) { Name = name }.AddTo(directBlendTree);

        public static RadialPuppetBlendTree AddRadialPuppet(this DirectBlendTree directBlendTree, string name = null) => new RadialPuppetBlendTree(directBlendTree.AssetContainer) { Name = name }.AddTo(directBlendTree);

        public static LogicORGateBlendTree AddLogicORGate(this DirectBlendTree directBlendTree, string name = null) => new LogicORGateBlendTree(directBlendTree.AssetContainer) { Name = name }.AddTo(directBlendTree);

        public static LogicANDGateBlendTree AddLogicANDGate(this DirectBlendTree directBlendTree, string name = null) => new LogicANDGateBlendTree(directBlendTree.AssetContainer) { Name = name }.AddTo(directBlendTree);

        public static DirectBlendTree AddDirectBlendTree(this DirectBlendTree directBlendTree, string name = null) => new DirectBlendTree(directBlendTree.AssetContainer, directBlendTree.ParameterName) { Name = name }.AddTo(directBlendTree);
    }
}
