// Filename : HitungJawabanPemain.cs

using UnityEngine;
using UnityEngine.UI;

public class HitungJawabanPemain : MonoBehaviour
{
	public Text nilaiPemainText;

	private int jawabanBenar;

	private void Start()
	{
		Soal[] kumpulanSoal = GameManager.Singleton.paketSoal.kumpulanSoal;
		for (int i = 0; i < kumpulanSoal.Length; i++)
		{
			if (kumpulanSoal[i].jawabanBenar == GameManager.Singleton.jawabanUser[i])
				jawabanBenar++;
		}

		nilaiPemainText.text = "Jawaban Benar : " + jawabanBenar;
	}
}
