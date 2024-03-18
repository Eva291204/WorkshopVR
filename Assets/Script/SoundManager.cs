using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _soundInstance;
    public static SoundManager Instance
    {
        get
        {
            if (_soundInstance == null)
            {
                Debug.Log("ScoreManager is null");
            }
            return _soundInstance;
        }
    }
    public void Awake()
    {
        if (_soundInstance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _soundInstance = this;
        }
    }

    public AudioSource SoundGoodFood;
    public AudioSource SoundBadFood;
    public AudioSource SoundMakeTea;
    public AudioSource SoundCooktMeat;

    public void PlayGoodFoodSound()
    {
        SoundGoodFood.Play();
    }
    public void PlayBadFoodSound()
    {
        SoundBadFood.Play();
    }
    
    public void PlayMakeTeaEffectSound()
    {
        SoundMakeTea.Play();
    }
    public void PlayCooktMeatEffectSound()
    {
        SoundCooktMeat.Play();
    }
}
