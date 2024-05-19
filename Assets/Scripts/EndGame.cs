using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
   [SerializeField] private Image _image;
   [SerializeField] private TextMeshProUGUI _time;
   [SerializeField] private Player _player;
   [SerializeField] private Timer _timer;
   private void Start()
   {
      _player.EndGame += ShowEndImage;
   }

   public void ShowEndImage()
   {
      _image.gameObject.SetActive(true);
      _time.text = $"Ваше врем : {_timer.Time.ToString()}";
   }
   
   public void RestartGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
