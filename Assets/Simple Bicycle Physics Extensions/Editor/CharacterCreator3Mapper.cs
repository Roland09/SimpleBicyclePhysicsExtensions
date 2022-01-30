using UnityEngine;

namespace Rowlan.SimpleBicyclePhysicsExtensions
{
    public class CharacterCreator3Mapper : CharacterIkMapper
    {
        public CharacterCreator3Mapper(GameObject bikePrefab) : base(bikePrefab)
        {
        }

        public override void Apply(GameObject bikePrefab)
        {
            // HipIK
            AddMultiParentConstraint("HipIK", "CC_Base_Hip", "HipIKTarget");

            // ChestIK
            AddTwoBoneIkConstraint("ChestIK", "CC_Base_Waist", "CC_Base_Spine01", "CC_Base_Spine02", "ChestIKTarget");

            // RightFootIK
            AddTwoBoneIkConstraint("RightFootIK", "CC_Base_R_Thigh", "CC_Base_R_Calf", "CC_Base_R_Foot", "RightFootIKTarget");

            // LeftFootIK
            AddTwoBoneIkConstraint("LeftFootIK", "CC_Base_L_Thigh", "CC_Base_L_Calf", "CC_Base_L_Foot", "LeftFootIKTarget");

            // LeftFootIdleIK
            AddTwoBoneIkConstraint("LeftFootIdleIK", "CC_Base_L_Thigh", "CC_Base_L_Calf", "CC_Base_L_Foot", "LeftFootIdleIKTarget");

            // RightHandIK
            AddTwoBoneIkConstraint("RightHandIK", "CC_Base_R_Upperarm", "CC_Base_R_Forearm", "CC_Base_R_Hand", "RightHandIKTarget");

            // LeftHandIK
            AddTwoBoneIkConstraint("LeftHandIK", "CC_Base_L_Upperarm", "CC_Base_L_Forearm", "CC_Base_L_Hand", "LeftHandIKTarget");

            // HeadIK
            AddMultiAimConstraint("HeadIK", "CC_Base_Head", "HeadIKTarget");

            Debug.Log("Bike rig mapping performed");
        }

    }
}