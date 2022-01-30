using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.Animations.Rigging;

namespace Rowlan.SimpleBicyclePhysicsExtensions
{
    /// <summary>
    /// Perform the mapping of a Character Creator 3 or Mixamo Character to the IK Rigs of Simple Bicycle Physics
    /// 
    /// Usage:
    /// 
    /// + drag the character model on the bike root gameobject
    /// + select the model in the hierarchy, then click menu Cyclist Setup > Setup Selected
    /// + adjust the position, eg set x/z to 0/0; y depends on the character
    /// + perform mapping
    /// 
    /// </summary>
    public class SimpleBicyclePhysicsExtensions : EditorWindow
    {
        [SerializeField]
        private VisualTreeAsset m_VisualTreeAsset = default;

        [MenuItem("Window/Rowlan/Simple Bicycle Physics Extensions")]
        public static void ShowExample()
        {
            SimpleBicyclePhysicsExtensions wnd = GetWindow<SimpleBicyclePhysicsExtensions>();
            wnd.titleContent = new GUIContent("Simple Bicycle Physics Extensions");
        }

        private ObjectField bikePrefabRootField;

        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;

            // Instantiate UXML
            VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
            root.Add(labelFromUXML);

            this.bikePrefabRootField = root.Q<ObjectField>("BikePrefabRootField");

            Button mapCC3Button = root.Q<Button>("MapCC3Button");
            mapCC3Button.clicked += MapCharacterCreator3;

            Button mapMixamoButton = root.Q<Button>("MapMixamoButton");
            mapMixamoButton.clicked += MapMixamo;

        }

        private void MapCharacterCreator3()
        {
            if (!ConsistencyCheck())
                return;

            GameObject bikePrefabRoot = this.bikePrefabRootField.value as GameObject;

            CharacterCreator3Mapper mapper = new CharacterCreator3Mapper( bikePrefabRoot);
            mapper.Apply();
        }

        private void MapMixamo()
        {
            if (!ConsistencyCheck())
                return;

            GameObject bikePrefabRoot = this.bikePrefabRootField.value as GameObject;

            MixamoMapper mapper = new MixamoMapper(bikePrefabRoot);
            mapper.Apply();
        }

        private bool ConsistencyCheck()
        {
            GameObject bikePrefabRoot = this.bikePrefabRootField.value as GameObject;

            if (bikePrefabRoot == null)
            {
                EditorUtility.DisplayDialog("Error", "Please set the bike prefab root", "Ok");
                return false;
            }

            BicycleController bicycleController = bikePrefabRoot.GetComponent<BicycleController>();

            if (bicycleController == null)
            {
                EditorUtility.DisplayDialog("Error", "Bike prefab root must have a BicycleController", "Ok");
                return false;
            }

            GameObject character = bikePrefabRoot.transform.GetComponentInChildren<ProceduralIKHandler>().gameObject;

            if (character == null)
            {
                EditorUtility.DisplayDialog("Error", "Bike prefab root must have a character set up with a ProceduralIKHandler", "Ok");
                return false;
            }

            GameObject bikeRig = bikePrefabRoot.transform.GetComponentInChildren<Rig>().gameObject;

            if (bikeRig == null)
            {
                EditorUtility.DisplayDialog("Error", "Bike prefab root must have be set up with a Rig", "Ok");
                return false;
            }

            return true;
        }
    }
}