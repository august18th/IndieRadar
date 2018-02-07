using System;
using System.ComponentModel.DataAnnotations;

namespace IndieRadar.Web.ViewModels
{
    public class GameViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Название игры должно содержать от 2 до 50 символов")]
        public String GameName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя разработчика должно содержать от 3 до 50 символов")]
        public String Developer { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "Описание должно содержать от 20 до 200 символов")]
        public String Description { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Версия не должна содержать больше 20 символов")]
        public String Version { get; set; }

        public Byte[] MainPhoto { get; set; }
        public Double? Rating { get; set; }

        [Required(ErrorMessage = "Пожалуйста укажите жанр игры (или несколько)")]
        public string[] GameGenres { get; set; }

        [Required(ErrorMessage = "Пожалуйста укажите платформу игры (или несколько)")]
        public string[] GamePlatforms { get; set; }
    }
}