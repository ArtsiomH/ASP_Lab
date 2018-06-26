using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _60331_Glotov.DAL
{
    public class Book
    {
        [HiddenInput]
        public int BookId { get; set; } //id книги

        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название книги")]
        public string BookName { get; set; } //название книги

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; } //описание книги

        [Required]
        [Display(Name = "Категория")]
        public string CategoryName { get; set; } //название категории

        [Required]
        [Range(minimum: 10, maximum: 300)]
        [Display(Name = "Цена")]
        public int Price { get; set; } //цена

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; } //изображение

        [ScaffoldColumn(false)]
        public string MimeType { get; set; } //Mime - тип данных изобраения
    }
}
