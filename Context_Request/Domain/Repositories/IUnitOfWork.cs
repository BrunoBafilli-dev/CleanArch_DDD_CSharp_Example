﻿using Domain.Request.Repositories.Request;

namespace Domain.Request.Repositories
{
    public interface IUnitOfWork
    {
        public IRequestRepository RequestRepository { get; }

        Task CommitAsync();
    }
}