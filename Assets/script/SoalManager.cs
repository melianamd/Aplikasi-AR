using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoalManager : MonoBehaviour
{

    [System.Serializable]
    public class Soal
    {
        [TextArea]
        [Header("Soal")]
        public string soal;


        [Header("Pilihan untuk jawabah")]
        public Sprite pilA;
        public Sprite pilB, pilC, pilD;

        [Header("Kunci jawaban")]
        public bool A;
        public bool B, C, D;
    }

    public GameObject selesai;
    public int skor;
    public float waktu;
    private int nilaiAcak;
    Text textSoal, textWaktu;
    Image textA, textB, textC, textD;
    public List<Soal> KumpulanSoal;
    // Use this for initialization
    void Start()
    {
        textSoal = GameObject.Find("TextSoal").GetComponent<Text>();
        textA = GameObject.Find("A").GetComponent<Image>();
        textB = GameObject.Find("B").GetComponent<Image>();
        textC = GameObject.Find("C").GetComponent<Image>();
        textD = GameObject.Find("D").GetComponent<Image>();
        textWaktu = GameObject.Find("TextWaktu").GetComponent<Text>();

        nilaiAcak = Random.RandomRange(0, KumpulanSoal.Count);
    }

    // Update is called once per frame
    void Update()
    {

        textWaktu.text = "Time : " + waktu.ToString("0");
        waktu -= Time.deltaTime;

        if (waktu <= 0)
        {

            KumpulanSoal.RemoveAt(nilaiAcak);
            waktu = 5;
            nilaiAcak = Random.RandomRange(0, KumpulanSoal.Count);

        }

        if (KumpulanSoal.Count > 0)
        {

            textSoal.text = KumpulanSoal[nilaiAcak].soal;
            textA.sprite = KumpulanSoal[nilaiAcak].pilA;
            textB.sprite = KumpulanSoal[nilaiAcak].pilB;
            textC.sprite = KumpulanSoal[nilaiAcak].pilC;
            textD.sprite = KumpulanSoal[nilaiAcak].pilD;
        }
        else
        {
            // selesai.SetActive(true);
            textSoal.text = "Skor: " + skor;
            GameObject.Find("TextWaktu").SetActive(false);
            GameObject.Find("Panel").SetActive(false);
        }
    }

    public void CekJawaban(string jawaban)
    {
        if (KumpulanSoal[nilaiAcak].A == true && jawaban == "a")
        {
            skor++;
        }

        if (KumpulanSoal[nilaiAcak].B == true && jawaban == "b")
        {
            skor++;
        }

        if (KumpulanSoal[nilaiAcak].C == true && jawaban == "c")
        {
            skor++;
        }

        if (KumpulanSoal[nilaiAcak].D == true && jawaban == "d")
        {
            skor++;
        }

        KumpulanSoal.RemoveAt(nilaiAcak);
        nilaiAcak = Random.RandomRange(0, KumpulanSoal.Count);
        waktu = 5;
    }

    //public void ulang(){
    //Application.LoadedLevel(Application.loadedLevel);
    //}
}
