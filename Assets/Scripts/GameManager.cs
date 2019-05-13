// Filename : GameManager.cs

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Singleton;

	public GameObject gambarPertanyaan;
	public GameObject[] pilihanJawabanButton;
	public GameObject nextButton, previousButton;
	public GameObject kolomJawaban;
	public Text teksPertanyaan;
	public Text sisaWaktuMengerjakan;
	public PaketSoal paketSoal;
	public Jawaban[] jawabanUser;
	public int waktuMenitMengerjakan = 120;
	public int nomorSoalDitampilkan = 0;

	private Jawaban jawabanBenar;
	private int jumlahSoal;
	private int waktuDetik = 0;

	private void Awake()
	{
		Singleton = this;
		DontDestroyOnLoad(this);
	}

	// Filename : GameManager.cs
	private void Start()
	{
		jumlahSoal	= paketSoal.kumpulanSoal.Length;
		jawabanUser = new Jawaban[jumlahSoal];

		for (int i = 0; i < jawabanUser.Length; i++)
		{
			jawabanUser[i] = Jawaban.Kosong;
		}

		SetSoal();
		InvokeRepeating("KurangiWaktuMengerjakan", 2, 1);
	}

	// Filename : GameManager.cs
	public void SetSoal(int gantiKe = 0)
	{
		// menunjuk isi array kumpulan soal indeks ke N
		// batasi biar tidak muncul exception Index Out Of Range
		if (nomorSoalDitampilkan + gantiKe == jumlahSoal) nomorSoalDitampilkan = 0;
		else if (nomorSoalDitampilkan + gantiKe == -1) nomorSoalDitampilkan = jumlahSoal-1;
		else nomorSoalDitampilkan += gantiKe;

		// tampilkan soal
		Soal soal			= paketSoal.kumpulanSoal[nomorSoalDitampilkan];
		teksPertanyaan.text = soal.soalPertanyaan;
		Sprite gambarSoal	= soal.gambarPertanyaan;

		// apakah soal memiliki gambar?
		if (gambarSoal == null) gambarPertanyaan.SetActive(false);
		else
		{
			gambarPertanyaan.GetComponent<Image>().sprite = gambarSoal;
			gambarPertanyaan.SetActive(true);
		}

		// set pilihan jawaban yang ditampilkan
		PilihanJawaban[] pilihanJawaban = soal.pilihanJawaban;

		for (int i = 0; i < pilihanJawabanButton.Length; i++)
		{
			GameObject teksPilihanJawaban	= pilihanJawabanButton[i].transform.Find("TeksJawaban").gameObject;
			GameObject gambarPilihanJawaban = pilihanJawabanButton[i].transform.Find("GambarJawaban").gameObject;
			Button button					= pilihanJawabanButton[i].GetComponentInChildren<Button>();
			button.image.color				= Color.white;

			// apakah ada teks yang perlu ditampilkan?
			if (pilihanJawaban[i].teks != "")
			{				
				teksPilihanJawaban.GetComponent<Text>().text = pilihanJawaban[i].teks;
				teksPilihanJawaban.SetActive(true);
			}
			else teksPilihanJawaban.SetActive(false);

			// apakah ada gambar yang perlu ditampilkan?
			if (pilihanJawaban[i].gambar)
			{
				gambarPilihanJawaban.GetComponent<Image>().sprite = pilihanJawaban[i].gambar;
				gambarPilihanJawaban.SetActive(true);
			}
			else gambarPilihanJawaban.SetActive(false);


			// apakah pemain sudah pernah menjawab soal ini sebelumnya?
			// jika iya, perlihatkan ia menjawab pilihan yang mana (A / B / C / D)
			if (jawabanUser[nomorSoalDitampilkan] != Jawaban.Kosong && (int)jawabanUser[nomorSoalDitampilkan] == i + 1)
			{
				Color selectedAnswerColor = new Color(255, 0, 237);
				pilihanJawabanButton[i].GetComponentInChildren<Button>().image.color = selectedAnswerColor;
			}
		}
	}

	// Filename : GameManager.cs
	private void KurangiWaktuMengerjakan()
	{
		waktuDetik++;
		if(waktuDetik%60 == 0)
		{
			waktuDetik = 0;
			waktuMenitMengerjakan--;
			sisaWaktuMengerjakan.text = "Sisa waktu : " + waktuMenitMengerjakan + " menit";
		}

		if (waktuMenitMengerjakan == 0)
			WaktuHabis();
	}

	// Filename : GameManager.cs
	public void SetJawaban(int jawaban)
	{
		jawabanUser[nomorSoalDitampilkan] = (Jawaban)jawaban;
		SetSoal(1);
	}

	// Filename : GameManager.cs
	public void WaktuHabis()
	{
		SceneManager.LoadScene("NilaiJawaban");
	}
}
