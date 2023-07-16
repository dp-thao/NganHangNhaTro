using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.Views;
using Microsoft.EntityFrameworkCore;


namespace NganHangNhaTro.Repositories
{
    public class MotelRepository : IMotelRepository
    {
        private readonly dbContext _dbContext;

        public MotelRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}