﻿using UnityEditor.Animations;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace AnimatorAsCode.Pi.V0
{
    public interface IAacDefaultsProvider
    {
        void ConfigureState(AnimatorState state, AnimationClip emptyClip);
        void ConfigureTransition(AnimatorStateTransition transition);
        string ConvertLayerName(string systemName);
        string ConvertLayerNameWithSuffix(string systemName, string suffix);
        Vector2 Grid();
    }

    public class AacDefaultsProvider : IAacDefaultsProvider
    {
        private readonly bool _writeDefaults;

        public AacDefaultsProvider(bool writeDefaults = false)
        {
            _writeDefaults = writeDefaults;
        }

        public virtual void ConfigureState(AnimatorState state, AnimationClip emptyClip)
        {
            state.motion = emptyClip;
            state.writeDefaultValues = _writeDefaults;
        }

        public virtual void ConfigureTransition(AnimatorStateTransition transition)
        {
            transition.duration = 0;
            transition.hasExitTime = false;
            transition.exitTime = 0;
            transition.hasFixedDuration = true;
            transition.offset = 0;
            transition.interruptionSource = TransitionInterruptionSource.None;
            transition.orderedInterruption = true;
            transition.canTransitionToSelf = false;
        }

        public virtual string ConvertLayerName(string systemName)
        {
            return systemName;
        }

        public virtual string ConvertLayerNameWithSuffix(string systemName, string suffix)
        {
            return $"{systemName}__{suffix}";
        }

        public Vector2 Grid()
        {
            return new Vector2(250, 70);
        }
    }
}