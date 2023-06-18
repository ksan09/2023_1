using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    public Slider _vfxS;
    public Slider _bgmS;
    public Slider _masterS;

    private void OnEnable()
    {
        SettingAudioUI();
    }

    private void SettingAudioUI()
    {
        _vfxS.value = AudioManager.Instance.GetVFXSound();
        _bgmS.value = AudioManager.Instance.GetBGMSound();
        _masterS.value = AudioManager.Instance.GetMasterSound();
    }

    public void VFX_Func()
    {
        AudioManager.Instance.SetVFXSound(_vfxS.value);
    }
    public void BGM_Func()
    {
        AudioManager.Instance.SetBGMSound(_bgmS.value);
    }
    public void Master_Func()
    {
        AudioManager.Instance.SetMasterSound(_masterS.value);
    }
}
