﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Model.DbInit
{
    public class DataSeed
    {
        public async static Task SeedAsync(DbContext _Db)
        {
            if (!_Db.Set<user>().Any())
            {
                await _Db.Set<user>().AddAsync(new user
                {
                    username = "admin",
                    password = "123",
                    roles = new List<role>()
                    {
                        new role()
                        { 
                            menus = new List<menu>()
                            {
                                new menu() { mould=new mould()}
                            }
                        }
                    }
                });
            }
            await _Db.SaveChangesAsync();

            Console.WriteLine(nameof(DbContext) + ":数据库初始成功！");
        }
    }
}
