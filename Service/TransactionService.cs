using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LG_CRUD_Restaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace LG_CRUD_Restaurant.Service
{
	public class TransactionService
	{
        private readonly TransactionContext _context;

        public TransactionService(TransactionContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTransaction(Transaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }

    }
}
