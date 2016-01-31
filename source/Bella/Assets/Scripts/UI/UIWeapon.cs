using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIWeapon : MonoBehaviour
{
    public Player UIplayerTracker;
    //public Weapon UIweaponTracker;
    public Sprite uiBackground;
    public Sprite uiKnifeSprite;
    public Sprite uiSwordSprite;
    public Sprite uiPistolSprite;
    public Sprite uiRifleSprite;
    public Image uiBullet1;
    public Image uiBullet2;
    public Image uiBullet3;
    // Use this for initialization
    void Start()
    {
        uiBullet1.CrossFadeAlpha((float)0, (float)0, false);
        uiBullet2.CrossFadeAlpha((float)0, (float)0, false);
        uiBullet3.CrossFadeAlpha((float)0, (float)0, false);
    }
    // Update is called once per frame
    void Update()
    {
        switch (UIplayerTracker.equippedWeapon)
        {
            case Player.weapons.None:
                uiBullet1.CrossFadeAlpha((float)0, (float)0, false);
                uiBullet2.CrossFadeAlpha((float)0, (float)0, false);
                uiBullet3.CrossFadeAlpha((float)0, (float)0, false);
                GetComponent<Image>().sprite = uiBackground;
                break;
            case Player.weapons.Knife:
                GetComponent<Image>().sprite = uiKnifeSprite;
                break;
            case Player.weapons.Sword:
                GetComponent<Image>().sprite = uiSwordSprite;
                break;
            case Player.weapons.Pistol:
                SetBulletAlpha(UIplayerTracker.currentWeapon.numShots);
                GetComponent<Image>().sprite = uiPistolSprite;
                break;
            case Player.weapons.Rifle:
                SetBulletAlpha(UIplayerTracker.currentWeapon.numShots);
                GetComponent<Image>().sprite = uiRifleSprite;
                break;
        }

    }
    void SetBulletAlpha(int numShots)
    {
        switch (numShots)
        {
            case 3:
                uiBullet1.CrossFadeAlpha((float)1, (float).5, false);
                uiBullet2.CrossFadeAlpha((float)1, (float).5, false);
                uiBullet3.CrossFadeAlpha((float)1, (float).5, false);
                break;
            case 2:
                uiBullet1.CrossFadeAlpha((float)1, (float).5, false);
                uiBullet2.CrossFadeAlpha((float)1, (float).5, false);
                uiBullet3.CrossFadeAlpha((float)0, (float).5, false);
                break;
            case 1:
                uiBullet1.CrossFadeAlpha((float)1, (float).5, false);
                uiBullet2.CrossFadeAlpha((float)0, (float).5, false);
                uiBullet3.CrossFadeAlpha((float)0, (float).5, false);
                break;
            //case 0:
            //    uiBullet1.CrossFadeAlpha((float)0, (float)0, false);
            //    uiBullet2.CrossFadeAlpha((float)0, (float)0, false);
            //    uiBullet3.CrossFadeAlpha((float)0, (float)0, false);
            //    break;


        }
    }
}
