using UnityEngine;

public class CallBy : MonoBehaviour
{
    void Start()
    {
        print("=============== 원본 ===============");
        string a = "앞";
        string b = "뒤";
        print($"{a}, {b}");


        Swap(a, b); // 값에 의한 호출이기에 결과는 그대로 [앞, 뒤]
        print($"{a}, {b}");

        Swap(ref a, ref b); // 참조에 의한 호출이기에 결과가 바뀜 [뒤, 앞]
        print($"{a}, {b}");
    }

    /// <summary> 값에 의한 호출 </summary>
    void Swap(string x, string y)
    {
        string temp = x;
        x = y;
        y = temp;
        print("========= Swap - Call By Value =========");
    }

    /// <summary> 참조에 의한 호출 </summary>
    void Swap(ref string x, ref string y)
    {
        string temp = x;
        x = y;
        y = temp;
        print("======== Swap - Call By Reference =======");
    }
}
