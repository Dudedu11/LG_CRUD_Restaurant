﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LG_CRUD_Restaurant.Models;
using LG_CRUD_Restaurant.Service;
using Microsoft.AspNetCore.Mvc;

namespace LG_CRUD_Restaurant.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transaction = await _transactionService.GetAllTransactions();
            return Ok(transaction);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transaction = await _transactionService.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(Transaction transaction)
        {
            await _transactionService.AddTransaction(transaction);
            return CreatedAtAction("GetTransaction", new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }
            await _transactionService.UpdateTransaction(transaction);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            await _transactionService.DeleteTransaction(id);
            return NoContent();
        }
    }
}