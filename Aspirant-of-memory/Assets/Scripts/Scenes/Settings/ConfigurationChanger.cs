using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveSerial))]
public class ConfigurationChanger : MonoBehaviour
{
    [SerializeField] private ActiveLevelConfiguration activeLevelConfiguration;
    private SaveSerial saveSerial;

    private void OnEnable()
    {
        saveSerial = GetComponent<SaveSerial>();
        saveSerial.OnMaxOpenLevelChanged += activeLevelConfiguration.ChangeMaxOpenLevel;
    }

    private void OnDisable()
    {
        saveSerial.OnMaxOpenLevelChanged -= activeLevelConfiguration.ChangeMaxOpenLevel;
    }
}