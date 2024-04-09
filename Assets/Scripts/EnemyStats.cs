using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    private int currentHp;
    private int CurrentHp
    {
        get { return currentHp; }
        set { 
            currentHp = value;
            if (currentHp < 0) currentHp = 0;
            hpImage.fillAmount = (float)currentHp / maxHp;
        }
    }

    [SerializeField] private int maxHp;

    [SerializeField] private Image hpImage;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHp = maxHp;
    }

    public void TakeDmg(int dmg)
    {
        CurrentHp -= dmg;
        if(CurrentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
