﻿using System.ComponentModel.DataAnnotations;

namespace DicoFoodAPI.Models.ViewModels
{
    public class VendaItensViewModel
    {
        public int Id { get; set; }
        public string CodigoVenda { get; set; }
        [Required]
        public int IdLanche { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
