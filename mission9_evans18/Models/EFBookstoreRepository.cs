﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_evans18.Models
{
    public class EFBookstoreRepository: IBookstoreRepository
    {
        private BookstoreContext context { get; set; }
        public EFBookstoreRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Books> Books => context.Books;
    }
}
