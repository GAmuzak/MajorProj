using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EnumIInteractableDict))]
public class CustomSfieldDictPropertyDrawers : SerializableDictionaryPropertyDrawer {}
