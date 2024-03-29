﻿using London_Api_corePractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace London_Api_corePractice
{
    public class HotelAPIDbContext : DbContext
    {
        public HotelAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RoomEntity> Rooms
        {
            get; set;
        }
    }
}
