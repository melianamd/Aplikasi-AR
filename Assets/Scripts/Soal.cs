// Filename : Soal.cs

using UnityEngine;

public enum Jawaban { Kosong, A, B, C, D}

[CreateAssetMenu(fileName = "Soal", menuName ="Pilihan Ganda/Soal")]
public class Soal : ScriptableObject
{
	public string soalPertanyaan;
	public Sprite gambarPertanyaan;
	public Jawaban jawabanBenar;
	public PilihanJawaban[] pilihanJawaban;
}
