using UnityEngine;

namespace Rowlan.SimpleBicyclePhysicsExtensions
{
    public class CharacterCreator3Mapper : CharacterMapperBase
    {
        public CharacterCreator3Mapper(GameObject bikePrefab) : base(bikePrefab)
        {
        }

        public override void Apply()
        {
            // HipIK
            AddMultiParentConstraint("HipIK", "HipIKTarget", "CC_Base_Hip");

            // ChestIK
            AddTwoBoneIkConstraint("ChestIK", "ChestIKTarget", "CC_Base_Waist", "CC_Base_Spine01", "CC_Base_Spine02");

            // RightFootIK
            AddTwoBoneIkConstraint("RightFootIK", "RightFootIKTarget", "CC_Base_R_Thigh", "CC_Base_R_Calf", "CC_Base_R_Foot");

            // LeftFootIK
            AddTwoBoneIkConstraint("LeftFootIK", "LeftFootIKTarget", "CC_Base_L_Thigh", "CC_Base_L_Calf", "CC_Base_L_Foot");

            // LeftFootIdleIK
            AddTwoBoneIkConstraint("LeftFootIdleIK", "LeftFootIdleIKTarget", "CC_Base_L_Thigh", "CC_Base_L_Calf", "CC_Base_L_Foot");

            // RightHandIK
            AddTwoBoneIkConstraint("RightHandIK", "RightHandIKTarget", "CC_Base_R_Upperarm", "CC_Base_R_Forearm", "CC_Base_R_Hand");

            // LeftHandIK
            AddTwoBoneIkConstraint("LeftHandIK", "LeftHandIKTarget", "CC_Base_L_Upperarm", "CC_Base_L_Forearm", "CC_Base_L_Hand");

            // HeadIK
            AddMultiAimConstraint("HeadIK", "HeadIKTarget", "CC_Base_Head");

        }

    }
}