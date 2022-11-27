﻿using EntitiesLayer.Entities;
using System.Collections.Generic;
using DataAccessLayer.Repositories;
using System.Linq;

namespace BusinessLayer.Services
{
    public class UlogeServices
    {
        public List<Uloga> GetUloge()
        {
            using(var repo = new UlogeRepository())
            {
                return repo.GetAll().ToList();
            }
        }

    }
}
