﻿using DicoFoodAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DicoFoodAPI.Models
{
    public class Lanche : BaseEntity
    {
        [Required]
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public int Categoria { get; set; }
        public string UrlCapa { get; set; }
        public string UrlImagem { get; set; }
    }
}
