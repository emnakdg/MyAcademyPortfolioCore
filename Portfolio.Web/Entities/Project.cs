using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        [MinLength(5, ErrorMessage = "Proje adı en az 5 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Proje adı en fazla 50 karakter olmalıdır.")]
        [Required(ErrorMessage = "Proje adı gereklidir.")]
        public string ProjectName { get; set; }

        [MinLength(10, ErrorMessage = "Proje açıklaması en az 10 karakter olmalıdır.")]
        [MaxLength(500, ErrorMessage = "Proje açıklaması en fazla 500 karakter olmalıdır.")]
        [Required(ErrorMessage = "Proje açıklaması gereklidir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Proje Görsel Url gereklidir.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Proje Github Url gereklidir.")]
        [Url(ErrorMessage = "Lütfen geçerli bir URL girin.")]
        public string GithubUrl { get; set; }

        [Required(ErrorMessage = "Kategori gereklidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen geçerli bir kategori seçin.")]
        public int CategoryId { get; set; }

        //Navigation Properties
        public Category? Category { get; set; }
    }
}
