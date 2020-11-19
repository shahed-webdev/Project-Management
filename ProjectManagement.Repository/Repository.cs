﻿using AutoMapper;
using ProjectManagement.Data;

namespace ProjectManagement.Repository
{
    public class Repository
    {
        protected readonly ApplicationDbContext Db;
        protected readonly IMapper _mapper;

        public Repository(ApplicationDbContext db, IMapper mapper)
        {
            Db = db;
            _mapper = mapper;
        }
    }
}