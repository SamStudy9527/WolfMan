using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestDeal : MonoBehaviour
{

    List<int> man = new List<int>();

    private void Start()
    {
        man.Add(1);
        man.Add(1);
        man.Add(1);
        man.Add(2);
        man.Add(2);
        man.Add(2);
        man.Add(3);
        man.Add(4);
        man.Add(5);


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int count = man.Count - 1;
            Debug.Log("输出总数：" + count);
            for (int i = 0; i < man.Count - 1; i++)
            {
                var number = Random.Range(0, count);
                var counts = man[number];
                man[number] = man[count];
                man[count] = counts;
                count--;
            }

            for (int j = 0; j < man.Count; j++)
            {
                Debug.Log("输出：" + man[j]);
            }
        }
    }

}