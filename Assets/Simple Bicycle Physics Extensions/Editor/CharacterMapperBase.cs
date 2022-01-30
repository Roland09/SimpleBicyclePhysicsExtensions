using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Rowlan.SimpleBicyclePhysicsExtensions
{
    public abstract class CharacterMapperBase
    {
        GameObject bikePrefab;
        GameObject character;
        GameObject bikeRig;

        public CharacterMapperBase(GameObject bikePrefab)
        {
            this.bikePrefab = bikePrefab;

            if (bikePrefab != null)
            {
                this.character = bikePrefab.transform.GetComponentInChildren<ProceduralIKHandler>().gameObject;
                this.bikeRig = bikePrefab.transform.GetComponentInChildren<Rig>().gameObject;
            }
        }

        public abstract void Apply();

        protected void AddMultiParentConstraint(string ikName, string sourceObjectName, string constrainedObjectName)
        {
            Transform HipIK = FindChild(bikeRig, ikName);
            Transform CC_Base_Hip = FindChild(character, constrainedObjectName);
            Transform HipIKTarget = FindChild(bikePrefab, sourceObjectName);

            MultiParentConstraint mps = HipIK.GetComponent<MultiParentConstraint>();
            mps.data.constrainedObject = CC_Base_Hip;
            WeightedTransformArray wts = mps.data.sourceObjects;
            wts.Clear();
            wts.Add(new WeightedTransform(HipIKTarget, 1.0f));
            mps.data.sourceObjects = wts;

        }

        protected void AddTwoBoneIkConstraint(string ikName, string targetName, string rootName, string midName, string tipName)
        {
            Transform ChestIK = FindChild(bikeRig, ikName);

            TwoBoneIKConstraint tbc = ChestIK.GetComponent<TwoBoneIKConstraint>();

            tbc.data.root = FindChild(character, rootName);
            tbc.data.mid = FindChild(character, midName);
            tbc.data.tip = FindChild(character, tipName);

            tbc.data.target = FindChild(bikePrefab, targetName);
        }

        protected void AddMultiAimConstraint(string ikName, string sourceObjectName, string constrainedObjectName)
        {
            Transform HipIK = FindChild(bikeRig, ikName);
            Transform CC_Base_Hip = FindChild(character, constrainedObjectName);
            Transform HipIKTarget = FindChild(bikePrefab, sourceObjectName);

            MultiAimConstraint mps = HipIK.GetComponent<MultiAimConstraint>();
            mps.data.constrainedObject = CC_Base_Hip;
            WeightedTransformArray wts = mps.data.sourceObjects;
            wts.Clear();
            wts.Add(new WeightedTransform(HipIKTarget, 1.0f));
            mps.data.sourceObjects = wts;

        }

        protected Transform FindChild(GameObject parent, string name)
        {
            Transform[] children = parent.transform.GetComponentsInChildren<Transform>();

            foreach (Transform child in children)
            {
                if (StringUtils.Matches(child.transform.name, name))
                    return child;
            }

            return null;
        }

        public bool ConsistencyCheck( out string error)
        {
            if (bikePrefab == null)
            {
                error = "Please set the bike prefab root";
                return false;
            }

            BicycleController bicycleController = bikePrefab.GetComponent<BicycleController>();

            if (bicycleController == null)
            {
                error = "Bike prefab root must have a BicycleController";
                return false;
            }

            if (character == null)
            {
                error = "Bike prefab root must have a character set up with a ProceduralIKHandler";
                return false;
            }

            if (bikeRig == null)
            {
                error = "Bike prefab root must have be set up with a Rig";
                return false;
            }

            error = "";
            return true;
        }

    }
}