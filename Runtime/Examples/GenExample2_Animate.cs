﻿#if UNITY_EDITOR
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using UnityEditor;
using UnityEditor.Animations;

namespace AnimatorAsCodeFramework.Pi.Examples
{
    public class GenExample2_Animate : MonoBehaviour
    {
        public VRCAvatarDescriptor avatar;
        public AnimatorController assetContainer;
        public string assetKey;
        public SkinnedMeshRenderer wedgeMesh;
    }

    [CustomEditor(typeof(GenExample2_Animate), true)]
    public class GenExample1_BlushEditor : Editor
    {
        private const string SystemName = "Example 2";

        public override void OnInspectorGUI()
        {
            AacExample.InspectorTemplate(this, serializedObject, "assetKey", Create, Remove);
        }

        private void Create()
        {
            var my = (GenExample2_Animate) target;
            var aac = AacExample.AnimatorAsCode(SystemName, my.avatar, my.assetContainer, my.assetKey);

            var fx = aac.CreateMainFxLayer();

            fx.NewState("Motion")
                .WithAnimation(aac.NewClip().Animating(clip =>
                {
                    clip.Animates(my.wedgeMesh, "blendShape.Wedge").WithFrameCountUnit(keyframes =>
                        keyframes.Easing(0, 100f).Easing(28, 0).Easing(29, 0).Easing(30, 0).Easing(31, 0).Easing(32, 0).Easing(60, 100f)
                    );
                    clip.Animates(my.wedgeMesh, "material._Metallic").WithFrameCountUnit(keyframes =>
                        keyframes.Constant(0, 1f).Constant(28, 0).Constant(60, 0)
                    );
                }))
                .MotionTime(fx.FloatParameter("WedgeAmount"));
        }

        private void Remove()
        {
            var my = (GenExample2_Animate) target;
            var aac = AacExample.AnimatorAsCode(SystemName, my.avatar, my.assetContainer, my.assetKey);

            aac.RemoveAllMainLayers();
        }
    }
}
#endif