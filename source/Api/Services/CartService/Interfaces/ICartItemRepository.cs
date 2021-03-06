﻿using CartService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Interfaces
{
    public interface ICartItemRepository
    {
        void Create(CartItem cartItem);
        void Update(CartItem cartItem);

        EntityState GetEntityState(CartItem item);
    }
}
