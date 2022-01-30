using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Rowlan.SimpleBicyclePhysicsExtensions
{
    public abstract class CharacterIkMapper
    {
        GameObject bikePrefab;
        GameObject character;
        GameObject bikeRig;

        public CharacterIkMapper(GameObject bikePrefab)
        {
            this.bikePrefab = bikePrefab;

            this.character = bikePrefab.transform.GetComponentInChildren<ProceduralIKHandler>().gameObject;
            this.bikeRig = bikePrefab.transform.GetComponentInChildren<Rig>().gameObject;
        }

        public abstract void Apply(GameObject bikePrefab);

        protected void AddMultiParentConstraint(string ikName, string constrainedObjectName, string sourceObjectName)
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

        protected void AddTwoBoneIkConstraint(string ikName, string rootName, string midName, string tipName, string targetName)
        {
            Transform ChestIK = FindChild(bikeRig, ikName);

            TwoBoneIKConstraint tbc = ChestIK.GetComponent<TwoBoneIKConstraint>();

            tbc.data.root = FindChild(character, rootName);
            tbc.data.mid = FindChild(character, midName);
            tbc.data.tip = FindChild(character, tipName);

            tbc.data.target = FindChild(bikePrefab, targetName);
        }

        protected void AddMultiAimConstraint(string ikName, string constrainedObjectName, string sourceObjectName)
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
                if (child.transform.name == name)
                    return child;
            }

            return null;
        }
    }
}