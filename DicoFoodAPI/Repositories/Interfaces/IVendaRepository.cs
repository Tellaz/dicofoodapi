﻿using DicoFoodAPI.Models.ViewModels;
using System.Collections.Generic;

namespace DicoFoodAPI.Repositories.Interfaces
{
    public interface IVendaRepository
    {
        List<VendaViewModel> ListarVendas();
        VendaViewModel ListarVendasPorId(int id);
        VendaViewModel CriarVenda(VendaViewModel vendaViewModel);
        VendaViewModel AtualizarVenda(VendaViewModel vendaViewModel);
        void DeletarVenda(int id);
    }
}
