using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IAController)), CanEditMultipleObjects]
public class IAControllerEditor : Editor
{
    public SerializedProperty
        iaFieldOfView_Prop,

        animatorZombie_Prop,

        idle_Prop,
        walking_Prop,
        movement_Prop,
        running_Prop,
        interpolationTime_Prop,

        state_Prop,

        distanceMovement_Prop,
        velocityOfMovement_Prop;

    void OnEnable() 
    {
        //Setup the SerializedProperty

        //IA VALUES
        iaFieldOfView_Prop = serializedObject.FindProperty("iA_FieldOfView");
 
        //ANIMATOR
        animatorZombie_Prop = serializedObject.FindProperty("animatorZombie");
 
        //ANIMATOR VALUES
        idle_Prop = serializedObject.FindProperty("idleAnimationValue");
        walking_Prop = serializedObject.FindProperty("walkingAnimationValue");
        movement_Prop = serializedObject.FindProperty("movementAnimationValue");
        running_Prop = serializedObject.FindProperty("runningAnimationValue");
        interpolationTime_Prop = serializedObject.FindProperty("interpolationTime");

        //STATE
        state_Prop = serializedObject.FindProperty ("initialState");
        //WALKING VALUES
        distanceMovement_Prop = serializedObject.FindProperty("distanceMovement");
        velocityOfMovement_Prop = serializedObject.FindProperty("velocityOfMovement");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(animatorZombie_Prop, new GUIContent("Zombie Animator"));

        EditorGUILayout.PropertyField(iaFieldOfView_Prop);

        EditorGUILayout.PropertyField(idle_Prop);
        EditorGUILayout.PropertyField(walking_Prop);
        EditorGUILayout.PropertyField(movement_Prop);
        EditorGUILayout.PropertyField(running_Prop);
        EditorGUILayout.PropertyField(interpolationTime_Prop);

        EditorGUILayout.PropertyField( state_Prop );
        IAController.States st = (IAController.States)state_Prop.enumValueIndex;

        switch( st )
        {
            case IAController.States.idle:
                break;

            case IAController.States.walking:
                EditorGUILayout.PropertyField(distanceMovement_Prop);
                EditorGUILayout.PropertyField(velocityOfMovement_Prop);
                break;

            default:
                Debug.LogError(st.ToString() + " is not a initial state, please change it");
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
