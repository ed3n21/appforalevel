using AutoMapper;
using BL.ModelsBL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface ITransactionService : IGenericService<TransactionBL>
    {

    }

    public class TransactionService : GenericService<TransactionBL, Transaction>, ITransactionService
    {
        private readonly IMapper _mapper;
        public TransactionService(IMapper mapper) : base()
        {
            _mapper = mapper;
        }

        public override TransactionBL Map(Transaction TransactionDL)
        {
            return _mapper.Map<Transaction, TransactionBL>(TransactionDL);
        }

        public override Transaction Map(TransactionBL TransactionBL)
        {
            return _mapper.Map<TransactionBL, Transaction>(TransactionBL);
        }

        public override IEnumerable<TransactionBL> Map(IEnumerable<Transaction> transactionsDL)
        {
            return _mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionBL>>(transactionsDL);
        }

        public override IEnumerable<Transaction> Map(IEnumerable<TransactionBL> transactionsBL)
        {
            return _mapper.Map<IEnumerable<TransactionBL>, IEnumerable<Transaction>>(transactionsBL);
        }
    }
}
