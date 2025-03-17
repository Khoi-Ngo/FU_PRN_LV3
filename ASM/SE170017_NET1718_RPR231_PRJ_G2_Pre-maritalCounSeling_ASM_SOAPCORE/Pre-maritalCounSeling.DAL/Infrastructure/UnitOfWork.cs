using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Pre_maritalCounSeling.DAL.Entities;
using Pre_maritalCounSeling.DAL.Repositories.QuizRepo;
using Pre_maritalCounSeling.DAL.Repositories.UserRepo;

namespace Pre_maritalCounSeling.DAL.Infrastructure
{
    public class UnitOfWork
    {
        private readonly NET1718_PRN231_PRJ_G2_PremaritalCounselingContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #region entities repositories

        public UserRepository UserRepository { get; }
        public QuestionOptionRepository QuestionOptionRepository { get; }
        public QuestionRepository QuestionRepository { get; }
        public QuizRepository QuizRepository { get; }
        public QuizResultRepository QuizResultRepository { get; }
        public RoleRepository RoleRepository { get; }

        public UnitOfWork(NET1718_PRN231_PRJ_G2_PremaritalCounselingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            UserRepository ??= new UserRepository(_context);
            QuestionOptionRepository ??= new QuestionOptionRepository(_context);
            QuestionRepository ??= new QuestionRepository(_context);
            QuizRepository ??= new QuizRepository(_context);
            QuizResultRepository ??= new QuizResultRepository(_context);
            RoleRepository ??= new RoleRepository(_context);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        #endregion


    }
}
