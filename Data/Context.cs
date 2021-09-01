﻿using CadstrarTarefasWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadstrarTarefasWebAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
