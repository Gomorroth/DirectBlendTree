namespace gomoru.su
{
    internal static class DirectBlendTreeExtensions
    {
        private static T AddTo<T>(this T tree, DirectBlendTree blendTree) where T : IDirectBlendTreeItem
        {
            blendTree.Add(tree);
            return tree;
        }


        public static DirectBlendTree AddDirectBlendTree(this DirectBlendTree directBlendTree, string name = null) => new DirectBlendTree(directBlendTree.ParameterName) { Name = name }.AddTo(directBlendTree);

        public static ToggleBlendTree AddToggle(this DirectBlendTree directBlendTree, string name = null) => new ToggleBlendTree() { Name = name }.AddTo(directBlendTree);

        public static RadialPuppetBlendTree AddRadialPuppet(this DirectBlendTree directBlendTree, string name = null) => new RadialPuppetBlendTree() { Name = name }.AddTo(directBlendTree);

        public static LogicORGateBlendTree AddOrGate(this DirectBlendTree directBlendTree, string name = null) => new LogicORGateBlendTree() { Name = name }.AddTo(directBlendTree);

        public static LogicANDGateBlendTree AddAndGate(this DirectBlendTree directBlendTree, string name = null) => new LogicANDGateBlendTree() { Name = name }.AddTo(directBlendTree);

    }
}
