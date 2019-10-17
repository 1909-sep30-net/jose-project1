using Microsoft.EntityFrameworkCore;
using Old_Record_Store.Library;
using Old_Record_Store_DataAccess.Entities;
using Old_Record_Store_DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Old_Record_Store.App
{
    class Dependencies{
        public static IRecordStoreRepository CreateRestaurantRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecordStoreContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);

            var dbContext = new RecordStoreContext(optionsBuilder.Options);

            return new RecordStoreRepository(dbContext);
        }
    }
}
