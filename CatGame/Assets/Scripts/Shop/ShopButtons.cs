using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButtons : MonoBehaviour
{
    public GameObject CloseShop;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;

    public int price1 = 1;
    public int price2 = 2;
    public int price3 = 3;

    //void Start()
    //{
    //    // Sprawdź, czy przedmioty były kupione wcześniej
    //    if (PlayerPrefs.GetInt("Bought_Object1", 0) == 1)
    //        UnlockObject(Object1);
    //    if (PlayerPrefs.GetInt("Bought_Object2", 0) == 1)
    //        UnlockObject(Object2);
    //    if (PlayerPrefs.GetInt("Bought_Object3", 0) == 1)
    //        UnlockObject(Object3);
    //}

    public void CloseShopButton()
    {
        SceneManager.LoadScene(0); // wróć do menu gry
    }

    public void BuyObject1()
    {
        if (TryPurchase(price1, "Bought_Object1"))
            UnlockObject(Object1);
    }

    public void BuyObject2()
    {
        if (TryPurchase(price2, "Bought_Object2"))
            UnlockObject(Object2);
    }

    public void BuyObject3()
    {
        if (TryPurchase(price3, "Bought_Object3"))
            UnlockObject(Object3);
    }

    private bool TryPurchase(int cost, string key)
    {
        if (PlayerPrefs.GetInt(key, 0) == 1)
        {
            Debug.Log("✅ Przedmiot już został kupiony.");
            return false;
        }

        if (ScoreManager.SubtractPoints(cost))
        {
            PlayerPrefs.SetInt(key, 1);
            PlayerPrefs.Save();
            Debug.Log($"✅ Zakupiono przedmiot za {cost} punktów.");
            return true;
        }
        else
        {
            Debug.Log("❌ Za mało punktów na zakup.");
            return false;
        }
    }

    private void UnlockObject(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(true); // np. pokazuje obrazek, efekt, ikonę itp.
        }
    }
}
