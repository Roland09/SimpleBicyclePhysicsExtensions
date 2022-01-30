using UnityEngine;

namespace Rowlan.SimpleBicyclePhysicsExtensions
{
    public class CharacterCreator3GameBaseMapper : CharacterMapperBase
    {
        public CharacterCreator3GameBaseMapper(GameObject bikePrefab) : base(bikePrefab)
        {
        }

        public override void Apply()
        {
            // HipIK
            AddMultiParentConstraint("HipIK", "HipIKTarget", "pelvis");

            // ChestIK
            AddTwoBoneIkConstraint("ChestIK", "ChestIKTarget", "spine_01", "spine_02", "spine_03");

            // RightFootIK
            AddTwoBoneIkConstraint("RightFootIK", "RightFootIKTarget", "thigh_r", "calf_r", "foot_r");

            // LeftFootIK
            AddTwoBoneIkConstraint("LeftFootIK", "LeftFootIKTarget", "thigh_l", "calf_l", "foot_l");

            // LeftFootIdleIK
            AddTwoBoneIkConstraint("LeftFootIdleIK", "LeftFootIdleIKTarget", "thigh_l", "calf_l", "foot_l");

            // RightHandIK
            AddTwoBoneIkConstraint("RightHandIK", "RightHandIKTarget", "upperarm_r", "lowerarm_r", "hand_r");

            // LeftHandIK
            AddTwoBoneIkConstraint("LeftHandIK", "LeftHandIKTarget", "upperarm_l", "lowerarm_l", "hand_l");

            // HeadIK
            AddMultiAimConstraint("HeadIK", "HeadIKTarget", "head");

        }

    }
}