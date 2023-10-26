using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LG_CRUD_Restaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace LG_CRUD_Restaurant.Service
{
	public class FoodService
	{
        private readonly FoodContext _context;

        public FoodService(FoodContext context)
        {
            _context = context;
        }

        public async Task<List<Food>> GetAllFoods()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<Food> GetFoodById(int id)
        {
            return await _context.Foods.FindAsync(id);
        }

        public async Task AddFood(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFood(Food food)
        {
            _context.Entry(food).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFood(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food != null)
            {
                _context.Foods.Remove(food);
                await _context.SaveChangesAsync();
            }
        }

    }
}
