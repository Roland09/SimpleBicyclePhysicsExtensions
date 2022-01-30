using UnityEngine;

namespace Rowlan.SimpleBicyclePhysicsExtensions
{
    public class MixamoMapper : CharacterMapperBase
    {
        public MixamoMapper(GameObject bikePrefab) : base(bikePrefab)
        {
        }

        public override void Apply()
        {
            // HipIK
            AddMultiParentConstraint("HipIK", "HipIKTarget", "*:Hips");

            // ChestIK
            AddTwoBoneIkConstraint("ChestIK", "ChestIKTarget", "*:Spine", "*:Spine1", "*:Spine2");

            // RightFootIK
            AddTwoBoneIkConstraint("RightFootIK", "RightFootIKTarget", "*:RightUpLeg", "*:RightLeg", "*:RightFoot");

            // LeftFootIK
            AddTwoBoneIkConstraint("LeftFootIK", "LeftFootIKTarget", "*:LeftUpLeg", "*:LeftLeg", "*:LeftFoot");

            // LeftFootIdleIK
            AddTwoBoneIkConstraint("LeftFootIdleIK", "LeftFootIdleIKTarget", "*:LeftUpLeg", "*:LeftLeg", "*:LeftFoot");

            // RightHandIK
            AddTwoBoneIkConstraint("RightHandIK", "RightHandIKTarget", "*:RightArm", "*:RightForeArm", "*:RightHand");

            // LeftHandIK
            AddTwoBoneIkConstraint("LeftHandIK", "LeftHandIKTarget", "*:LeftArm", "*:LeftForeArm", "*:LeftHand");

            // HeadIK
            AddMultiAimConstraint("HeadIK", "HeadIKTarget", "*:Head");

        }

    }
}