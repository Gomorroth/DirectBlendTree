# DirectBlendTree
DirectなBlendTreeを用いてレイヤーを圧縮したい人向けのヘルパー

制作物のAssemblyDefinitionに含まれるようにクローンすると多分いい感じです

## 使い方?

```cs

var blendTree = new DirectBlendTree();

var toggle = blendTree.AddToggle();
toggle.ParameterName = "anon";
toggle.ON = some_animation;

_ = blendTree.AddDirectBlendTree("Group").AddToggle("Toggle");

/* ~~~~ */

var layer = blendTree.ToAnimatorControllerLayer(buildContext.AssetContainer);

```
