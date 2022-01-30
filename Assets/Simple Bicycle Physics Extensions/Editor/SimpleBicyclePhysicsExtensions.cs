using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace Rowlan.SimpleBicyclePhysicsExtensions
{
    /// <summary>
    /// Perform the mapping of a Character Creator 3 Character to the IK Rigs of Simple Bicycle Physics
    /// 
    /// Usage:
    /// 
    /// + drag the CC3 model on the bike root gameobject
    /// + select the model in the hierarchy, then click menu Cyclist Setup > Setup Selected
    /// + set x/z to 0/0 (don't change y)
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

            Button mapCC3Button = root.Q<Button>("MapCC3Button");
            mapCC3Button.clicked += MapCharacterCreator3;

            this.bikePrefabRootField = root.Q<ObjectField>("BikePrefabRootField");

        }

        private void MapCharacterCreator3()
        {
            GameObject bikePrefabRoot = this.bikePrefabRootField.value as GameObject;

            CharacterCreator3Mapper mapper = new CharacterCreator3Mapper( bikePrefabRoot);
            mapper.Apply(bikePrefabRoot);
        }
    }
}