using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

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

        private ObjectField bikePrefabField;

        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;

            // Instantiate UXML
            VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
            root.Add(labelFromUXML);

            this.bikePrefabField = root.Q<ObjectField>("BikePrefabField");

            Button mapMixamoButton = root.Q<Button>("MapMixamoButton");
            mapMixamoButton.clicked += MapMixamo;

            Button mapCC3Button = root.Q<Button>("MapCC3Button");
            mapCC3Button.clicked += MapCharacterCreator3;

            Button mapCC3GameBaseButton = root.Q<Button>("MapCC3GameBaseButton");
            mapCC3GameBaseButton.clicked += MapCharacterCreator3GameBase;

        }

        private void MapCharacterCreator3()
        {
            GameObject bikePrefabRoot = this.bikePrefabField.value as GameObject;

            CharacterCreator3Mapper mapper = new CharacterCreator3Mapper( bikePrefabRoot);

            if( !mapper.ConsistencyCheck( out string error))
            {
                EditorUtility.DisplayDialog("Error", error, "Ok");
                return;
            }

            mapper.Apply();
        }

        private void MapCharacterCreator3GameBase()
        {
            GameObject bikePrefabRoot = this.bikePrefabField.value as GameObject;

            CharacterCreator3GameBaseMapper mapper = new CharacterCreator3GameBaseMapper(bikePrefabRoot);

            if (!mapper.ConsistencyCheck(out string error))
            {
                EditorUtility.DisplayDialog("Error", error, "Ok");
                return;
            }

            mapper.Apply();
        }

        private void MapMixamo()
        {
            GameObject bikePrefabRoot = this.bikePrefabField.value as GameObject;

            MixamoMapper mapper = new MixamoMapper(bikePrefabRoot);

            if (!mapper.ConsistencyCheck(out string error))
            {
                EditorUtility.DisplayDialog("Error", error, "Ok");
                return;
            }

            mapper.Apply();
        }

    }
}