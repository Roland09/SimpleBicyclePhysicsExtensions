using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Rowlan.SimpleBicyclePhysicsExtensions
{
    public class CharacterCreator3Mapper
    {
        public void MapCharacterCreator3(GameObject bikePrefab)
        {
            GameObject cc3Model = bikePrefab.transform.GetComponentInChildren<ProceduralIKHandler>().gameObject;
            GameObject rig = bikePrefab.transform.GetComponentInChildren<Rig>().gameObject;

            // HipIK
            AddMultiParentConstraint(bikePrefab, cc3Model, rig, "HipIK", "CC_Base_Hip", "HipIKTarget");

            // ChestIK
            AddTwoBoneIkConstraint(bikePrefab, cc3Model, rig, "ChestIK", "CC_Base_Waist", "CC_Base_Spine01", "CC_Base_Spine02", "ChestIKTarget");

            // RightFootIK
            AddTwoBoneIkConstraint(bikePrefab, cc3Model, rig, "RightFootIK", "CC_Base_R_Thigh", "CC_Base_R_Calf", "CC_Base_R_Foot", "RightFootIKTarget");

            // LeftFootIK
            AddTwoBoneIkConstraint(bikePrefab, cc3Model, rig, "LeftFootIK", "CC_Base_L_Thigh", "CC_Base_L_Calf", "CC_Base_L_Foot", "LeftFootIKTarget");

            // LeftFootIdleIK
            AddTwoBoneIkConstraint(bikePrefab, cc3Model, rig, "LeftFootIdleIK", "CC_Base_L_Thigh", "CC_Base_L_Calf", "CC_Base_L_Foot", "LeftFootIdleIKTarget");

            // RightHandIK
            AddTwoBoneIkConstraint(bikePrefab, cc3Model, rig, "RightHandIK", "CC_Base_R_Upperarm", "CC_Base_R_Forearm", "CC_Base_R_Hand", "RightHandIKTarget");

            // LeftHandIK
            AddTwoBoneIkConstraint(bikePrefab, cc3Model, rig, "LeftHandIK", "CC_Base_L_Upperarm", "CC_Base_L_Forearm", "CC_Base_L_Hand", "LeftHandIKTarget");

            // HeadIK
            AddMultiAimConstraint(bikePrefab, cc3Model, rig, "HeadIK", "CC_Base_Head", "HeadIKTarget");


            Debug.Log("Bike rig mapping performed");
        }

        private void AddMultiParentConstraint(GameObject bikePrefab, GameObject cc3Model, GameObject rig, string ikName, string constrainedObjectName, string sourceObjectName)
        {
            Transform HipIK = FindChild(rig, ikName);
            Transform CC_Base_Hip = FindChild(cc3Model, constrainedObjectName);
            Transform HipIKTarget = FindChild(bikePrefab, sourceObjectName);

            MultiParentConstraint mps = HipIK.GetComponent<MultiParentConstraint>();
            mps.data.constrainedObject = CC_Base_Hip;
            WeightedTransformArray wts = mps.data.sourceObjects;
            wts.Clear();
            wts.Add(new WeightedTransform(HipIKTarget, 1.0f));
            mps.data.sourceObjects = wts;

        }

        private void AddTwoBoneIkConstraint(GameObject bikePrefab, GameObject cc3Model, GameObject rig, string ikName, string rootName, string midName, string tipName, string targetName)
        {
            Transform ChestIK = FindChild(rig, ikName);

            TwoBoneIKConstraint tbc = ChestIK.GetComponent<TwoBoneIKConstraint>();

            tbc.data.root = FindChild(cc3Model, rootName);
            tbc.data.mid = FindChild(cc3Model, midName);
            tbc.data.tip = FindChild(cc3Model, tipName);

            tbc.data.target = FindChild(bikePrefab, targetName);
        }

        private void AddMultiAimConstraint(GameObject bikePrefab, GameObject cc3Model, GameObject rig, string ikName, string constrainedObjectName, string sourceObjectName)
        {
            Transform HipIK = FindChild(rig, ikName);
            Transform CC_Base_Hip = FindChild(cc3Model, constrainedObjectName);
            Transform HipIKTarget = FindChild(bikePrefab, sourceObjectName);

            MultiAimConstraint mps = HipIK.GetComponent<MultiAimConstraint>();
            mps.data.constrainedObject = CC_Base_Hip;
            WeightedTransformArray wts = mps.data.sourceObjects;
            wts.Clear();
            wts.Add(new WeightedTransform(HipIKTarget, 1.0f));
            mps.data.sourceObjects = wts;

        }

        private Transform FindChild(GameObject parent, string name)
        {
            Transform[] children = parent.transform.GetComponentsInChildren<Transform>();

            foreach (Transform child in children)
            {
                if (child.transform.name == name)
                    return child;
            }

            return null;
        }
    }
}