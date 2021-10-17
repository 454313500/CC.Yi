﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Interface;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Service
{
   public partial class MenuService:BaseService<menu>, IMenuService
    {
        public MenuService(DbContext Db) : base(Db) { }

        public async Task<menu> AddChildrenMenu(menu _menu, menu _children)
        {
            var menu_data = await _Db.Set<menu>().Include(u => u.children).Where(u => u.id == _menu.id).FirstOrDefaultAsync();
            _children.is_top = (short)Common.Enum.TopFlagEnum.Children;
            menu_data.children.Add(_children);
            await UpdateAsync(menu_data);
            return menu_data;
        }

        public async Task<bool> DelListByUpdateAsync(List<int> _ids)
        {
            var menuList = await GetEntitiesAsync(u=>_ids.Contains(u.id));
            menuList.ToList().ForEach(u => u.is_delete = (short)Common.Enum.DelFlagEnum.Deleted);
            return await UpdateListAsync(menuList);
        }

        public async Task<IEnumerable<menu>> GetAllEntitiesTrueAsync()
        {
            return await GetEntitiesAsync(u=> u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
        }

        public async Task<List<menu>> GetChildrenByMenu(menu _menu)
        {
            var menu_data = await GetEntity(u=>u.id==_menu.id&& u.is_delete == (short)Common.Enum.DelFlagEnum.Normal);
            var childrenList = menu_data.children.ToList();
            return childrenList;
        }

        public async Task<List<menu>> GetChildrenMenu(menu _menu)
        {
            var menu= await _Db.Set<menu>().Include(u => u.children).Include(u=>u.mould)
                .Where(u =>u.id==_menu.id&& u.is_delete == (short)Common.Enum.DelFlagEnum.Normal&& u.is_top == (short)Common.Enum.TopFlagEnum.Children )
                .FirstOrDefaultAsync();
            var childrenList = menu.children.ToList();
            return childrenList;
        }

        public async Task<menu> GetMenuMouldByMenu(menu _menu)
        {
            var menu_data = await _Db.Set<menu>().Include(u => u.children).Include(u=>u.mould).Where(u=>u.id==_menu.id).FirstOrDefaultAsync();
            return menu_data;
        }

        public async Task<mould> GetMouldByMenu(menu _menu)
        {
            var menu_data =await _Db.Set<menu>().Include(u => u.mould)
                .Where(u => u.id == _menu.id & u.is_delete == (short)Common.Enum.DelFlagEnum.Normal).FirstOrDefaultAsync();
            return menu_data.mould;
        }

        public async Task<List<menu>> GetTopMenu()
        {
            return await _Db.Set<menu>().Include(u => u.children)
               .Where(u => u.is_delete == (short)Common.Enum.DelFlagEnum.Normal && u.is_top == (short)Common.Enum.TopFlagEnum.Top)
               .ToListAsync();
        }

        public async Task<bool> SetMouldByMenu(int mouldId, int menuId)
        {
            var menu_data = await GetEntity(u => u.id == menuId);
            var mould_data = await _Db.Set<mould>().Where(u => u.id==mouldId).FirstOrDefaultAsync();
            menu_data.mould = mould_data;
            return await UpdateAsync(menu_data);
        }
        
    }
}
