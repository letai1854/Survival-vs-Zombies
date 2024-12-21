using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolKunai : MonoBehaviour
{
    
    public int countKunai;
    [SerializeField] public Queue<Kunai> pool;
    public float speedSword;
    public GameObject kunai;
    private bool resetkunai=false;
    void Start()
    {
        pool = new Queue<Kunai>();

        AddKunai();
        //GetKunai();
    }

    public void GetKunai()
    {
        Kunai kunaiObject = pool.Dequeue();
        kunaiObject.transform.position = new Vector3(ManagerSkill.instance.player.transform.position.x, ManagerSkill.instance.player.transform.position.y, ManagerSkill.instance.player.transform.position.z);
        kunaiObject.gameObject.SetActive(true);
        if (ManagerSkill.instance.player.dashLeftRight == 0)
        {
            ManagerSkill.instance.player.dashLeftRight = 1;
        }
        kunaiObject.SetUpKunai(speedSword, ManagerSkill.instance.player.dashLeftRight);
        //StartCoroutine(SetKunai(kunaiObject, 4.0f));

    }

    public void AddKunai()
    {
        for (int i = 0; i < countKunai; i++)
        {
            GameObject newKunai = Instantiate(kunai);
            Kunai newKunaiSword = newKunai.GetComponent<Kunai>();
            pool.Enqueue(newKunaiSword);
        }
    }
    public bool CheckCountPool()
    {
        if (pool.Count == 0)
        {
            return false;
        }
        return true;
    }
    private IEnumerator SetKunai(Kunai kunaiObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        kunaiObject.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
