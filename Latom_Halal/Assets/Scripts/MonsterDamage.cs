using UnityEngine;
using UnityEngine.UI;

public class MonsterDamage : MonoBehaviour
{
    public Slider PlrHpSlider;
    public Animator anim;
    public MonsterFollow follow;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (follow.distance.magnitude <= 1.5)
        {
            print("Damaged");
            Damage(1);
        }
    }

    void Damage(int damage)
    {
        PlrHpSlider.value -= damage;
    }
}
